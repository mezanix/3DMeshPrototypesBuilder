using System.Collections.Generic;
using UnityEngine;

namespace Neckkeys.Utilities.Extensions
{
    public static class ColorExtensions
    {
        public static Color MultiplyButAlpha(this Color t, float m)
        {
            return (t * m).With(a: t.a);
        }

        public static Color With(this Color t,
            float? r = null,
            float? g = null,
            float? b = null,
            float? a = null)
        {
            return new Color(
                r ?? t.r,
                g ?? t.g,
                b ?? t.b,
                a ?? t.a);
        }

        public static List<Color> ListOf(this Color t, int count)
        {
            List<Color> r = new List<Color>();

            for (int i = 0; i < count; i++)
            {
                r.Add(t);
            }

            return r;
        }
    }
}