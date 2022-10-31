using Xunit;
using System.Drawing;

namespace RayTracer.Tests;

public class RayTracerLibTests
{
    [Fact]
    public void EmptySceneShouldBeBlack()
    {
        const int width = 1024;
        const int height = 1024;

        RayTracer rayTracer = new ();

        Bitmap bitmap = rayTracer.Render();

        Assert.Equal(width, bitmap.Width);
        Assert.Equal(height, bitmap.Height);

        var expectedColorArgb = Color.Black.ToArgb();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var actualColor = bitmap.GetPixel(x, y);
                Assert.Equal(expectedColorArgb, actualColor.ToArgb());
            }
        }
    }
}
