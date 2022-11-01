
namespace RayTracer;

public sealed class Bitmap
{
    public Bitmap(int width, int height)
    {
        Width = width;
        Height = height;
        frame = new Color [width, height];
    }

    public int Width { get; }
    public int Height { get; }

    public void SetPixel(int x, int y, Color argb) =>
        frame[x, y] = argb;

    public Color GetPixel(int x, int y) =>
        frame[x, y];

    private Color [,] frame;
}
