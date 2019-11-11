using Microsoft.ML.Data;

namespace BusinessLogic.Entity
{
    public class InputData
    {
        [LoadColumn(0)]
        public float MFCC1 { get; set; }
        [LoadColumn(1)]
        public float MFCC2 { get; set; }
        [LoadColumn(2)]
        public float MFCC3 { get; set; }
        [LoadColumn(3)]
        public float MFCC4 { get; set; }
        [LoadColumn(4)]
        public float MFCC5 { get; set; }
        [LoadColumn(5)]
        public float MFCC6 { get; set; }
        [LoadColumn(6)]
        public float MFCC7 { get; set; }
        [LoadColumn(7)]
        public float MFCC8 { get; set; }
        [LoadColumn(8)]
        public float MFCC9 { get; set; }
        [LoadColumn(9)]
        public float MFCC10 { get; set; }
        [LoadColumn(10)]
        public float MFCC11 { get; set; }
        [LoadColumn(11)]
        public float MFCC12 { get; set; }
        [LoadColumn(12)]
        public float MFCC13 { get; set; }

        [LoadColumn(13)]
        public float MFCCDelta1 { get; set; }
        [LoadColumn(14)]
        public float MFCCDelta2 { get; set; }
        [LoadColumn(15)]
        public float MFCCDelta3 { get; set; }
        [LoadColumn(16)]
        public float MFCCDelta4 { get; set; }
        [LoadColumn(17)]
        public float MFCCDelta5 { get; set; }
        [LoadColumn(18)]
        public float MFCCDelta6 { get; set; }
        [LoadColumn(19)]
        public float MFCCDelta7 { get; set; }
        [LoadColumn(20)]
        public float MFCCDelta8 { get; set; }
        [LoadColumn(21)]
        public float MFCCDelta9 { get; set; }
        [LoadColumn(22)]
        public float MFCCDelta10 { get; set; }
        [LoadColumn(23)]
        public float MFCCDelta11 { get; set; }
        [LoadColumn(24)]
        public float MFCCDelta12 { get; set; }
        [LoadColumn(25)]
        public float MFCCDelta13 { get; set; }

        [LoadColumn(26)]
        public float MFCCDeltaDelta1 { get; set; }
        [LoadColumn(27)]
        public float MFCCDeltaDelta2 { get; set; }
        [LoadColumn(28)]
        public float MFCCDeltaDelta3 { get; set; }
        [LoadColumn(29)]
        public float MFCCDeltaDelta4 { get; set; }
        [LoadColumn(30)]
        public float MFCCDeltaDelta5 { get; set; }
        [LoadColumn(31)]
        public float MFCCDeltaDelta6 { get; set; }
        [LoadColumn(32)]
        public float MFCCDeltaDelta7 { get; set; }
        [LoadColumn(33)]
        public float MFCCDeltaDelta8 { get; set; }
        [LoadColumn(34)]
        public float MFCCDeltaDelta9 { get; set; }
        [LoadColumn(35)]
        public float MFCCDeltaDelta10 { get; set; }
        [LoadColumn(36)]
        public float MFCCDeltaDelta11 { get; set; }
        [LoadColumn(37)]
        public float MFCCDeltaDelta12 { get; set; }
        [LoadColumn(38)]
        public float MFCCDeltaDelta13 { get; set; }

        [LoadColumn(39)]
        [ColumnName("Label")]
        public bool Label { get; set; }
    }
}