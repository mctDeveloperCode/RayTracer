using Xunit;
using System.Drawing;

namespace RayTracer.Tests;

public sealed class RayTracerLibTests
{
    [Fact]
    public void EmptySceneShouldBeBlack()
    {
        const int width = 1024;
        const int height = 1024;

        RayTracer rayTracer = new ();

        Bitmap bitmap = rayTracer.Render();

        Assert.Equal(width, bitmap.Columns);
        Assert.Equal(height, bitmap.Rows);

        var expectedColor = Color.Black;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var actualColor = bitmap.GetPixel(x, y);
                Assert.Equal(expectedColor, actualColor);
            }
        }
    }
}
