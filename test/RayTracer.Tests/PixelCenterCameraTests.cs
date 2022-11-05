using Xunit;
using System.Collections.Generic;

namespace RayTracer.Tests;

public sealed class PixelCenterCameraTests
{
    [Theory]
    [MemberData(nameof(SquarePixelTestData))]
    internal void SquarePixelTest(int rows, int columns, IEnumerable<Ray> expected)
    {
        Camera camera = new (
            pointOfView: new Ray(focus, -Vector.ZBasis),
            frameUp: Vector.YBasis,
            width: 0.2,
            height: 0.2,
            rows: rows,
            columns: columns);

        IEnumerable<Ray> actual = camera.Rays();

        MathAssert.Equal(expected, actual);
    }

    private static IEnumerable<object[]> SquarePixelTestData() =>
        new object[][]
        {
            expectedSquare1By1,
            expectedSquare1By2,
            expectedSquare2By1,
            expectedSquare2By2,
        };

    private static Vector focus = new (0.0, 0.0, 1.0);

    private static object[] expectedSquare1By1 =
    {
        1, 1,      // rows, columns
        new Ray[]  // expected
        {
            new Ray(focus, -Vector.ZBasis)
        }
    };

    private static object[] expectedSquare1By2 =
    {
        1, 2,      // rows, columns
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(-0.05, 0.0, -1.0)),
            new Ray(focus, new Vector( 0.05, 0.0, -1.0))
        }
    };

    private static object[] expectedSquare2By1 =
    {
        2, 1,      // rows, columns
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(0.0,  0.05, -1.0)),
            new Ray(focus, new Vector(0.0, -0.05, -1.0))
        }
    };

    private static object[] expectedSquare2By2 =
    {
        2, 2,      // rows, columns
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(-0.05,  0.05, -1.0)),
            new Ray(focus, new Vector( 0.05,  0.05, -1.0)),
            new Ray(focus, new Vector(-0.05, -0.05, -1.0)),
            new Ray(focus, new Vector( 0.05, -0.05, -1.0))
        }
    };
}
