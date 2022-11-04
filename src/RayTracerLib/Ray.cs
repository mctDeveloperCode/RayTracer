namespace RayTracer;

internal struct Ray
{
    public Vector Position { get; }
    public Vector Direction { get; }

    public Ray(Vector location, Vector direction) =>
        (Position, Direction) = (location, direction.Unit());

    public Vector Nearest(Vector point) =>
        (Direction * (point - Position)) * Direction + Position;

    public static Ray XAxis { get; } = new Ray(Vector.Origin, Vector.XBasis);
    public static Ray YAxis { get; } = new Ray(Vector.Origin, Vector.YBasis);
    public static Ray ZAxis { get; } = new Ray(Vector.Origin, Vector.ZBasis);

    public override string ToString() =>
        $"Ray(({Position.X}, {Position.Y}, {Position.Z}), ({Direction.X}, {Direction.Y}, {Direction.Z}))";
}
