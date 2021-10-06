using Neckkeys.Utilities.StringServices;
using Neckkeys.Utilities.Extensions;
using UnityEditor;
using UnityEngine;

namespace Neckkeys.UtilitiesEditor.DataServices
{
    public class AssetSaver
    {
        Object obj = null;
        string path = Application.dataPath;

        public AssetSaver(Object obj, string path)
        {
            this.obj = obj;
            this.path = path.ToProjectRelative();
        }

        public void Save()
        {
            Object assetExists = AssetDatabase.LoadAssetAtPath<Object>(path);
            if (assetExists == null)
            {
                obj.CreateAssetSaveRefreshAndPing(path);
                return;
            }

            NKEditorUtility.DisplayDialogComplexReplaceAsset(path, obj, StringConsts.General.Mesh);
        }
    }
}
