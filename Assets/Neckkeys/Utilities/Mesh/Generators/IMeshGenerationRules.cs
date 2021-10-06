using UnityEngine;

namespace Neckkeys.Utilities.MeshUtililties
{
    public interface IMeshGenerationRules
    {
        int[] Triangles { get; }
        Vector3[] Vertices { get; }
        Color[] Colors { get; }

        void Update();
    }
}