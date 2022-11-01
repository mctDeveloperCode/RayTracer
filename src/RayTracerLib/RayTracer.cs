
namespace RayTracer;
public sealed class RayTracer
{
    public Bitmap Render()
    {
        return GetEmptyScene(1024, 1024);
    }

    private Bitmap GetEmptyScene(int width, int height)
    {
        Bitmap bitmap = new (width, height);

        for (int x = 0; x < width; x++)
            for (int y = 0; y < width; y++)
                bitmap.SetPixel(x, y, Color.Black);

        return bitmap;
    }
}
