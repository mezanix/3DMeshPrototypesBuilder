using UnityEngine;

namespace Neckkeys.Utilities.Textures.Noise
{
    public class NoiseProviderVoronoi : NoiseProvider
    {
        int width = 1024;
        int height = 1024;
        int n = 12;

        public NoiseProviderVoronoi(int width, int height, int n)
        {
            this.width = width;
            this.height = height;
            this.n = n;
        }

        public override Color[] ProvidePixels()
        {
            return Voronoi.Pixels(width, height, n);
        }

        public override float[] ProvideHeightmap()
        {
            return Voronoi.Heightmap(width, height, n);
        }

        public override bool IsGlobal()
        {
            return true;
        }
    }
}