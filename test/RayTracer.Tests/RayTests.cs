using System.Collections.Generic;
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

    internal static IEnumerable<object[]> NearestShouldFindPointOnRayNearestToGivenPointData() =>
        new object[][]
        {
            new object [] { new Ray(Vector.Origin, Vector.XBasis), new Vector(3.0, 4.0, 5.0), new Vector(3.0, 0.0, 0.0) },
            new object [] { new Ray(Vector.Origin, Vector.YBasis), new Vector(3.0, 4.0, 5.0), new Vector(0.0, 4.0, 0.0) },
            new object [] { new Ray(Vector.Origin, Vector.ZBasis), new Vector(3.0, 4.0, 5.0), new Vector(0.0, 0.0, 5.0) },
            new object [] { new Ray(Vector.Origin, new Vector(2.0, 3.0, 6.0)), new Vector(147.0, 196.0, 245.0), new Vector(96.0, 144.0, 288.0) },
            new object [] { new Ray(new Vector(10.0, 12.0, 14.0), Vector.XBasis), new Vector(3.0, 4.0, 5.0), new Vector(3.0, 12.0, 14.0) },
            new object [] { new Ray(new Vector(10.0, 12.0, 14.0), Vector.YBasis), new Vector(3.0, 4.0, 5.0), new Vector(10.0, 4.0, 14.0) },
            new object [] { new Ray(new Vector(10.0, 12.0, 14.0), Vector.ZBasis), new Vector(3.0, 4.0, 5.0), new Vector(10.0, 12.0, 5.0) },
            new object [] { new Ray(new Vector(10.0, 12.0, 14.0), new Vector(2.0, 3.0, 6.0)), new Vector(157.0, 208.0, 259.0), new Vector(106.0, 156.0, 302.0) },
        };

    [Theory]
    [MemberData(nameof(NearestShouldFindPointOnRayNearestToGivenPointData))]
    internal void NearestShouldFindPointOnRayNearestToGivenPoint(Ray ray, Vector point, Vector expected)
    {
        Vector actual = ray.Nearest(point);
        MathAssert.Equal(expected, actual);
    }
}
