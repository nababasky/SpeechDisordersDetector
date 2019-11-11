using System.Collections.Generic;
using Accord.Audio;
using BusinessLogic.Interfaces;
using NAudio.Wave;

namespace BusinessLogic.Services
{
    public class AudioService : IAudioService
    {
        private readonly IFileWorkerService _fileWorkerService;
        public AudioService(IFileWorkerService fileWorkerService)
        {
            _fileWorkerService = fileWorkerService;
        }

        public void DoResampling((string, string, List<string>) item, string parentFolderName, int sampleRate)
        {
            var newParentFolderName = parentFolderName + "_" + sampleRate;

            foreach (var file in item.Item3)
            {
                var output = file.Replace(parentFolderName, newParentFolderName);
                int outRate = sampleRate;

                using (var reader = new AudioFileReader(file))
                {
                    if (reader.WaveFormat.SampleRate == outRate)
                        continue;
                    var resampler = new NAudio.Wave.SampleProviders.WdlResamplingSampleProvider(reader, outRate);
                    WaveFileWriter.CreateWaveFile16(output, resampler);
                }
            }
        }

        public double GetSampleRate(string filePath)
        {
            double sampleRate;
            using (var reader = new AudioFileReader(filePath))
            {
                sampleRate = reader.WaveFormat.SampleRate;
            }

            return sampleRate;
        }

        public Signal GetSignal(string filePath)
        {
            Signal audio;
            using (AudioFileReader reader = new AudioFileReader(filePath))
            {
                float[] samples = new float[reader.Length / 4];
                int offset = 0;
                while (reader.Position + 4 * 4096 < reader.Length)
                {
                    offset += reader.Read(samples, offset, 4096); 
                }
                audio = Signal.FromArray(samples, reader.WaveFormat.SampleRate);
            }
            return audio;
        }
    }
}