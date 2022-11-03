using Xunit;

namespace RayTracer.Tests;

public sealed class RayTests
{
    [Fact]
    public void XAxisShouldBeXAxis()
    {
        Ray expected = new Ray(Vector.Origin, Vector.XBasis);
        Ray actual = Ray.XAxis;
        MathAssert.Equal(expected, actual);
    }

    [Fact]
    public void YAxisShouldBeYAxis()
    {
        Ray expected = new Ray(Vector.Origin, Vector.YBasis);
        Ray actual = Ray.YAxis;
        MathAssert.Equal(expected, actual);
    }

    [Fact]
    public void ZAxisShouldBeZAxis()
    {
        Ray expected = new Ray(Vector.Origin, Vector.ZBasis);
        Ray actual = Ray.ZAxis;
        MathAssert.Equal(expected, actual);
    }
}
