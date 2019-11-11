using System;
using System.IO;
using System.Linq;

namespace BusinessLogic.Entity
{
    public class Dataset
    {
        public double[][] Instances { get; private set; }

        public int[] ClassLabels { get; private set; }

        public string[] ClassNames { get; private set; }

        public string[] VariableNames { get; private set; }

        public Dataset(string filePath)
        {
            var rows = File.ReadAllLines(filePath).Select(l => l.Split(',').Where(_ => !string.IsNullOrEmpty(_)).ToArray()).ToArray();

            double[,] data = new double[rows.Length, rows.Max(_ => _.Length)];
            for (var i = 0; i < rows.Length; i++)
            {
                for (var j = 0; j < rows[i].Length; j++)
                {
                    data[i, j] = Convert.ToDouble(rows[i][j]);
                }
            }

            ClassNames = new[] { "MFCC1", "MFCC2", "MFCC3", "MFCC4",
                                    "MFCC5", "MFCC6", "MFCC7", "MFCC8",
                                    "MFCC9", "MFCC10", "MFCC11","MFCC12", "MFCC13",
                                    "MFCCDelta1", "MFCCDelta2", "MFCCDelta3",
                                    "MFCCDelta4", "MFCCDelta5", "MFCCDelta6",
                                    "MFCCDelta7", "MFCCDelta8", "MFCCDelta9",
                                    "MFCCDelta10", "MFCCDelta11", "MFCCDelta12", "MFCCDelta13",
                                    "MFCCDeltaDelta1", "MFCCDeltaDelta2", "MFCCDeltaDelta3",
                                    "MFCCDeltaDelta4", "MFCCDeltaDelta5", "MFCCDeltaDelta6",
                                    "MFCCDeltaDelta7", "MFCCDeltaDelta8", "MFCCDeltaDelta9",
                                    "MFCCDeltaDelta10", "MFCCDeltaDelta11", "MFCCDeltaDelta12", "MFCCDeltaDelta13" };

            VariableNames = new[] { "MFCC1", "MFCC2", "MFCC3", "MFCC4",
                                    "MFCC5", "MFCC6", "MFCC7", "MFCC8",
                                    "MFCC9", "MFCC10", "MFCC11","MFCC12", "MFCC13",
                                    "MFCCDelta1", "MFCCDelta2", "MFCCDelta3",
                                    "MFCCDelta4", "MFCCDelta5", "MFCCDelta6",
                                    "MFCCDelta7", "MFCCDelta8", "MFCCDelta9",
                                    "MFCCDelta10", "MFCCDelta11", "MFCCDelta12", "MFCCDelta13",
                                    "MFCCDeltaDelta1", "MFCCDeltaDelta2", "MFCCDeltaDelta3",
                                    "MFCCDeltaDelta4", "MFCCDeltaDelta5", "MFCCDeltaDelta6",
                                    "MFCCDeltaDelta7", "MFCCDeltaDelta8", "MFCCDeltaDelta9",
                                    "MFCCDeltaDelta10", "MFCCDeltaDelta11", "MFCCDeltaDelta12", "MFCCDeltaDelta13" };

            int n = data.GetLength(0);
            int d = data.GetLength(1) - 1;
            Instances = new double[n][];
            ClassLabels = new int[n];
            for (int i = 0; i < Instances.Length; i++)
            {
                Instances[i] = new double[d];
                for (int j = 0; j < d; j++)
                    Instances[i][j] = data[i, j];
                ClassLabels[i] = (int)data[i, d];
            }

        }
    }
}
