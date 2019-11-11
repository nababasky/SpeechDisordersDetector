using Microsoft.ML.Data;

namespace SpeechDisordersDetrctor.Data
{
    public class InputData
    {
        [LoadColumn(0)]
        public string MFCC_1 { get; set; }
        [LoadColumn(1)]
        public string MFCC_2 { get; set; }
        [LoadColumn(2)]
        public string MFCC_3 { get; set; }
        [LoadColumn(3)]
        public string MFCC_4 { get; set; }
        [LoadColumn(4)]
        public string MFCC_5 { get; set; }
        [LoadColumn(5)]
        public string MFCC_6 { get; set; }
        [LoadColumn(6)]
        public string MFCC_7 { get; set; }
        [LoadColumn(7)]
        public string MFCC_8 { get; set; }
        [LoadColumn(8)]
        public string MFCC_9 { get; set; }
        [LoadColumn(9)]
        public string MFCC_10 { get; set; }
        [LoadColumn(10)]
        public string MFCC_11 { get; set; }
        [LoadColumn(11)]
        public string MFCC_12 { get; set; }
        [LoadColumn(12)]
        public string MFCC_13 { get; set; }

        [LoadColumn(13)]
        public string MFCC_Delta_1 { get; set; }
        [LoadColumn(14)]
        public string MFCC_Delta_2 { get; set; }
        [LoadColumn(15)]
        public string MFCC_Delta_3 { get; set; }
        [LoadColumn(16)]
        public string MFCC_Delta_4 { get; set; }
        [LoadColumn(17)]
        public string MFCC_Delta_5 { get; set; }
        [LoadColumn(18)]
        public string MFCC_Delta_6 { get; set; }
        [LoadColumn(19)]
        public string MFCC_Delta_7 { get; set; }
        [LoadColumn(20)]
        public string MFCC_Delta_8 { get; set; }
        [LoadColumn(21)]
        public string MFCC_Delta_9 { get; set; }
        [LoadColumn(22)]
        public string MFCC_Delta_10 { get; set; }
        [LoadColumn(23)]
        public string MFCC_Delta_11 { get; set; }
        [LoadColumn(24)]
        public string MFCC_Delta_12 { get; set; }
        [LoadColumn(25)]
        public string MFCC_Delta_13 { get; set; }

        [LoadColumn(26)]
        public string MFCC_Delta_Delta_1 { get; set; }
        [LoadColumn(27)]
        public string MFCC_Delta_Delta_2 { get; set; }
        [LoadColumn(28)]
        public string MFCC_Delta_Delta_3 { get; set; }
        [LoadColumn(29)]
        public string MFCC_Delta_Delta_4 { get; set; }
        [LoadColumn(30)]
        public string MFCC_Delta_Delta_5 { get; set; }
        [LoadColumn(31)]
        public string MFCC_Delta_Delta_6 { get; set; }
        [LoadColumn(32)]
        public string MFCC_Delta_Delta_7 { get; set; }
        [LoadColumn(33)]
        public string MFCC_Delta_Delta_8 { get; set; }
        [LoadColumn(34)]
        public string MFCC_Delta_Delta_9 { get; set; }
        [LoadColumn(35)]
        public string MFCC_Delta_Delta_10 { get; set; }
        [LoadColumn(36)]
        public string MFCC_Delta_Delta_11 { get; set; }
        [LoadColumn(37)]
        public string MFCC_Delta_Delta_12 { get; set; }
        [LoadColumn(38)]
        public string MFCC_Delta_Delta_13 { get; set; }

        [LoadColumn(39)]
        [ColumnName("Label")]
        public string Label;
    }

    public class ClassPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Class;
    }
}
