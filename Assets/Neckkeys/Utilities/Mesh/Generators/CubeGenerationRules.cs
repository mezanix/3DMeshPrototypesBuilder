using Neckkeys.Utilities.Extensions;
using Neckkeys.Utilities.Math;
using System;
using UnityEngine;

namespace Neckkeys.Utilities.MeshUtililties
{
    [Serializable]
    public class CubeGenerationRules : IMeshGenerationRules
    {
        int[] IMeshGenerationRules.Triangles => new int[]
        {
            0, 1, 2,
            2, 1, 3,

            4, 5, 6,
            6, 5, 7,

            8, 9, 10,
            8, 10, 11,

            12, 13, 14,
            14, 13, 15,

            16, 17, 18,
            19, 17, 16,

            20, 21, 22,
            20, 23, 21
        };

        [SerializeField]
        TransformNoRotation topFaceTransform = new TransformNoRotation(Vector3.zero.With(y:1f));

        [SerializeField]
        Color topFaceColor = Color.cyan;

        [Space]
        [SerializeField]
        TransformNoRotation bottomFaceTransform = new TransformNoRotation(Vector3.zero.With(y: -1f));

        [SerializeField]
        Color bottomFaceColor = Color.cyan.With(g: darkeningTheBottom);

        Vector3[] IMeshGenerationRules.Vertices => new Vector3[]
        {
            cornersPositions[0],
            cornersPositions[4],
            cornersPositions[1],
            cornersPositions[5],

            cornersPositions[1],
            cornersPositions[5],
            cornersPositions[2],
            cornersPositions[6],

            cornersPositions[0],
            cornersPositions[1],
            cornersPositions[2],
            cornersPositions[3],

            cornersPositions[4],
            cornersPositions[7],
            cornersPositions[5],
            cornersPositions[6],

            cornersPositions[3],
            cornersPositions[6],
            cornersPositions[7],
            cornersPositions[2],

            cornersPositions[3],
            cornersPositions[4],
            cornersPositions[0],
            cornersPositions[7],

        };

        //int[][] corners = new int[][]
        //{
        //    new int[] {0, 22, 8},
        //    new int[] {2, 4, 9},
        //    new int[] {6, 10, 19},
        //    new int[] {11, 20, 16},

        //    new int[] {21, 1, 12},
        //    new int[] {3, 5, 14},
        //    new int[] {15, 7, 17},
        //    new int[] {23, 13, 18},
        //};

        [HideInInspector]
        [SerializeField]
        Vector3[] cornersPositions = new Vector3[]
        {
            Vector3.zero - Vector3.one* 0.5f,
            Vector3.right - Vector3.one* 0.5f,
            Vector3.right + Vector3.forward - Vector3.one* 0.5f,
            Vector3.forward - Vector3.one* 0.5f,

            Vector3.zero + Vector3.up - Vector3.one* 0.5f,
            Vector3.right + Vector3.up - Vector3.one* 0.5f,
            Vector3.right + Vector3.forward + Vector3.up - Vector3.one* 0.5f,
            Vector3.forward + Vector3.up - Vector3.one* 0.5f,
        };

        Color[] IMeshGenerationRules.Colors => new Color[]
        {
            cornersColors[0],
            cornersColors[4],
            cornersColors[1],
            cornersColors[5],
                   
            cornersColors[1],
            cornersColors[5],
            cornersColors[2],
            cornersColors[6],
                   
            cornersColors[0],
            cornersColors[1],
            cornersColors[2],
            cornersColors[3],
                   
            cornersColors[4],
            cornersColors[7],
            cornersColors[5],
            cornersColors[6],
                   
            cornersColors[3],
            cornersColors[6],
            cornersColors[7],
            cornersColors[2],
                   
            cornersColors[3],
            cornersColors[4],
            cornersColors[0],
            cornersColors[7],
        };

        const float darkeningTheBottom = 0.75f;

        [HideInInspector]
        [SerializeField]
        Color[] cornersColors = new Color[]
        {
            Color.cyan.With(g: darkeningTheBottom),
            Color.cyan.With(g: darkeningTheBottom),
            Color.cyan.With(g: darkeningTheBottom),
            Color.cyan.With(g: darkeningTheBottom),

            Color.cyan,
            Color.cyan,
            Color.cyan,
            Color.cyan,
        };

        void IMeshGenerationRules.Update()
        {
            cornersPositions[4] =
                topFaceTransform.position.z * Vector3.forward +
                topFaceTransform.position.x * Vector3.right +
                topFaceTransform.position.y * Vector3.up -
                Vector3.forward * topFaceTransform.scale.z -
                Vector3.right * topFaceTransform.scale.x;
            cornersPositions[5] =
                topFaceTransform.position.z * Vector3.forward +
                topFaceTransform.position.x * Vector3.right +
                topFaceTransform.position.y * Vector3.up -
                Vector3.forward * topFaceTransform.scale.z +
                Vector3.right * topFaceTransform.scale.x;
            cornersPositions[6] =
                topFaceTransform.position.z * Vector3.forward +
                topFaceTransform.position.x * Vector3.right +
                topFaceTransform.position.y * Vector3.up +
                Vector3.forward * topFaceTransform.scale.z +
                Vector3.right * topFaceTransform.scale.x;
            cornersPositions[7] =
                topFaceTransform.position.z * Vector3.forward +
                topFaceTransform.position.x * Vector3.right +
                topFaceTransform.position.y * Vector3.up +
                Vector3.forward * topFaceTransform.scale.z -
                Vector3.right * topFaceTransform.scale.x;

            cornersPositions[0] =
                bottomFaceTransform.position.z * Vector3.forward +
                bottomFaceTransform.position.x * Vector3.right +
                bottomFaceTransform.position.y * Vector3.up -
                Vector3.forward * bottomFaceTransform.scale.z -
                Vector3.right * bottomFaceTransform.scale.x;
            cornersPositions[1] =
                bottomFaceTransform.position.z * Vector3.forward +
                bottomFaceTransform.position.x * Vector3.right +
                bottomFaceTransform.position.y * Vector3.up -
                Vector3.forward * bottomFaceTransform.scale.z +
                Vector3.right * bottomFaceTransform.scale.x;
            cornersPositions[2] =
                bottomFaceTransform.position.z * Vector3.forward +
                bottomFaceTransform.position.x * Vector3.right +
                bottomFaceTransform.position.y * Vector3.up +
                Vector3.forward * bottomFaceTransform.scale.z +
                Vector3.right * bottomFaceTransform.scale.x;
            cornersPositions[3] =
                bottomFaceTransform.position.z * Vector3.forward +
                bottomFaceTransform.position.x * Vector3.right +
                bottomFaceTransform.position.y * Vector3.up +
                Vector3.forward * bottomFaceTransform.scale.z -
                Vector3.right * bottomFaceTransform.scale.x;

            int middleCornerColors = 4;
            for (int i = 0; i < middleCornerColors; i++)
            {
                cornersColors[i] = bottomFaceColor;
            }
            for (int i = middleCornerColors; i < cornersColors.Length; i++)
            {
                cornersColors[i] = topFaceColor;
            }
        }
    }
}