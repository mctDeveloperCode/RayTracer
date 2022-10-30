using System.Drawing;
using System.Drawing.Imaging;

public static class Program
{
    public static int Main()
    {
        Save(GetGradient(2048), @".\image.png");
        return 0;
    }

    private static void Save(Bitmap bitmap, string filename) =>
        bitmap.Save(filename, ImageFormat.Png);

    private static Bitmap GetGradient(int size)
    {
        int rows = size;
        int cols = size;
        Bitmap bitmap = new (cols, rows);

        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                int g = (int) (((double) x / cols) * 256);
                int b = (int) (((double) y / rows) * 256);

                int r = g > b ? g : b;

                bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
            }
        }
        return bitmap;
    }
}
