using System.Collections.Generic;
using UnityEngine;

namespace Neckkeys.Utilities.Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 With(this Vector3 t,
            float? x = null,
            float? y = null,
            float? z = null)
        {
            return new Vector3(
                x ?? t.x,
                y ?? t.y,
                z ?? t.z);
        }
        public static Vector2 With(this Vector2 t,
            float? x = null,
            float? y = null
            )
        {
            return new Vector2(
                x ?? t.x,
                y ?? t.y);
        }
    
        public static Vector3 NormalFrom3Points(this Vector3[] t)
        {
            Vector3 _01 = t[1] - t[0];
            Vector3 _02 = t[2] - t[0];

            Vector3 cross = Vector3.Cross(_01, _02);

            return cross.normalized;
        }
        public static List<Vector3> ListOf(this Vector3 t, int count)
        {
            List<Vector3> r = new List<Vector3>();

            for (int i = 0; i < count; i++)
            {
                r.Add(t);
            }

            return r;
        }
    }
}