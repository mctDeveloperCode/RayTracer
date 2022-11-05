using Xunit;
using System.Collections.Generic;

namespace RayTracer.Tests;

public sealed class PixelCenterCameraTests
{
    [Theory]
    [MemberData(nameof(PixelTestData))]
    internal void PixelTest(int rows, int columns, double height, double width, IEnumerable<Ray> expected)
    {
        Camera camera = new (
            pointOfView: new Ray(focus, -Vector.ZBasis),
            frameUp: Vector.YBasis,
            height: height,
            width: width,
            rows: rows,
            columns: columns);

        IEnumerable<Ray> actual = camera.Rays();

        MathAssert.Equal(expected, actual);
    }

    private static IEnumerable<object[]> PixelTestData() =>
        new object[][]
        {
            square1By1Data,
            square1By2Data,
            square2By1Data,
            square2By2Data,
            tall1By1Data,
            tall1By2Data,
            tall2By1Data,
            tall2By2Data,
        };

    private static Vector focus = new (0.0, 0.0, 1.0);

    private static object[] square1By1Data =
    {
        1, 1,      // rows, columns
        0.2, 0.2,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, -Vector.ZBasis)
        }
    };

    private static object[] square1By2Data =
    {
        1, 2,      // rows, columns
        0.2, 0.2,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(-0.05, 0.0, -1.0)),
            new Ray(focus, new Vector( 0.05, 0.0, -1.0))
        }
    };

    private static object[] square2By1Data =
    {
        2, 1,      // rows, columns
        0.2, 0.2,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(0.0,  0.05, -1.0)),
            new Ray(focus, new Vector(0.0, -0.05, -1.0))
        }
    };

    private static object[] square2By2Data =
    {
        2, 2,      // rows, columns
        0.2, 0.2,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(-0.05,  0.05, -1.0)),
            new Ray(focus, new Vector( 0.05,  0.05, -1.0)),
            new Ray(focus, new Vector(-0.05, -0.05, -1.0)),
            new Ray(focus, new Vector( 0.05, -0.05, -1.0))
        }
    };

    private static object[] tall1By1Data =
    {
        1, 1,      // rows, columns
        0.4, 0.2,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, -Vector.ZBasis)
        }
    };

    private static object[] tall1By2Data =
    {
        1, 2,      // rows, columns
        0.4, 0.2,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(-0.05, 0.0, -1.0)),
            new Ray(focus, new Vector( 0.05, 0.0, -1.0))
        }
    };

    private static object[] tall2By1Data =
    {
        2, 1,      // rows, columns
        0.4, 0.2,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(0.0,  0.1, -1.0)),
            new Ray(focus, new Vector(0.0, -0.1, -1.0))
        }
    };

    private static object[] tall2By2Data =
    {
        2, 2,      // rows, columns
        0.4, 0.2,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(-0.05,  0.1, -1.0)),
            new Ray(focus, new Vector( 0.05,  0.1, -1.0)),
            new Ray(focus, new Vector(-0.05, -0.1, -1.0)),
            new Ray(focus, new Vector( 0.05, -0.1, -1.0))
        }
    };

    private static object[] wide1By1Data =
    {
        1, 1,      // rows, columns
        0.2, 0.4,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, -Vector.ZBasis)
        }
    };

    private static object[] wide1By2Data =
    {
        1, 2,      // rows, columns
        0.2, 0.4,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(-0.1, 0.0, -1.0)),
            new Ray(focus, new Vector( 0.1, 0.0, -1.0))
        }
    };

    private static object[] wide2By1Data =
    {
        2, 1,      // rows, columns
        0.2, 0.4,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(0.0,  0.05, -1.0)),
            new Ray(focus, new Vector(0.0, -0.05, -1.0))
        }
    };

    private static object[] wide2By2Data =
    {
        2, 2,      // rows, columns
        0.2, 0.4,  // height, width
        new Ray[]  // expected
        {
            new Ray(focus, new Vector(-0.1,  0.05, -1.0)),
            new Ray(focus, new Vector( 0.1,  0.05, -1.0)),
            new Ray(focus, new Vector(-0.1, -0.05, -1.0)),
            new Ray(focus, new Vector( 0.1, -0.05, -1.0))
        }
    };
}
