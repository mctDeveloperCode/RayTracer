namespace RayTracer;

internal sealed class Camera
{
    public Camera(Ray pointOfView, Vector frameUp, double width, double height, int rows, int columns)
    {
        this.pointOfView = pointOfView;

        this.rows = rows;
        this.columns = columns;

        Vector frameCenter = pointOfView.Nearest(frameUp);
        Vector frameYBasis = (frameUp - frameCenter).Unit();
        Vector frameXBasis = pointOfView.Direction.Cross(frameYBasis);

        double pixelWidth = width / columns;
        double pixelHeight = height / rows;

        yStep = -frameYBasis * pixelHeight;
        xStep = frameXBasis * pixelWidth;

        upperLeft =
            // Start in the center of the frame
            frameCenter
            // Move to the upper left corner of the frame
            + frameYBasis * (height * 0.5) - frameXBasis * (width * 0.5)
            // Move to the center of the upper left pixel.
            + xStep * 0.5 + yStep * 0.5;
    }

    public IEnumerable<Ray> Rays()
    {
        foreach (Vector pixelCenter in PixelCenters())
            yield return new Ray(pointOfView.Position, (pixelCenter - pointOfView.Position));
    }

    private IEnumerable<Vector> PixelCenters()
    {
        for (int y = 0; y < rows; y++)
            for (int x = 0; x < columns; x++)
                yield return xStep * x + yStep * y + upperLeft;
    }

    // Perspective of the camera
    private Ray pointOfView;

    // Number of pixels
    private int rows;
    private int columns;

    // Move by exactly one pixel
    private Vector xStep;
    private Vector yStep;

    // The center of the upper left pixel in the frame
    private Vector upperLeft;
}
