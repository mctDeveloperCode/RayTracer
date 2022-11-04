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

    // Dot product
    public static double operator *(Vector lhs, Vector rhs) =>
        lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;

    public static Vector operator *(Vector vector, int scale) =>
        new Vector(vector.X * scale, vector.Y * scale, vector.Z * scale);

    public static Vector operator *(int scale, Vector vector) =>
        new Vector(vector.X * scale, vector.Y * scale, vector.Z * scale);

    public static Vector operator *(Vector vector, double scale) =>
        new Vector(vector.X * scale, vector.Y * scale, vector.Z * scale);

    public static Vector operator *(double scale, Vector vector) =>
        new Vector(vector.X * scale, vector.Y * scale, vector.Z * scale);

    public static Vector operator +(Vector lhs, Vector rhs) =>
     new Vector(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);

    public static Vector operator -(Vector lhs, Vector rhs) =>
     new Vector(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);

    public static Vector Origin { get; } = new Vector(0.0, 0.0, 0.0);
    public static Vector XBasis { get; } = new Vector(1.0, 0.0, 0.0);
    public static Vector YBasis { get; } = new Vector(0.0, 1.0, 0.0);
    public static Vector ZBasis { get; } = new Vector(0.0, 0.0, 1.0);

    public override string ToString() =>
        $"Vector({X}, {Y}, {Z})";
}
