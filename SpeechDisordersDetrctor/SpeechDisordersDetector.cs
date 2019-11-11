using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Constants;
using BusinessLogic.Enums;
using BusinessLogic.Extension;
using BusinessLogic.Interfaces;

namespace SpeechDisordersDetrctor
{
    public partial class SpeechDisordersDetector : Form
    {
        private readonly IAudioService _audioService;
        private readonly IFileWorkerService _fileWorkerService;
        private readonly IFeatureExtractorService _featureExtractorService;
        private readonly INeuralNetworkService _neuralNetworkService;
        private readonly IBaseWorker _baseWorker;

        public SpeechDisordersDetector(
            IAudioService audioService,
            IFileWorkerService fileWorkerService,
            IFeatureExtractorService featureExtractorService,
            INeuralNetworkService neuralNetworkService,
            IBaseWorker baseWorker)
        {
            _audioService = audioService;
            _fileWorkerService = fileWorkerService;
            _featureExtractorService = featureExtractorService;
            _neuralNetworkService = neuralNetworkService;
            _baseWorker = baseWorker;

            InitializeComponent();
        }

        Panel activePanel = new Panel();
        private static List<(string, string, List<string>)> Files = new List<(string, string, List<string>)>();
        private string FilePathForDataPreparing;

        private void rawDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            activePanel = rawDataPanel;
            activePanel.Visible = true;
        }

        private void AddFolderRawData_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                selectedFolder.Text = folderBrowserDialog.SelectedPath;

                Files = _fileWorkerService.DirectorySearch(folderBrowserDialog.SelectedPath);

                int sampleRate = (int)_audioService.GetSampleRate(Files.First().Item3.First());
                DialogResult result = MessageBox.Show($"Files from selected folder have {sampleRate} samperate. \n Click \"OK\" to use current samplerate\n Click \"Cancel\"  to change it", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    sampleRateValue.Text = sampleRate.ToString();
                    FilePathForDataPreparing = Files.First().Item1;
                }
                else
                {
                    using (var form = new SampeRateForm())
                    {
                        DialogResult res = form.ShowDialog();

                        if (res == DialogResult.OK)
                        {
                            sampleRate = form.SampleRateValue;
                        }
                    }

                    sampleRateValue.Text = sampleRate.ToString();
                    FilePathForDataPreparing = ResamplAndGetNewLocation(Files, sampleRate);
                }

                try
                {
                    _baseWorker.PrepareData(FilePathForDataPreparing);
                    MessageBox.Show("data prepared successfully");
                }
                catch (Exception exce)
                {
                    MessageBox.Show("error happened while preparing data");
                }

            }
        }

        private string ResamplAndGetNewLocation(List<(string, string, List<string>)> files, int sampleRate)
        {
            var parentFolderName = files[0].Item1.Split('\\').Last();
            var parentFolderInfo = (parentFolderName + "_" + sampleRate);

            var folders = files.Select(_ => _.Item2.Replace(parentFolderName, parentFolderInfo)).Distinct().ToList();

            folders.ForEach(_ => _fileWorkerService.CreateDirectory(_));

            Parallel.ForEach(files, _ => _audioService.DoResampling(_, parentFolderName, sampleRate));

            return files[0].Item1.Replace(parentFolderName, parentFolderInfo);
        }

        private void modelReadyFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Constants.SimpleTrainedDataFilePath)
                //|| !File.Exists(Constants.SimpleTestedDataFilePath)
                || !File.Exists(Constants.MultiTrainedDataFilePath)
                //|| !File.Exists(Constants.MultiTestedDataFilePath)
                )
            {
                MessageBox.Show("some files are missing");
            }

            else
            {
                activePanel = predictionPanel;
                activePanel.Visible = true;
            }
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "|*.wav;";
            dlg.ShowDialog();

            var selectedFile = dlg.FileName;
            var coeffs = _featureExtractorService.ExtractCoefficientFromAudio(selectedFile);

            string lastFolderName = _fileWorkerService.GetLastFolderName(selectedFile);
            int simpleClassLabel = lastFolderName.GetLabelForSimpleClassification();
            int multiClassLabel = lastFolderName.GetLabelForMultiClassification();

            var coeffsForClassification = new List<double[]>();

            for (int i = 0; i < coeffs.composed_mfcc.Count; i++)
            {
                var row = coeffs.composed_mfcc[i]
                    .Concat(coeffs.composed_delta[i])
                    .Concat(coeffs.composed_delta_delta[i])
                    .ToArray();

                coeffsForClassification.Add(row);
            }

            var label = (VoiceType)_neuralNetworkService.DoSimplePrediction(coeffsForClassification.ToArray(), simpleClassLabel);
            var enumLabel = label
                .GetType()
                .GetMember(label.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<DescriptionAttribute>()
                ?.Description
            ?? label.ToString();

            if (label == VoiceType.Pathological)
            {
                var multiLabel = (PathologicalType)_neuralNetworkService.DoMultiplePrediction(coeffsForClassification.ToArray(), simpleClassLabel);
                var multiEnumLabel = multiLabel
                    .GetType()
                    .GetMember(multiLabel.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? multiLabel.ToString();

                lvi.Text = $"{multiEnumLabel} - {(PathologicalType)multiClassLabel}";
                listView1.Items.Add(lvi);
            }
            else
            {
                lvi.Text = $"{enumLabel} - {(VoiceType)simpleClassLabel}";
            listView1.Items.Add(lvi);
            }
        }
    }
}
