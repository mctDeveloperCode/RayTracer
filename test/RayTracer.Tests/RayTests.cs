using Xunit;

namespace RayTracer.Tests;

public sealed class RayTests
{
    [Fact]
    public void XAxinTest()
    {
        Ray expected = new Ray(Vector.Origin, Vector.XBasis);
        Ray actual = Ray.XAxis;
        MathAssert.Equal(expected, actual);
    }

    [Fact]
    public void YAxinTest()
    {
        Ray expected = new Ray(Vector.Origin, Vector.YBasis);
        Ray actual = Ray.YAxis;
        MathAssert.Equal(expected, actual);
    }

    [Fact]
    public void ZAxinTest()
    {
        Ray expected = new Ray(Vector.Origin, Vector.ZBasis);
        Ray actual = Ray.ZAxis;
        MathAssert.Equal(expected, actual);
    }
}
