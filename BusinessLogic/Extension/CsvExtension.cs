using BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Extension
{
    public static class CsvExtension
    {
        public static InputData FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            InputData inputData = new InputData();
            inputData.MFCC1 = (float)Convert.ToDouble(values[0]);
            inputData.MFCC2 = (float)Convert.ToDouble(values[1]);
            inputData.MFCC3 = (float)Convert.ToDouble(values[2]);
            inputData.MFCC4 = (float)Convert.ToDouble(values[3]);
            inputData.MFCC5 = (float)Convert.ToDouble(values[4]);
            inputData.MFCC6 = (float)Convert.ToDouble(values[5]);
            inputData.MFCC7 = (float)Convert.ToDouble(values[6]);
            inputData.MFCC8 = (float)Convert.ToDouble(values[7]);
            inputData.MFCC9 = (float)Convert.ToDouble(values[8]);
            inputData.MFCC10 = (float)Convert.ToDouble(values[9]);
            inputData.MFCC11 = (float)Convert.ToDouble(values[10]);
            inputData.MFCC12 = (float)Convert.ToDouble(values[11]);
            inputData.MFCC13 = (float)Convert.ToDouble(values[12]);

            inputData.MFCCDelta1 = (float)Convert.ToDouble(values[13]);
            inputData.MFCCDelta2 = (float)Convert.ToDouble(values[14]);
            inputData.MFCCDelta3 = (float)Convert.ToDouble(values[15]);
            inputData.MFCCDelta4 = (float)Convert.ToDouble(values[16]);
            inputData.MFCCDelta5 = (float)Convert.ToDouble(values[17]);
            inputData.MFCCDelta6 = (float)Convert.ToDouble(values[18]);
            inputData.MFCCDelta7 = (float)Convert.ToDouble(values[19]);
            inputData.MFCCDelta8 = (float)Convert.ToDouble(values[20]);
            inputData.MFCCDelta9 = (float)Convert.ToDouble(values[21]);
            inputData.MFCCDelta10 = (float)Convert.ToDouble(values[22]);
            inputData.MFCCDelta11 = (float)Convert.ToDouble(values[23]);
            inputData.MFCCDelta12 = (float)Convert.ToDouble(values[24]);
            inputData.MFCCDelta13 = (float)Convert.ToDouble(values[25]);

            inputData.MFCCDeltaDelta1 = (float)Convert.ToDouble(values[26]);
            inputData.MFCCDeltaDelta2 = (float)Convert.ToDouble(values[27]);
            inputData.MFCCDeltaDelta3 = (float)Convert.ToDouble(values[28]);
            inputData.MFCCDeltaDelta4 = (float)Convert.ToDouble(values[29]);
            inputData.MFCCDeltaDelta5 = (float)Convert.ToDouble(values[30]);
            inputData.MFCCDeltaDelta6 = (float)Convert.ToDouble(values[31]);
            inputData.MFCCDeltaDelta7 = (float)Convert.ToDouble(values[32]);
            inputData.MFCCDeltaDelta8 = (float)Convert.ToDouble(values[33]);
            inputData.MFCCDeltaDelta9 = (float)Convert.ToDouble(values[34]);
            inputData.MFCCDeltaDelta10 = (float)Convert.ToDouble(values[35]);
            inputData.MFCCDeltaDelta11 = (float)Convert.ToDouble(values[36]);
            inputData.MFCCDeltaDelta12 = (float)Convert.ToDouble(values[37]);
            inputData.MFCCDeltaDelta13 = (float)Convert.ToDouble(values[38]);

            return inputData;
        }

        //public static string LabelFromCsv(this string csvLine)
        //{
        //    string[] values = csvLine.Split(',');

        //    return Convert.ToInt32(values[39]);
        //}
    }
}
