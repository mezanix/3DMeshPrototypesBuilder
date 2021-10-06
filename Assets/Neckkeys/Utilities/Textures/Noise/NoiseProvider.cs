using UnityEngine;

namespace Neckkeys.Utilities.Textures.Noise
{
    public class NoiseProvider
    {
        public NoiseProvider()
        {

        }

        public virtual float ProvideNoise(float x, float y)
        {
            return Mathf.PerlinNoise(x, y) * 2f - 1f;
        }

        public virtual Color[] ProvidePixels()
        {
            return new Color[0];
        }

        public virtual float[] ProvideHeightmap()
        {
            return new float[0];
        }

        public virtual bool IsGlobal()
        {
            return false;
        }
    }
}