using System.Collections.Generic;

namespace Neckkeys.Utilities.Extensions
{
    public static class CollectionsExtensions
    {
        public static bool InRange<T>(this List<T> t, int i)
        {
            return i > -1 && i < t.Count;
        }

        public static List<object> ListOf(this object t, int count)
        {
            List<object> r = new List<object>();

            for (int i = 0; i < count; i++)
            {
                r.Add(t);
            }

            return r;
        }
    }
}