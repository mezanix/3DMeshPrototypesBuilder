using UnityEngine;


namespace Neckkeys.Utilities.Extensions
{
    public static class TransformExtensions
    {
        public static Transform Reset(this Transform t)
        {
            t.ResetLocation();
            t.ResetRotation();
            t.ResetLocalScale();
            return t;
        }
        public static Transform ResetLocation(this Transform t)
        {
            t.position = Vector3.zero;
            return t;
        }
        public static Transform ResetRotation(this Transform t)
        {
            t.rotation = Quaternion.identity;
            return t;
        }
        public static Transform ResetLocalScale(this Transform t)
        {
            t.localScale = Vector3.one;
            return t;
        }
    }
}