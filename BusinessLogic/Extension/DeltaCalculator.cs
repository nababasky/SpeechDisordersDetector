using System;

namespace BusinessLogic.Extension
{
    public static class DeltaCalculator
    {
        private static int NumberOfMFCC = 13;
        private static int M = 2;

        public static double[,] performDelta2D(this double[,] data)
        {
            int frameCount = data.GetLength(0);
            double mSqSum = 0;

            for (int i = -M; i < M; i++)
            {
                mSqSum += Math.Pow(i, 2);
            }

            double[,] delta = new double[frameCount, NumberOfMFCC];

            for (int i = 0; i < NumberOfMFCC; i++)
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

                    delta[j, i] = sumDataMulM / 2 * mSqSum;
                }
            }

            return delta;
        }
    }
}
