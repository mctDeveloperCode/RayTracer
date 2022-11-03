namespace RayTracer;

internal sealed class Camera
{
    public Camera(Ray axis) =>
        Axis = axis;

    public IEnumerable<Ray> Rays()
    {
        yield return Axis;
    }

    // Centerline of the camera
    private Ray Axis { get; }
}
