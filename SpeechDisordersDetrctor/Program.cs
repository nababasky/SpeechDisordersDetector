using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace SpeechDisordersDetrctor
{
    static class Program
    {
        private static Container container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BuildUp();
            Application.Run(container.GetInstance<SpeechDisordersDetector>());
        }

        private static void BuildUp()
        {
            // Create the container as usual.
            container = new Container();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            // Register your types, for instance:
            container.Register<IAudioService, AudioService>(Lifestyle.Transient);
            container.Register<IFeatureExtractorService, FeatureExtractorService>(Lifestyle.Transient);
            container.Register<IFileWorkerService, FileWorkerService>(Lifestyle.Transient);
            container.Register<INeuralNetworkService, NeuralNetworkService>(Lifestyle.Transient);
            container.Register<IBaseWorker, BaseWorker>(Lifestyle.Transient);

            // Optionally verify the container.
            container.Verify();
        }
    }
}
