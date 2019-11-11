using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLogic.Services
{
    public class FileWorkerService : IFileWorkerService
    {
        public void CreateDirectory(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
        }

        public List<(string, string, List<string>)> DirectorySearch(string directory)
        {
            var files = new List<(string, string, List<string>)>();
            foreach (string d in Directory.GetDirectories(directory))
            {
                files.Add((directory, d, Directory.GetFiles(d, "*.wav").ToList()));
                DirectorySearch(d);
            }

            return files;
        }

        public string GetLastFolderName(string filePath)
        {
            return Path.GetFileName(Path.GetDirectoryName(filePath));
        }

        public string[] GetWavFiles(string filePath)
        {
            return Directory.GetFiles(filePath, "*.wav", SearchOption.AllDirectories);
        }

        public string WriteDataToCSVFile(List<List<double>> coeffs, bool isTrainData, TrainedMode trainedMode)
        {
            string fileName = string.Empty;
            if (isTrainData && trainedMode == TrainedMode.Simple)
                fileName = Constants.Constants.SimpleTrainedDataFileName;
            if (isTrainData && trainedMode == TrainedMode.Multi)
                fileName = Constants.Constants.MultiTrainedDataFileName;
            if (!isTrainData && trainedMode == TrainedMode.Simple)
                fileName = Constants.Constants.SimpleTestedDataFileName;
            if (!isTrainData && trainedMode == TrainedMode.Multi)
                fileName = Constants.Constants.MultiTestedDataFileName;

            using (StreamWriter outfile = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + $"{fileName}"))
            {
                for (int i = 0; i < coeffs.Count; i++)
                {
                    string content = "";
                    for (int j = 0; j < coeffs[i].Count; j++)
                    {
                        content += coeffs[i][j].ToString() + ",";
                    }

                    outfile.WriteLine(content);
                }
            }

            return AppDomain.CurrentDomain.BaseDirectory + $"{fileName}";
        }
    }
}