using Neckkeys.Utilities.Extensions;
using System.Linq;
using UnityEngine;

namespace Neckkeys.Utilities.Textures.Noise
{
    public class NoiseModifier
    {
        int width = 1024;
        int height = 1024;

        int seed = 1;

        float scale = 10f;

        int octaves = 3;
        float persistance = 20f;
        float lacunarity = 20f;

        Vector2 offset = Vector2.zero;

        bool oneMinus = false;

        float floorLimit = 0f;
        float ceilLimit = 1f;

        NoiseProvider provider = null;

        public NoiseModifier(int width, int height, int seed, float scale,
            int octaves, float persistance, float lacunarity, Vector2 offset,
            bool oneMinus,
            float floorCeilLimit, float floorCeilLimitWidth,
            NoiseProvider provider)
        {
            this.width = width;
            this.height = height;
            this.seed = seed;
            this.scale = scale;

            this.octaves = octaves;
            this.persistance = persistance;
            this.lacunarity = lacunarity;
            this.offset = offset;

            this.oneMinus = oneMinus;

            floorLimit = Mathf.Clamp(floorCeilLimit - floorCeilLimitWidth, 0f, 1f);
            ceilLimit = Mathf.Clamp(floorCeilLimit + floorCeilLimitWidth, 0f, 1f);

            this.provider = provider;
        }

        private float[] Heightmap()
        {
            float[] r = new float[width * height];

            float maxNoiseHeight = float.MinValue;
            float minNoiseHeight = float.MaxValue;

            if (provider.IsGlobal())
            {
                r = provider.ProvideHeightmap();
            }
            else
            {
                System.Random prng = new System.Random(seed);
                Vector2[] octaveOffsets = new Vector2[octaves];
                for (int i = 0; i < octaves; i++)
                {
                    float offsetX = prng.Next(-100000, 100000) + offset.x;
                    float offsetY = prng.Next(-100000, 100000) + offset.y;
                    octaveOffsets[i] = new Vector2(offsetX, offsetY);
                }

                if (scale <= 0)
                {
                    scale = 0.0001f;
                }

                float halfWidth = width / 2f;
                float halfHeight = height / 2f;

                int c = -1;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        c++;
                        float amplitude = 1f;
                        float frequency = 1f;
                        float noiseHeight = 0f;

                        for (int i = 0; i < octaves; i++)
                        {
                            float sampleX = (x - halfWidth) / scale * frequency + octaveOffsets[i].x;
                            float sampleY = (y - halfHeight) / scale * frequency + octaveOffsets[i].y;

                            //float sampleX = (x) / scale * frequency + offset.x;
                            //float sampleY = (y) / scale * frequency + offset.y;

                            float noiseValue = provider.ProvideNoise(sampleX, sampleY);
                            noiseHeight += noiseValue * amplitude;

                            amplitude *= persistance;
                            frequency *= lacunarity;
                        }

                        if (noiseHeight > maxNoiseHeight)
                        {
                            maxNoiseHeight = noiseHeight;
                        }
                        else if (noiseHeight < minNoiseHeight)
                        {
                            minNoiseHeight = noiseHeight;
                        }

                        r[c] = noiseHeight;
                    }
                }

            }

            float maxR = r.Max();
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = provider.IsGlobal()? r[i] : 
                    Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, r[i]);

                r[i] = oneMinus ? 1f - r[i] : r[i];

                r[i] = r[i] <= floorLimit ? 0f : r[i];
                r[i] = r[i] >= ceilLimit ? 1f : r[i];
            }

            return r;
        }

        public Color[] Pixels()
        {
            Color[] r = new Color[width * height];
            float[] heightmap = Heightmap();

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = (Color.white * heightmap[i]).With(a: 1f);
            }

            return r;
        }
    }
}