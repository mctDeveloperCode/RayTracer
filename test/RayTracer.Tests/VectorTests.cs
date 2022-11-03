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
        MathAssert.Equal(expected, actual);
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
        MathAssert.Equal(expected, actual);
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

        MathAssert.Equal(expected, actual);
        MathAssert.Equal(1.0, actual.Length);
    }


    [Fact]
    public void OriginTest()
    {
        Vector expected = new Vector(0.0, 0.0, 0.0);
        Vector actual = Vector.Origin;
        MathAssert.Equal(expected, actual);
    }

    [Fact]
    public void XBasisTest()
    {
        Vector expected = new Vector(1.0, 0.0, 0.0);
        Vector actual = Vector.XBasis;
        MathAssert.Equal(expected, actual);
    }

    [Fact]
    public void YBasisTest()
    {
        Vector expected = new Vector(0.0, 1.0, 0.0);
        Vector actual = Vector.YBasis;
        MathAssert.Equal(expected, actual);
    }

    [Fact]
    public void ZBasisTest()
    {
        Vector expected = new Vector(0.0, 0.0, 1.0);
        Vector actual = Vector.ZBasis;
        MathAssert.Equal(expected, actual);
    }

    [Fact]
    public void OperatorVectorTimesInt()
    {
        Vector lhs = new (1.0, 2.0, 3.0);
        int rhs = 2;

        Vector actual = lhs * rhs;
        Vector expected = new (2.0, 4.0, 6.0);

        MathAssert.Equal(expected, actual);
    }

    [Fact]
    public void OperatorIntTimesVector()
    {
        int lhs = 2;
        Vector rhs = new (1.0, 2.0, 3.0);

        Vector actual = lhs * rhs;
        Vector expected = new (2.0, 4.0, 6.0);

        MathAssert.Equal(expected, actual);
    }

    [Fact]
    public void OperatorPlusTest()
    {
        Vector lhs = new (1.0, 2.0, 3.0);
        Vector rhs = new (4.0, 5.0, 6.0);

        Vector actual = lhs + rhs;
        Vector expected = new (5.0, 7.0, 9.0);

        MathAssert.Equal(expected, actual);
    }

    [Fact]
    public void OperatorMinusTest()
    {
        Vector lhs = new (6.0, 5.0, 4.0);
        Vector rhs = new (1.0, 2.0, 3.0);

        Vector actual = lhs - rhs;
        Vector expected = new (5.0, 3.0, 1.0);

        MathAssert.Equal(expected, actual);
    }
}
