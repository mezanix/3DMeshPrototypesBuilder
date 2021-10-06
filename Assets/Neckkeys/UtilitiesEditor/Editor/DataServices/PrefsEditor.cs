using Neckkeys.Utilities.StringServices;
using UnityEditor;

namespace Neckkeys.UtilitiesEditor.DataServices
{
    public static class PrefsEditor
    {
        public static void SetString(string key, string s)
        {
            EditorPrefs.SetString(key, s);
        }

        public static string ScriptsIdePath => EditorPrefs.GetString(StringConsts.EditorPrefs.Keys.ScriptsIdePath);
    }
}