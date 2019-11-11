using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Audio;
using BusinessLogic.Extension;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class FeatureExtractorService : IFeatureExtractorService
    {
        private readonly IFileWorkerService _fileWorkerService;
        private readonly IAudioService _audioService;

        public FeatureExtractorService(IFileWorkerService fileWorkerService, IAudioService audioSevice)
        {
            _fileWorkerService = fileWorkerService;
            _audioService = audioSevice;
        }

        public (List<List<double>> simple, List<List<double>> multi) ExtractCoefficients(string filePath)
        {
            var allFiles = _fileWorkerService.GetWavFiles(filePath);
            var random = new Random();
            allFiles = allFiles.OrderBy(_ => random.Next()).ToArray();

            var simpleCoeefs = new List<List<double>>();
            var multiCoeefs = new List<List<double>>();

            foreach (var file in allFiles)
            {
                var coeffs = ExtractCoefficientFromAudio(file);

                string lastFolderName = _fileWorkerService.GetLastFolderName(file);

                int simpleClassLabel = lastFolderName.GetLabelForSimpleClassification();
                int multiClassLabel = lastFolderName.GetLabelForMultiClassification();

                for (int i = 0; i < coeffs.composed_mfcc.Count; i++)
                {
                    var row = coeffs.composed_mfcc[i]
                        .Concat(coeffs.composed_delta[i])
                        .Concat(coeffs.composed_delta_delta[i])
                        .Concat(new double[] { Convert.ToDouble(simpleClassLabel) })
                        .ToList();

                    simpleCoeefs.Add(row);
                }

                for (int i = 0; i < coeffs.composed_mfcc.Count; i++)
                {
                    if (multiClassLabel != int.MaxValue)
                    {
                        var row = coeffs.composed_mfcc[i]
                            .Concat(coeffs.composed_delta[i])
                            .Concat(coeffs.composed_delta_delta[i])
                            .Concat(new double[] { Convert.ToDouble(multiClassLabel) })
                            .ToList();

                        multiCoeefs.Add(row);
                    }
                }
            }

            return (simple: simpleCoeefs, multi: multiCoeefs);
        }

        public (List<double[]> composed_mfcc, List<double[]> composed_delta, List<double[]> composed_delta_delta) ExtractCoefficientFromAudio(string filePath)
        {
            var audio = _audioService.GetSignal(filePath);

            var mfcc = new MelFrequencyCepstrumCoefficient(
                filterCount: 26,
                cepstrumCount: 13,
                lowerFrequency: 300,
                upperFrequency: audio.SampleRate / 2,
                alpha: 0.97,
                samplingRate:
                audio.SampleRate,
                frameRate: 25,
                windowLength: 0.0257,
                numberOfBins: 512);

            var cepstrumCoefficients = mfcc.Transform(audio).Select(_ => _.Descriptor).ToList();

            double[,] mfcc_list = cepstrumCoefficients.CreateRectangularArray();

            var delta = mfcc_list.performDelta2D();
            var deltaDelta = delta.performDelta2D();

            List<double[]> composed_mfcc = mfcc_list.ToJaggedArray().ToList();
            List<double[]> composed_delta = delta.ToJaggedArray().ToList();
            List<double[]> composed_delta_delta = deltaDelta.ToJaggedArray().ToList();

            return (composed_mfcc: composed_mfcc, composed_delta: composed_delta, composed_delta_delta: composed_delta_delta);
        }
    }
}