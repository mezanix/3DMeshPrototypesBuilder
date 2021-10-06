using UnityEngine;

namespace Neckkeys.Utilities.MeshUtililties
{
    public class MeshDebuger
    {
        Mesh mesh = null;
        Transform transform = null;
        float normalLength = 1f;
        Color normalColor = Color.cyan;

        public MeshDebuger(Mesh mesh, Transform transform, float normalLength, Color normalColor)
        {
            this.mesh = mesh;
            this.transform = transform;

            this.normalLength = normalLength;
            this.normalColor = normalColor;
        }

        public void Run()
        {
            DrawNormals();
        }

        private void DrawNormals()
        {
            for (int i = 0; i < mesh.normals.Length; i++)
            {
                Debug.DrawLine(
                    transform.TransformPoint(mesh.vertices[i]),
                    transform.TransformPoint(mesh.vertices[i]) + 
                    transform.TransformDirection(mesh.normals[i]) * normalLength, normalColor);
            }
        }
    }
}