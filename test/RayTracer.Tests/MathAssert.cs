using System;
using System.Collections.Generic;
using Xunit;

namespace RayTracer.Tests;

internal static class MathAssert
{
    public static void Equal(double expected, double actual) =>
        Assert.Equal(expected, actual, precision);

    public static void Equal(Vector expected, Vector actual) =>
        Assert.Equal(expected, actual, vectorEqualityComparer);

    public static void Equal(Ray expected, Ray actual) =>
        Assert.Equal(expected, actual, rayEqualityComparer);

    private static readonly VectorEqualityComparer vectorEqualityComparer = new ();
    private static readonly RayEqualityComparer rayEqualityComparer = new ();

    private const int precision = 14;

    private sealed class VectorEqualityComparer : IEqualityComparer<Vector>
    {
        public bool Equals(Vector lhs, Vector rhs) =>
            Vector.Equals(
                new Vector(
                    Math.Round(lhs.X, precision),
                    Math.Round(lhs.Y, precision),
                    Math.Round(lhs.Z, precision)),
                new Vector(
                    Math.Round(rhs.X, precision),
                    Math.Round(rhs.Y, precision),
                    Math.Round(rhs.Z, precision)));

        public int GetHashCode(Vector _) =>
            throw new NotImplementedException();
    }

    private sealed class RayEqualityComparer : IEqualityComparer<Ray>
    {
        public bool Equals(Ray lhs, Ray rhs) =>
            vectorEqualityComparer.Equals(lhs.Position, rhs.Position) &&
            vectorEqualityComparer.Equals(lhs.Direction, rhs.Direction);

        public int GetHashCode(Ray _) =>
            throw new NotImplementedException();
    }
}
