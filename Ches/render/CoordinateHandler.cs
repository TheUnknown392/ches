using System.Numerics;
namespace render
{
    public static class CoordinateHandler
    {
        // for standard displays, xy are swapped  forsome reason
        public static Vector2 standardToRenderPosition(Vector2 pos)
        {
            return new Vector2(
                (pos.X - 4.5f) / 2f,
                (4.5f - pos.Y) / 2f
            );
        }

        public static Vector2 standardToRenderPosition(float x, float z)
        {
            return standardToRenderPosition(new Vector2(x, z));
        }

        public static Vector2 renderToStandardPosition(Vector2 pos)
        {
            return new Vector2(
                pos.X * 2f + 4.5f,
                4.5f - pos.Y * 2f
            );
        }

        public static Vector2 renderToStandardPosition(float x, float z)
        {
            return renderToStandardPosition(new Vector2(x, z));
        }

        

    }
}
