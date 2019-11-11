using System;
using System.Collections.Generic;

namespace SpeechDisordersDetrctor
{
    public static class ArrayExtension
    {
        public static double[,] CreateRectangularArray(this List<double[]> arrays)
        {
            int minorLength = arrays[0].Length;
            double[,] ret = new double[arrays.Count, minorLength];
            for (int i = 0; i < arrays.Count; i++)
            {
                var array = arrays[i];
                if (array.Length != minorLength)
                {
                    throw new ArgumentException
                        ("All arrays must be the same length");
                }
                for (int j = 0; j < minorLength; j++)
                {
                    ret[i, j] = array[j];
                }
            }
            return ret;
        }
    }
}