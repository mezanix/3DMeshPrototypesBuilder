using UnityEngine;

namespace Neckkeys.Utilities.Extensions
{
    public static class ArrayExtensions
    {
        public static void DebugLogGranular(this object[] t, string prefix = "", string suffix = "", int logLevel = 0)
        {
            for (int i = 0; i < t.Length; i++)
            {
                switch(logLevel)
                {
                    case 0:
                        Debug.Log(prefix + t[i] + suffix);
                        break;
                    case 1:
                        Debug.LogWarning(prefix + t[i] + suffix);
                        break;
                    case 2:
                        Debug.LogError(prefix + t[i] + suffix);
                        break;
                    default:
                        Debug.Log(prefix + t[i] + suffix);
                        break;
                }
            }
        }
    }
}