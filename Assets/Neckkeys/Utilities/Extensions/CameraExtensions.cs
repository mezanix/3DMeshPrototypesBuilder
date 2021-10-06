using UnityEngine;

namespace Neckkeys.Utilities.Extensions
{
    public static class CameraExtensions
    {
        public static Vector3 WorldBottomLeft(this Camera t, float z, Camera.MonoOrStereoscopicEye monoOrStereoscopicEye)
        {
            return t.ViewportToWorldPoint(Vector3.zero.With(z: z), monoOrStereoscopicEye);
        }
        public static Vector3 WorldTopLeft(this Camera t, float z, Camera.MonoOrStereoscopicEye monoOrStereoscopicEye)
        {
            return t.ViewportToWorldPoint(Vector3.one.With(z: z), monoOrStereoscopicEye);
        }
        public static float WorldWidth(this Camera t, float z, Camera.MonoOrStereoscopicEye monoOrStereoscopicEye)
        {
            return t.WorldDiagonal(z, monoOrStereoscopicEye).x;
        }
        public static Vector3 WorldDiagonal(this Camera t, float z, Camera.MonoOrStereoscopicEye monoOrStereoscopicEye)
        {
            return t.WorldTopLeft(z, monoOrStereoscopicEye) - t.WorldBottomLeft(z, monoOrStereoscopicEye);
        }

    }
}