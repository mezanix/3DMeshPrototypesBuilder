using UnityEngine;

namespace Neckkeys.Utilities.Textures.Noise
{
    public class NoiseProviderSimplexSeamless : NoiseProvider
    {
        float dx = 1f;
        float dy = 1f;
        Vector2 offset = Vector2.zero;

        public NoiseProviderSimplexSeamless(float dx, float dy, Vector2 offset) : base()
        {
            this.dx = dx;
            this.dy = dy;
            this.offset = offset;
        }

        public override float ProvideNoise(float x, float y)
        {
            return (SimplexNoise.SeamlessNoise(x, y, dx, dy, offset) + 1f) * 0.5f;
        }
    }
}