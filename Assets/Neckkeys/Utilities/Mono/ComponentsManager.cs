using UnityEngine;

namespace Neckkeys.Utilities.Mono
{
    public class ComponentsManager
    {
        GameObject gameObject = null;

        public ComponentsManager(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        MeshFilter meshFilter = null;
        public MeshFilter MeshFilter
        {
            get
            {
                if (meshFilter == null)
                    meshFilter = gameObject.GetComponent<MeshFilter>();
                if (meshFilter == null)
                    meshFilter = gameObject.AddComponent<MeshFilter>();
                return meshFilter;
            }
        }

        MeshRenderer meshRenderer = null;
        public MeshRenderer MeshRenderer
        {
            get
            {
                if (meshRenderer == null)
                    meshRenderer = gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer == null)
                    meshRenderer = gameObject.AddComponent<MeshRenderer>();
                return meshRenderer;
            }
        }

    }
}