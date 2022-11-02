namespace RayTracer;

public sealed class RayTracer
{
    public Bitmap Render()
    {
        return GetEmptyScene(1024, 1024);
    }

    private Bitmap GetEmptyScene(int columns, int rows)
    {
        Bitmap bitmap = new (rows, columns);

        for (int x = 0; x < columns; x++)
            for (int y = 0; y < rows; y++)
                bitmap.SetPixel(x, y, Color.Black);

        return bitmap;
    }
}
