using Neckkeys.Utilities.Extensions;
using UnityEngine;

namespace Neckkeys.Utilities.Textures.Noise
{
    public static class Perlin
    {
        public static Color[] Simple(int width = 1024, int height = 1024)
        {
            Color[] r = new Color[width * height];
            int c = -1;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    c++;
                    r[c] = (Color.white * Mathf.PerlinNoise(i.Ratio(width), j.Ratio(height))).With(a: 1f);
                }
            }
            return r;
        }

		public static Color[] Pixels(
			int width, int height, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset,
			float floorLimit = 0f, float ceilLimit = 1f,
			bool oneMinus = false)
        {
			Color[] r = new Color[width * height];
			float[] heightmap = Heightmap(width, height, seed, scale, octaves, persistance, lacunarity, offset,
				floorLimit, ceilLimit,
				oneMinus);

			for (int i = 0; i < r.Length; i++)
            {
				r[i] = (Color.white * heightmap[i]).With(a: 1f);
            }

			return r;
        }

        private static float[] Heightmap(
			int width, int height, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset,
			float floorLimit = 0f, float ceilLimit = 1f,
			bool oneMinus = false)
        {
			float[] r = new float[width * height];

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

			float maxNoiseHeight = float.MinValue;
			float minNoiseHeight = float.MaxValue;

			float halfWidth = width / 2f;
			float halfHeight = height / 2f;

			int c = -1;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					c++;
					float amplitude = 1;
					float frequency = 1;
					float noiseHeight = 0;

					for (int i = 0; i < octaves; i++)
					{
                        float sampleX = (x - halfWidth) / scale * frequency + octaveOffsets[i].x;
                        float sampleY = (y - halfHeight) / scale * frequency + octaveOffsets[i].y;

                        //float sampleX = (x) / scale * frequency + offset.x;
                        //float sampleY = (y) / scale * frequency + offset.y;

                        float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
						noiseHeight += perlinValue * amplitude;

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

            for (int i = 0; i < r.Length; i++)
			{
				r[i] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, r[i]);

				r[i] = oneMinus ? 1f - r[i] : r[i];

				r[i] = r[i] <= floorLimit ? 0f : r[i];
				r[i] = r[i] >= ceilLimit ? 1f : r[i];
			}

			return r;
		}
    }
}