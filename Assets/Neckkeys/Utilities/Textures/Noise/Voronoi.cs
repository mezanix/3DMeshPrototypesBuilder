using Neckkeys.Utilities.Extensions;
using UnityEngine;

namespace Neckkeys.Utilities.Textures.Noise
{
    public static class Voronoi
    {
        public static Color[] Pixels(int width, int height, int n)
        {
            Color[] r = new Color[width * height];
            float[] heightmap = Heightmap(width, height, n);

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = (Color.white * heightmap[i]).With(a: 1f);
            }

            return r;
        }

        public static float[] Heightmap(int width, int height, int n)
        {
            float[] r = new float[width * height];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = 0f;
            }

            Vector2Int[] points = new Vector2Int[n];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
            }

            int c = -1;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    c++;

                    float minDist = Mathf.Min((float)width, (float)height);
                    float noiseValue = 0;
                    for (int p = 0; p < points.Length; p++)
                    {
                        int pX = points[p].x;
                        int pY = points[p].y;
                        float Dist1X = (float)Mathf.Abs((x - pX));
                        float Dist1Y = (float)Mathf.Abs((y - pY));
                        float Dist2X = (float)width - Dist1X;
                        float Dist2Y = (float)height - Dist1Y;
                        /*to grant seamless I take the min between distX and wid-distX
						 |                       |
						 |                       |     ----------- = Dist1X
						 |...i-----------X.......|     ..........  = Dist2X
						 |                       |
						 */
                        Dist1X = Mathf.Min(Dist1X, Dist2X);
                        /*to grant seamless I take the min between distY and hei-distY*/
                        Dist1Y = Mathf.Min(Dist1Y, Dist2Y);
                        float dist = Mathf.Sqrt(Mathf.Pow(Dist1X, 2) + Mathf.Pow(Dist1Y, 2));

                        float maxDist = Mathf.Sqrt(Mathf.Pow((float)width, 2) + Mathf.Pow((float)height, 2));
                        if (dist < minDist)
                        {
                            noiseValue = dist / minDist;
                            minDist = dist;
                        }
                    }
                    r[c] = noiseValue;
                }
            }

            return r;
        }

    }
}