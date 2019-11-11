using System.ComponentModel;

namespace BusinessLogic.Enums
{
    public enum PathologicalType
    {
        [Description("Chordektomie")]
        Chordektomie = 0,
        [Description("Dysphonie")]
        Dysphonie,
        [Description("Kontaktpachydermie")]
        Kontaktpachydermie,
        [Description("Laryngitis")]
        Laryngitis
    }
}