using UnityEngine;

namespace Neckkeys.Utilities.Extensions
{
    public static class MeshExtensions
    {
        public static void RecalculateAll(this Mesh t)
        {
            t.RecalculateBounds();
            t.RecalculateNormals();
            t.RecalculateTangents();
        }
    }
}