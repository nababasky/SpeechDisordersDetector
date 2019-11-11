namespace BusinessLogic.Interfaces
{
    public interface INeuralNetworkService
    {
        int DoSimplePrediction(double[][] inputs, int output);

        int DoMultiplePrediction(double[][] inputs, int output);
    }
}