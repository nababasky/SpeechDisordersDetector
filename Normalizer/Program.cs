using Accord.Audio;
using Accord.DirectSound;
using Microsoft.Scripting.Hosting;
using NAudio.Wave;
using NAudio.Wave.Compression;
using NAudio.Wave.SampleProviders;
using Numpy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Normalizer
{
    class Program
    {

        private static List<(string, string, List<string>)> Files = new List<(string, string, List<string>)>();

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Ready for audio proccesing \n\n");
            Console.WriteLine("Please select folder for proccesing");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            var directoriesWithFiles = new Dictionary<string, string[]>();

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //DialogResult dialogResult1 = openFileDialog.ShowDialog();
            //if (dialogResult1 == DialogResult.OK
            //    && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
            //{
            //    Signal audio;
            //    using (AudioFileReader reader = new AudioFileReader(openFileDialog.FileName))
            //    {
            //        float[] samples = new float[reader.Length / 4];
            //        int offset = 0;
            //        while (reader.Position + 4 * 4096 < reader.Length)
            //        {
            //            offset += reader.Read(samples, offset, 4096);
            //        }
            //        audio = Signal.FromArray(samples, reader.WaveFormat.SampleRate);
            //    }

            //    var mfcc = new MelFrequencyCepstrumCoefficient();
            //    var cepstrumCoefficients = mfcc.Transform(audio).Select(_=>_.Descriptor).ToList();
                
            //    var N = 2;
            //    double[,] mfcc_list = cepstrumCoefficients.CreateRectangularArray();

            //    var delta = DeltaCalculator.performDelta2D(mfcc_list, 13, 2);
            //    var deltaDelta = DeltaCalculator.performDelta2D(delta, 13, 2);

            //    var composed_mfcc = GetAvaragedArray(mfcc_list);
            //    var composed_delta = GetAvaragedArray(delta);
            //    var composed_delta_delta = GetAvaragedArray(deltaDelta);

            //    var result = composed_mfcc.Concat(composed_delta).Concat(composed_delta_delta).ToList();
            //}



            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();


            if (dialogResult == DialogResult.OK
                && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {

                DirSearch(folderBrowserDialog.SelectedPath);

                Resampling(Files);
            }
            else
            {
                Console.WriteLine($"Selected Folder {folderBrowserDialog.SelectedPath} do not containts necessary files");
            }
            Console.WriteLine("Press any key to exit");


            Console.ReadKey();
        }

        private static void Resampling(List<(string, string, List<string>)> files)
        {
            var parentFolderName = files[0].Item1.Split('\\').Last();
            var parentFolderInfo = Directory.CreateDirectory(parentFolderName + "_16000");

            Console.WriteLine($"Folder {parentFolderInfo.Name} have been created");

            Parallel.ForEach(files, _ => DoResampling(_, parentFolderName));
        }

        private static void DoResampling((string, string, List<string>) item, string parentFolderName)
        {
            var newParentFolderName = parentFolderName + "_16000";

            var subFolderInfo = Directory.CreateDirectory(item.Item2.Replace(parentFolderName, newParentFolderName));
            Console.WriteLine($"Folder {subFolderInfo.Name} have been created in folder {item.Item1}");

            foreach(var file in item.Item3)
            {
                var output = file.Replace(parentFolderName, newParentFolderName);
                int outRate = 16000;

                using (var reader = new AudioFileReader(file))
                {
                    if (reader.WaveFormat.SampleRate == outRate)
                        continue;
                    var resampler = new WdlResamplingSampleProvider(reader, outRate);
                    WaveFileWriter.CreateWaveFile16(output, reader);
                }
            }








            //var outputDirectory = selectedPath + "_Resampled_8000";
            //var info = Directory.CreateDirectory(outputDirectory);
            //Console.WriteLine($"Folder {info.Name} have been created");

            //var outputSubDirectory = outputDirectory + "\\" + directoryWithFiles.Key.Split('\\').Last();
            //var subInfo = Directory.CreateDirectory(outputSubDirectory);
            //Console.WriteLine($"SubFolder {subInfo.Name} have been created in folder {info.Name}");

            //foreach (var file in directoryWithFiles.Value)
            //{
            //    var filename = Regex.Match(file, @".*\\([^\\]+$)").Groups[1].Value;
            //    var outputFileDirection = outputSubDirectory + "\\" + filename;
            //    int outRate = 8000;

            //    using (var reader = new AudioFileReader(file))
            //    {
            //        if (reader.WaveFormat.SampleRate == outRate)
            //            continue;
            //        var resampler = new WdlResamplingSampleProvider(reader, outRate);
            //        WaveFileWriter.CreateWaveFile16(outputFileDirection, reader);
            //    }
            //}

            //Console.WriteLine("Files successfuly resampled");
        }

        public static double[] GetAvaragedArray(double[,] coeff)
        {
            int rows = coeff.GetLength(0);
            int cols = coeff.GetLength(1);
            var newCoef = new List<double>();

            for (int i = 0; i < cols; i++)
            {
                double colAvg = 0;
                for (int x = 0; x < rows; x++)
                {
                    colAvg += coeff[x, i];
                }
                colAvg = colAvg / rows;
                newCoef.Add(colAvg);
            }

            return newCoef.ToArray();
        }

        static void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    Files.Add((sDir, d, Directory.GetFiles(d, "*.wav").ToList()));
                    DirSearch(d);
                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}