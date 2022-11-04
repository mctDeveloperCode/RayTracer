using Xunit;
using System.Collections.Generic;

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

    [Fact]
    internal void ShouldCastSingleRayPerPixel()
    {
        // Point of view
        Ray pov = new (Vector.Origin, Vector.XBasis);

        // Frame
        Vector up = new (1.0, 0.0, 1.0);
        double width = 0.1;
        double height = 0.1;
        int rows = 1;
        int columns = 1;

        Camera camera = new (pov, up, width, height, rows, columns);
    }
}
