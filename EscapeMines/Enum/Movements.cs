using System.ComponentModel;

namespace EscapeMines.Model
{
    public enum Movements
    {
        [Description("Rotate Right")]
        R,
        [Description("Rotate Left")]
        L,
        [Description("Move")]
        M,
        [Description("Unknown Movement")]
        UnknownMovement

    }
}
