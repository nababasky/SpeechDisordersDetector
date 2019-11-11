using System;
using System.Collections.Generic;

namespace BusinessLogic.Extension
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

        public static double[] GetAvaragedArray(this double[,] coeff)
        {
            int rows = coeff.GetLength(0);
            int cols = coeff.GetLength(1);
            var newCoef = new List<double>();

            for (int i = 0; i < cols; i++)
            {
                double colAvg = 0;
                for (int x = 0; x < rows; x++)
                {
                    colAvg += coeff[x, i];
                }
                colAvg = colAvg / rows;
                newCoef.Add(colAvg);
            }

            return newCoef.ToArray();
        }

        public static T[][] ToJaggedArray<T>(this T[,] twoDimensionalArray)
        {
            int rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            int rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            int numberOfRows = rowsLastIndex + 1;

            int columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            int columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            int numberOfColumns = columnsLastIndex + 1;

            T[][] jaggedArray = new T[numberOfRows][];
            for (int i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new T[numberOfColumns];

                for (int j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }
            return jaggedArray;
        }
    }
}