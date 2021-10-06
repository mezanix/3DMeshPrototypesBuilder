using Neckkeys.Utilities.StringServices;
using UnityEngine;

namespace Neckkeys.Utilities.ResourcesNamespace
{
    public static class ResourcesLib
    {
        public static class Utilities
        {
            public static class Materials
            {
                public static Material ParticlesStandardUnlitOpaqueColor =>
                    new Material(
                    Resources.Load<Material>(
                        StringConsts.Resources.Utilities.Materials.ParticlesStandardUnlitOpaqueColor));

                public static Material UnlitTexture =>
                    new Material(
                    Resources.Load<Material>(
                        StringConsts.Resources.Utilities.Materials.UnlitTexture));

                public static Material Default =>
                    new Material(
                    Resources.Load<Material>(
                        StringConsts.Resources.Utilities.Materials.Default));
            }
        }
    }
}