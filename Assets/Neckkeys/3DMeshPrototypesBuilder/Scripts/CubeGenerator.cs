using Neckkeys.Utilities.MeshUtililties;
using Neckkeys.Utilities.StringServices;
using UnityEngine;

namespace Neckkeys.MeshPrototypesBuilder
{
    public class CubeGenerator : MeshGeneratorMono
    {
        [SerializeField]
        [Tooltip(StringConsts.General.Mesh + " " + StringConsts.General.generation + " " + StringConsts.General.rules)]
        CubeGenerationRules rules = null;

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