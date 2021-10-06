using Neckkeys.Utilities.StringServices;
using UnityEngine;

namespace Neckkeys.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string AfterLastOf(this string t, char c)
        {
            int lio = t.LastIndexOf(c);
            return t.Substring(lio + 1, t.Length - lio - 1);
        }

        public static string BeforeLastOf(this string t, char c)
        {
            int lio = t.LastIndexOf(c);
            return t.Substring(0, lio);
        }

        public static string ToProjectRelative(this string t)
        {
            if (t.IsProjectRelative())
                return t;

            return StringConsts.General.Assets + t.Substring(Application.dataPath.Length);
        }

        public static bool IsInsideProject(this string t)
        {
            return t.Contains(Application.dataPath);
        }

        public static bool IsProjectRelative(this string t)
        {
            return t.Substring(0, StringConsts.General.Assets.Length) == StringConsts.General.Assets;
        }

        public static string Add(this string t, string sep, params string[] s)
        {
            string r = t;

            for (int i = 0; i < s.Length; i++)
            {
                r += sep + s[i];
            }

            return r;
        }
    }
}