using Neckkeys.Utilities.Extensions;
using Neckkeys.Utilities.StringServices;
using System;
using UnityEngine;

namespace Neckkeys.Utilities.MeshUtililties
{
    [Serializable]
    public class TriangleGenerationRules : IMeshGenerationRules
    {
        int[] IMeshGenerationRules.Triangles => new int[] { 0, 1, 2 };

        [Header(StringConsts.General.Vertices)]
        [SerializeField] 
        Vector3 vertex0 = Vector3.zero;
        [SerializeField]
        Vector3 vertex1 = Vector3.zero.With(y: 1f);
        [SerializeField]
        Vector3 vertex2 = Vector3.zero.With(x: 1f);

        Vector3[] IMeshGenerationRules.Vertices => new Vector3[]
        {
            vertex0,
            vertex1,
            vertex2
        };

        [Header(StringConsts.General.Colors)]
        [SerializeField]
        Color color0 = Color.cyan;
        [SerializeField]
        Color color1 = Color.cyan;
        [SerializeField]
        Color color2 = Color.cyan;

        Color[] IMeshGenerationRules.Colors => new Color[]
        {
            color0,
            color1,
            color2
        };

        void IMeshGenerationRules.Update()
        {

        }
    }
}