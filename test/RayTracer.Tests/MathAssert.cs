using Xunit;

namespace RayTracer.Tests;

internal static class MathAssert
{
    private const int precision = 15;

    public static void Equal(double expected, double actual) =>
        Assert.Equal(expected, actual, precision);

    public static void Equal(Vector expected, Vector actual)
    {
        Assert.Equal(expected.X, actual.X, precision);
        Assert.Equal(expected.Y, actual.Y, precision);
        Assert.Equal(expected.Z, actual.Z, precision);
    }

    public static void Equal(Ray expected, Ray actual)
    {
        MathAssert.Equal(expected.Position, actual.Position);
        MathAssert.Equal(expected.Direction, actual.Direction);
    }
}
