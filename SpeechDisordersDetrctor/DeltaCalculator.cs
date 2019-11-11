using System;

namespace SpeechDisordersDetrctor
{
    public static class DeltaCalculator
    {
        public static double[,] performDelta2D(double[,] data, int noOfMfcc, int M = 2)
        {
            int frameCount = data.GetLength(0);
            double mSqSum = 0;

            for (int i = -M; i < M; i++)
            {
                mSqSum += Math.Pow(i, 2);
            }

            double[,] delta = new double[frameCount, noOfMfcc];

            for (int i = 0; i < noOfMfcc; i++)
            {
                for (int k = 0; k < M; k++)
                {
                    delta[k, i] = data[k, i];
                }

                for (int k = frameCount - M; k < frameCount; k++)
                {
                    delta[k, i] = data[k, i];
                }

                for (int j = M; j < frameCount - M; j++)
                {
                    double sumDataMulM = 0;

                    for (int m = -M; m <= +M; m++)
                    {
                        sumDataMulM += m * data[m + j, i];
                    }

                    delta[j, i] = sumDataMulM / mSqSum;
                }
            }

            return delta;
        }
    }
}
