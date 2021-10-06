using Neckkeys.Utilities.MeshUtililties;
using Neckkeys.Utilities.Mono;
using Neckkeys.Utilities.ResourcesNamespace;
using UnityEngine;


namespace Neckkeys.MeshPrototypesBuilder
{
    public abstract class MeshGeneratorMono : MonoBehaviour
    {
        protected MeshGenerator meshGenerator = null;
        protected abstract MeshGenerator MeshGenerator { get; }

        ComponentsManager cm = null;
        public ComponentsManager Cm
        {
            get
            {
                if (cm == null)
                    cm = new ComponentsManager(gameObject);
                return cm;
            }
        }

        Material material = null;
        public Material Material
        {
            get
            {
                if (material == null)
                    material = ResourcesLib.Utilities.Materials.ParticlesStandardUnlitOpaqueColor;
                return material;
            }
            set
            {
                material = value;
            }
        }

        public void GenerateMesh()
        {
            Cm.MeshFilter.mesh = MeshGenerator.Generate();

            Cm.MeshRenderer.material = Material;
        }

        public void AddMissingParentComponent()
        {
            if (IsParentComponentExists() == true)
                return;

            transform.parent.gameObject.AddComponent<MeshBuilder>();
        }

        bool IsParentComponentExists()
        {
            return transform.parent.GetComponent<MeshBuilder>() != null;
        }

        private void DebugMesh()
        {
            MeshDebuger debuger = new MeshDebuger(Cm.MeshFilter.sharedMesh, transform, 1f, Color.cyan);
            debuger.Run();
        }
    }
}