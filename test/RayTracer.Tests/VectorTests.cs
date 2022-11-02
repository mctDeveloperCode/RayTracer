using Xunit;

namespace RayTracer.Tests;

public sealed class VectorTests
{
    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0)]
    [InlineData(1.0, 0.0, 0.0, 1.0)]
    [InlineData(0.0, 1.0, 0.0, 1.0)]
    [InlineData(0.0, 0.0, 1.0, 1.0)]
    [InlineData(3.0, 4.0, 0.0, 5.0)]
    [InlineData(0.0, 3.0, 4.0, 5.0)]
    [InlineData(4.0, 0.0, 3.0, 5.0)]
    [InlineData(2.0, 3.0, 6.0, 7.0)]
    [InlineData(1.0, 1.0, 1.0, 1.7320508075688772)]
    public void LengthTest(double x, double y, double z, double expected)
    {
        Vector vector = new (x, y, z);
        double actual = vector.Length;
        Equal(expected, actual);
    }

    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0)]
    [InlineData(1.0, 0.0, 0.0, 1.0)]
    [InlineData(0.0, 1.0, 0.0, 1.0)]
    [InlineData(0.0, 0.0, 1.0, 1.0)]
    [InlineData(3.0, 4.0, 0.0, 25.0)]
    [InlineData(0.0, 3.0, 4.0, 25.0)]
    [InlineData(4.0, 0.0, 3.0, 25.0)]
    [InlineData(2.0, 3.0, 6.0, 49.0)]
    [InlineData(1.0, 1.0, 1.0, 3.0)]
    public void Length2Test(double x, double y, double z, double expected)
    {
        Vector vector = new (x, y, z);
        double actual = vector.Length2;
        Equal(expected, actual);
    }

    [Theory]
    [InlineData(2.0, 3.0, 6.0, 7.0)]
    [InlineData(1.0, 0.0, 0.0, 1.0)]
    [InlineData(0.0, 1.0, 0.0, 1.0)]
    [InlineData(0.0, 0.0, 1.0, 1.0)]
    public void UnitVectorTest(double x, double y, double z, double length)
    {
        Vector expected = new (x / length, y / length, z / length);

        Vector vector = new (x, y, z);
        Vector actual = vector.Unit();

        Equal(expected, actual);
        Equal(1.0, actual.Length);
    }


    [Fact]
    public void OriginTest()
    {
        Vector expected = new Vector(0.0, 0.0, 0.0);
        Vector actual = Vector.Origin;
        Equal(expected, actual);
    }

    [Fact]
    public void XBasisTest()
    {
        Vector expected = new Vector(1.0, 0.0, 0.0);
        Vector actual = Vector.XBasis;
        Equal(expected, actual);
    }

    [Fact]
    public void YBasisTest()
    {
        Vector expected = new Vector(0.0, 1.0, 0.0);
        Vector actual = Vector.YBasis;
        Equal(expected, actual);
    }

    [Fact]
    public void ZBasisTest()
    {
        Vector expected = new Vector(0.0, 0.0, 1.0);
        Vector actual = Vector.ZBasis;
        Equal(expected, actual);
    }

    private const int precision = 15;

    private void Equal(double expected, double actual) =>
        Assert.Equal(expected, actual, precision);

    private void Equal(Vector expected, Vector actual)
    {
        Assert.Equal(expected.X, actual.X, precision);
        Assert.Equal(expected.Y, actual.Y, precision);
        Assert.Equal(expected.Z, actual.Z, precision);
    }
}
