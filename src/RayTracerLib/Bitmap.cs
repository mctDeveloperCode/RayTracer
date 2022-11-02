
namespace RayTracer;

public sealed class Bitmap
{
    public Bitmap(int rows, int columns)
    {
        Columns = columns;
        Rows = rows;
        frame = new Color [columns, rows];
    }

    public int Columns { get; }
    public int Rows { get; }

    public void SetPixel(int x, int y, Color argb) =>
        frame[x, y] = argb;

    public Color GetPixel(int x, int y) =>
        frame[x, y];

    private Color [,] frame;
}
