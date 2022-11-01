using System.Drawing;

namespace RayTracer.Tests;

internal static class TestPatterns
{
    private static Bitmap GetGradient(int size)
    {
        int rows = size;
        int cols = size;
        Bitmap bitmap = new (cols, rows);

        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                byte g = Calc(x, cols);
                byte b = Calc(y, rows);

                byte r = g > b ? g : b;

                bitmap.SetPixel(x, y, new Color(r, g, b));
            }
        }
        return bitmap;

        byte Calc(int value, int scale) =>
            (byte) (((double) value / scale) * 256);
    }
}
