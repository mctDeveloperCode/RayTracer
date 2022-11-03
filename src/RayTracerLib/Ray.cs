namespace RayTracer;

internal struct Ray
{
    public Vector Position { get; }
    public Vector Direction { get; }

    public Ray(Vector location, Vector direction) =>
        (Position, Direction) = (location, direction.Unit());
}
