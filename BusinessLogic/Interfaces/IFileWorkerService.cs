using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IFileWorkerService
    {
        void CreateDirectory(string directoryPath);

        string WriteDataToCSVFile(List<List<double>> coeffs, bool isTrainData, TrainedMode trainedMode);

        List<(string, string, List<string>)> DirectorySearch(string directory);

        string[] GetWavFiles(string filePath);

        string GetLastFolderName(string filePath);
    }
}