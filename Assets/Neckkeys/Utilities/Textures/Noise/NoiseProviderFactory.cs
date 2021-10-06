using UnityEngine;

namespace Neckkeys.Utilities.Textures.Noise
{
    public enum NoiseType
    {
        Perlin,
        SimplexSeamless,

        Voronoi
    }

    public class NoiseProviderFactory
    {
        NoiseType noiseType = NoiseType.Perlin;
        float dx = 1f;
        float dy = 1f;
        Vector2 offset = Vector2.zero;

        int width = 1024;
        int height = 1024;
        int n = 12;

        public NoiseProviderFactory(NoiseType noiseType, 
            float dx = 1f, float dy = 1f, float offsetX = 0f, float offsetY = 0f,
            int width= 1024, int height = 1024, int n = 12)
        {
            this.noiseType = noiseType;

            this.dx = dx;
            this.dy = dy;
            offset = new Vector2(offsetX, offsetY);

            this.width = width;
            this.height = height;
            this.n = n;
        }

        public NoiseProvider Provider()
        {
            switch (noiseType)
            {
                case NoiseType.Perlin:
                    return new NoiseProvider();

                case NoiseType.SimplexSeamless:
                    return new NoiseProviderSimplexSeamless(dx, dy, offset);

                case NoiseType.Voronoi:
                    return new NoiseProviderVoronoi(width, height, n);
            }
            return new NoiseProvider();
        }
    }
}