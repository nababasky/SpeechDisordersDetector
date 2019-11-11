using BusinessLogic.Entity;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Training
{
    class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                Console.WriteLine("Training Data Set");
                Console.WriteLine("-----------------");
                //await TrainAsync(BusinessLogic.Constants.Constants.TrainedDataFilePath, BusinessLogic.Constants.Constants.ModelFilePath);

                Console.WriteLine();

                Console.ReadKey();

            }).GetAwaiter().GetResult();
        }

        internal static async Task
            TrainAsync(string trainingDataFile, string modelPath)
        {
            var pipeline = new LearningPipeline();

            pipeline.Add(new TextLoader(trainingDataFile).CreateFrom<InputData>(separator: ','));

            pipeline.Add(new Dictionarizer("Label"));
            pipeline.Add(new ColumnConcatenator("Features", "MFCC1", "MFCC2", "MFCC3", "MFCC4",
                                                                         "MFCC5", "MFCC6", "MFCC7", "MFCC8",
                                                                         "MFCC9", "MFCC10", "MFCC11",
                                                                         "MFCC12", "MFCC13", "MFCCDelta1", "MFCCDelta2", "MFCCDelta3", "MFCCDelta4",
                                                                         "MFCCDelta5", "MFCCDelta6", "MFCCDelta7", "MFCCDelta8",
                                                                         "MFCCDelta9", "MFCCDelta10", "MFCCDelta11",
                                                                         "MFCCDelta12", "MFCCDelta13", "MFCCDeltaDelta1", "MFCCDeltaDelta2", "MFCCDeltaDelta3", "MFCCDeltaDelta4",
                                                                         "MFCCDeltaDelta5", "MFCCDeltaDelta6", "MFCCDeltaDelta7", "MFCCDeltaDelta8",
                                                                         "MFCCDeltaDelta9", "MFCCDeltaDelta10", "MFCCDeltaDelta11",
                                                                         "MFCCDeltaDelta12", "MFCCDeltaDelta13"));

            pipeline.Add(new StochasticDualCoordinateAscentClassifier());

            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLabel" });

            PredictionModel<InputData, OutputData> model =
                                pipeline.Train<InputData, OutputData>();

            await model.WriteAsync(modelPath);

            Console.WriteLine("Model created");
        }
    }
}
