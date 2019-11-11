using Accord.MachineLearning;
using Accord.Math.Distances;
using Accord.Statistics.Analysis;
using BusinessLogic.Entity;
using BusinessLogic.Interfaces;
using System;
using System.Linq;

namespace BusinessLogic.Services
{
    public class NeuralNetworkService : INeuralNetworkService
    {
        public int DoMultiplePrediction(double[][] inputs, int output)
        {
            Dataset multiTrainedDataset = new Dataset(Constants.Constants.MultiTrainedDataFilePath);

            double[][] multiTrainedDatasetInputs = multiTrainedDataset.Instances;
            int[] mltiTrainedDatasetOutputs = multiTrainedDataset.ClassLabels;

            var multiknn = new KNearestNeighbors()
            {
                K = 5,
                Distance = new Euclidean()
            };

            multiknn = multiknn.Learn(multiTrainedDatasetInputs, mltiTrainedDatasetOutputs);

            int[] predicted = multiknn.Decide(inputs);

            return predicted
                .GroupBy(_ => _)
                .OrderByDescending(_ => _.Count())
                .Select(_ => _.Key)
                .First();
        }

        public int DoSimplePrediction(double[][] inputs, int output)
        {
            Dataset simpleTrainedDataset = new Dataset(Constants.Constants.SimpleTrainedDataFilePath);

            double[][] simpleTrainedDatasetInputs = simpleTrainedDataset.Instances;
            int[] simpleTrainedDatasetOutputs = simpleTrainedDataset.ClassLabels;

            var knn = new KNearestNeighbors()
            {
                K = 5,
                Distance = new Euclidean()
            };


            knn = knn.Learn(simpleTrainedDatasetInputs, simpleTrainedDatasetOutputs);
            int[] predicted = knn.Decide(inputs);

            return predicted
                .GroupBy(_ => _)
                .OrderByDescending(_ => _.Count())
                .Select(_ => _.Key)
                .First();
        }
    }
}