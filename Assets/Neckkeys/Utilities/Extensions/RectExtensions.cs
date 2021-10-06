using UnityEngine;

namespace Neckkeys.Utilities.Extensions
{
    public static class RectExtensions
    {
        /// <summary>
        /// Get rect by normalized dimensions:
        /// if x = 0, y = 0, width = 1 and height = 1, it returns the same Rect. 
        /// ignorOrigine: means ignore the origine of the container Rect.
        /// </summary>
        public static Rect GetRectInside(this Rect t, float x, float y, float width, float height,
            bool ignoreOrigin = true)
        {
            float xOut = (ignoreOrigin ? 0f : t.x) + x * t.width;
            float yOut = (ignoreOrigin ? 0f : t.y) + y * t.height;
            float wOut = width * t.width;
            float hOut = height * t.height;

            return new Rect(xOut, yOut, wOut, hOut);
        }

        public static Rect[] Divide(this Rect t, bool horizontal, params float[] ratios)
        {
            Rect[] r = new Rect[ratios.Length];

            float xRatioCumul = 0f;

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = t.GetRectInside(
                    horizontal ? xRatioCumul : 0f,
                    horizontal ? 0f : xRatioCumul,
                    horizontal ? ratios[i] : 1f,
                    horizontal ? 1f : ratios[i],
                    false);

                xRatioCumul += ratios[i];
            }

            return r;
        }

        /// <summary>
        /// Get rect by normalized dimensions:
        /// if x = 0, y = 0, it returns the origine of the container Rect.
        /// ignorOrigine: means ignore the origine of the container Rect.
        /// </summary> 
        public static Vector2 GetPointInsideRect(this Rect t, float x, float y, bool ignoreOrigine = true)
        {
            float xOut = (ignoreOrigine ? 0f : t.x) + x * t.width;
            float yOut = (ignoreOrigine ? 0f : t.y) + y * t.height;

            return new Vector2(xOut, yOut);
        }

        public static Rect With(this Rect t,
            float? x = null,
            float? y = null,
            float? width = null,
            float? height = null)
        {
            return new Rect(
                x ?? t.x,
                y ?? t.y,
                width ?? t.width,
                height ?? t.height);
        }

        public static Rect Left(this Rect t)
        {
            return new Rect(t.x - t.height, t.y, t.height, t.height);
        }
        public static Rect LeftInside(this Rect t)
        {
            return new Rect(t.x, t.y, t.height, t.height);
        }
        public static Rect LeftInside(this Rect t, float w)
        {
            return new Rect(t.x, t.y, w, t.height);
        }

        public static Rect Right(this Rect t)
        {
            return new Rect(t.x + t.width, t.y, t.height, t.height);
        }
        public static Rect RightInside(this Rect t)
        {
            return new Rect(t.x + t.width - t.height, t.y, t.height, t.height);
        }
        public static Rect RightInside(this Rect t, float w)
        {
            return new Rect(t.x + t.width - w, t.y, w, t.height);
        }

        public static Rect At_X_Inside(this Rect t, float x)
        {
            return new Rect(t.x + x, t.y, t.height, t.height);
        }

        public static Rect SymetricToTheRight(this Rect t)
        {
            return new Rect(t.x + t.width, t.y, t.width, t.height);
        }
        public static Rect SymetricToTheRight(this Rect t, float w)
        {
            return new Rect(t.x + t.width, t.y, w, t.height);
        }

    }
}