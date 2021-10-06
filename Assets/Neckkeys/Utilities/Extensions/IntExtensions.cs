namespace Neckkeys.Utilities.Extensions
{
    public static class IntExtensions
    {
        public static float Ratio(this int t, int deno = 100)
        {
            return (float)t / (float)deno;
        }
    }
}