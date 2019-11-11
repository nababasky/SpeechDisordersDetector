using BusinessLogic.Enums;

namespace BusinessLogic.Extension
{
    public static class ClassLabelExtension
    {
        public static int GetLabelForSimpleClassification(this string folderName)
        {
            switch (folderName)
            {
                case "Healthy":
                    return (int)VoiceType.Healthy;
                default:
                    return (int)VoiceType.Pathological;
            }
        }

        public static int GetLabelForMultiClassification(this string folderName)
        {
            switch (folderName)
            {
                case "Chordektomie":
                    return (int)PathologicalType.Chordektomie;
                case "Dysphonie":
                    return (int)PathologicalType.Dysphonie;
                case "Kontaktpachydermie":
                    return (int)PathologicalType.Kontaktpachydermie;
                case "Laryngitis":
                    return (int)PathologicalType.Laryngitis;
                default:
                    return int.MaxValue;
            }
        }
    }
}