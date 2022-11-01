
namespace RayTracer;

public struct Color
{
    public Color(byte r, byte g, byte b) =>
        Argb = (uint) (0xFF000000u | ((uint) r) << 16 | ((uint) g) << 8 | ((uint) b));

    // public Color(byte a, byte r, byte g, byte b) : this(r, g, b) =>
    //     Argb = ((uint) a) << 24 | (this.Argb & 0x00FFFFFFu);

    public uint Argb { get; }

    public static Color Black { get; } = new Color(0, 0, 0);

    // public byte A => (byte) (Argb & 0xFF000000u >> 24);
    // public byte R => (byte) (Argb & 0x00FF0000u >> 16);
    // public byte G => (byte) (Argb & 0x0000FF00u >> 8);
    // public byte B => (byte) (Argb & 0x000000FFu >> 0);

    // public static explicit operator uint(Color color) => color.Argb;
    // public static explicit operator int(Color color) => (int) color.Argb;
}
