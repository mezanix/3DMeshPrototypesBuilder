using UnityEngine;

namespace Neckkeys.Utilities.Extensions
{
    public static class TextureExtensions
    {
        public static void SetPixelsAndApply(this Texture2D t, Color[] colors)
        {
            t.SetPixels(colors);
            t.Apply();
        }

        public static Vector2Int UvToPixelCoord(this Texture2D t, Vector2 Uv)
        {
            return new Vector2Int(
                (int)(Uv.x * t.width),
                (int)(Uv.y * t.height));
        }
    }
}