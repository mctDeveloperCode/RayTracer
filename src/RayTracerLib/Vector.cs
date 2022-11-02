namespace RayTracer;

internal struct Vector
{
    public Vector(double x, double y, double z) =>
        (X, Y, Z) = (x, y, z);

    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public double Length2 =>
        X * X + Y * Y + Z * Z;

    public double Length =>
        Math.Sqrt(Length2);

    public Vector Unit() =>
        new Vector(X / Length, Y / Length, Z / Length);

    public static Vector Origin { get; } = new Vector(0.0, 0.0, 0.0);
    public static Vector XBasis { get; } = new Vector(1.0, 0.0, 0.0);
    public static Vector YBasis { get; } = new Vector(0.0, 1.0, 0.0);
    public static Vector ZBasis { get; } = new Vector(0.0, 0.0, 1.0);
}
