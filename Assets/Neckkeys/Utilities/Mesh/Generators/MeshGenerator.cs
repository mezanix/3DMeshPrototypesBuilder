using Neckkeys.Utilities.Extensions;
using UnityEngine;

namespace Neckkeys.Utilities.MeshUtililties
{
    public class MeshGenerator
    {
        IMeshGenerationRules rules = null;

        public MeshGenerator(IMeshGenerationRules rules)
        {
            this.rules = rules;
        }

        //private Vector3[] ComputeNormals()
        //{
        //    Vector3[] r = new Vector3[rules.Vertices.Length];

        //    for (int i = 0; i < r.Length; i+=3)
        //    {
        //        int i_1 = i + 1;
        //        int i_2 = i + 2;

        //        Vector3 normal = new Vector3[]
        //        {
        //            rules.Vertices[i],
        //            rules.Vertices[i_1],
        //            rules.Vertices[i_2]
        //        }.NormalFrom3Points();

        //        r[i] = normal;
        //        r[i_1] = normal;
        //        r[i_2] = normal;
        //    }

        //    return r;
        //}

        private Vector3[] ComputeNormals()
        {
            Vector3[] r = new Vector3[rules.Vertices.Length];

            for (int i = 0; i < rules.Triangles.Length; i += 3)
            {
                int i_1 = i + 1;
                int i_2 = i + 2;

                Vector3 normal = new Vector3[]
                {
                    rules.Vertices[rules.Triangles[i]],
                    rules.Vertices[rules.Triangles[i_1]],
                    rules.Vertices[rules.Triangles[i_2]]
                }.NormalFrom3Points();

                r[rules.Triangles[i]] = normal;
                r[rules.Triangles[i_1]] = normal;
                r[rules.Triangles[i_2]] = normal;
            }

            return r;
        }

        public Mesh Generate()
        {
            Mesh r = new Mesh();

            rules.Update();

            r.vertices = rules.Vertices;

            r.triangles = rules.Triangles;

            r.normals = ComputeNormals();

            r.colors = rules.Colors;

            r.RecalculateAll();
            return r;
        }
    }
}