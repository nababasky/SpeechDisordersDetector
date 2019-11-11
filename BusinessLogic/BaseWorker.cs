using BusinessLogic.Interfaces;
using System.Linq;

namespace BusinessLogic
{
    public class BaseWorker : IBaseWorker
    {
        private readonly IFeatureExtractorService _featureExtractorService;
        private readonly IFileWorkerService _fileWorkerService;

        public BaseWorker(IFeatureExtractorService featureExtractorService, IFileWorkerService fileWorkerService)
        {
            _fileWorkerService = fileWorkerService;
            _featureExtractorService = featureExtractorService;
        }

        public void PrepareData(string filePath)
        {
            var coeffs = _featureExtractorService.ExtractCoefficients(filePath);
            var simpleCoeffs = coeffs.simple;
            var multiCoeffs = coeffs.multi.Where(_ => _[_.Count - 1] != int.MaxValue).ToList();

            var simpleCoeffsItemsCount = simpleCoeffs.Count;
            var multiCoeffsItemsCount = multiCoeffs.Count;

            //var simpleTrainedData = simpleCoeffs.Take((simpleCoeffsItemsCount * 75) / 100).ToList();
            //var simpleTestingData = simpleCoeffs.Skip(simpleTrainedData.Count).ToList();

            //var multiTrainedData = multiCoeffs.Take((multiCoeffsItemsCount * 75) / 100).ToList();
            //var multiTestingData = multiCoeffs.Skip(multiTrainedData.Count).ToList();

            var simpleTrainedData = simpleCoeffs.ToList();
            var multiTrainedData = multiCoeffs.ToList();

            _fileWorkerService.WriteDataToCSVFile(simpleTrainedData, true, Enums.TrainedMode.Simple);
            //_fileWorkerService.WriteDataToCSVFile(simpleTestingData, false, Enums.TrainedMode.Simple);
            _fileWorkerService.WriteDataToCSVFile(multiTrainedData, true, Enums.TrainedMode.Multi);
            //_fileWorkerService.WriteDataToCSVFile(multiTestingData, false, Enums.TrainedMode.Multi);
        }
    }
}