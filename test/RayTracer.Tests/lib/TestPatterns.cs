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
                int g = Calc(x, cols);
                int b = Calc(y, rows);

                int r = g > b ? g : b;

                bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
            }
        }
        return bitmap;

        int Calc(int value, int scale) =>
            (int) (((double) value / scale) * 256);
    }
}
