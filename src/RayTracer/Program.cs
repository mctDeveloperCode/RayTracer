using System.Drawing;
using System.Drawing.Imaging;

namespace RayTracer.Cli;

public static class Program
{
    public static int Main()
    {
        return 0;
    }
}

internal static class BitmapExtensions
{
    internal static void SaveTo(this Bitmap bitmap, string filename) =>
        bitmap.Save(filename, ImageFormat.Png);
}
