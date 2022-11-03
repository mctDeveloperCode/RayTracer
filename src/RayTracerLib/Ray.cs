namespace RayTracer;

internal struct Ray
{
    public Vector Position { get; }
    public Vector Direction { get; }

    public Ray(Vector location, Vector direction) =>
        (Position, Direction) = (location, direction.Unit());

    public static Ray XAxis { get; } = new Ray(Vector.Origin, Vector.XBasis);
    public static Ray YAxis { get; } = new Ray(Vector.Origin, Vector.YBasis);
    public static Ray ZAxis { get; } = new Ray(Vector.Origin, Vector.ZBasis);
}
