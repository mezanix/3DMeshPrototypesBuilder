using Neckkeys.Utilities.StringServices;
using Neckkeys.Utilities.Extensions;
using Neckkeys.UtilitiesEditor.DataServices;
using System;
using UnityEditor;

namespace Neckkeys.UtilitiesEditor
{
    public static class NKEditorUtility
    {
        public static void DisplayDialogComplexReplaceAsset(string path, UnityEngine.Object asset, string assetTypeName = StringConsts.General.Asset)
        {
            DisplayDialogComplex(StringConsts.General.Replace.Add(" ", assetTypeName),
                    (assetTypeName == StringConsts.General.Asset ? 
                    StringConsts.General.Asset : 
                    assetTypeName.Add(" ", StringConsts.General.asset, StringConsts.Data.existsAreYouSureYouWantToReplaceIt)) + "?",
                    StringConsts.General.Yes, () =>
                    {
                        AssetDatabase.DeleteAsset(path);
                        asset.CreateAssetSaveRefreshAndPing(path);
                    },
                    StringConsts.General.No, delegate { });
        }

        public static void DisplayDialogComplexDeleteObject(string objectTypeName, UnityEngine.Object obj)
        {
            DisplayDialogComplex(
                StringConsts.General.Delete.Add(" ", objectTypeName), 
                StringConsts.Data.AreYouSureYouWantToDeleteThis + " " + objectTypeName + "?",
                StringConsts.General.Yes, () => 
                { 
                    UnityEngine.Object.DestroyImmediate(obj);
                    obj = null;
                },
                StringConsts.General.No, delegate { });
        }

        public static void DisplayDialogComplex(string title, string message,
            string ok, Action okAction,
            string cancel, Action cancelAction,
            string alt = "", Action altAction = null)
        {
            int dialogOut = EditorUtility.DisplayDialogComplex(title, message, ok, cancel, alt);

            switch (dialogOut)
            {
                case 0:
                    okAction();
                    break;

                case 1:
                    cancelAction();
                    break;

                case 2:
                    altAction();
                    break;
            }
        }

        public static void DisplayDialogNotInsideProjectPath()
        {
            EditorUtility.DisplayDialog(
                StringConsts.Data.NotInsideProjectPath,
                StringConsts.Data.PleaseSelectAFolderInsideYourProjectAssetsFolder,
                StringConsts.General.Ok);
        }
    }
}