using Neckkeys.Utilities.StringServices;
using Neckkeys.Utilities.MeshUtililties;
using UnityEngine;

namespace Neckkeys.MeshPrototypesBuilder
{
    public class TriangleGenerator : MeshGeneratorMono
    {
        [SerializeField]
        [Tooltip(StringConsts.General.Mesh + " " + StringConsts.General.generation + " " + StringConsts.General.rules)]
        TriangleGenerationRules rules = null;

        protected override MeshGenerator MeshGenerator
        {
            get
            {
                if (meshGenerator == null)
                    meshGenerator = new MeshGenerator(rules);
                return meshGenerator;
            }
        }
    }
}