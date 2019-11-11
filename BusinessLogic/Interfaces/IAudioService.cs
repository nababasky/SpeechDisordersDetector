using Accord.Audio;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IAudioService
    {
        Signal GetSignal(string filePath);
        double GetSampleRate(string filePath);
        void DoResampling((string, string, List<string>) item, string parentFolderName, int sampleRate);
    }
}