using Neckkeys.UtilitiesEditor.Extensions;
using UnityEditor;
using UnityEngine;

namespace Neckkeys.UtilitiesEditor.DataServices
{
    public static class NKAssetsDatabaseUtilities
    {
        public static void SetDirtySaveAndRefresh(this Object t)
        {
            EditorUtility.SetDirty(t);
            SaveAndRefresh();

            Debug.Log(t.name + " set dirty save and refresh");
        }

        public static void CreateAssetSaveAndRefresh(this Object t, string path)
        {
            AssetDatabase.CreateAsset(t, path);
            SaveAndRefresh();
        }

        public static void CreateAssetSaveRefreshAndPing(this Object t, string path)
        {
            t.CreateAssetSaveAndRefresh(path);
            t.Ping();
        }

        public static void SaveAndRefresh()
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}