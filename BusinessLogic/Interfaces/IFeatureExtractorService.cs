using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IFeatureExtractorService
    {
        (List<List<double>> simple, List<List<double>> multi) ExtractCoefficients(string filePath);
        (List<double[]> composed_mfcc, List<double[]> composed_delta, List<double[]> composed_delta_delta) ExtractCoefficientFromAudio(string filePath);
    }
}