using Neckkeys.MeshPrototypesBuilder;
using Neckkeys.Utilities.Extensions;
using Neckkeys.Utilities.Reflection;
using Neckkeys.Utilities.StringServices;
using Neckkeys.UtilitiesEditor;
using Neckkeys.UtilitiesEditor.DataServices;
using Neckkeys.UtilitiesEditor.Extensions;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Neckkeys.MeshPrototypesBuilderEditor
{
    [CustomEditor(typeof(MeshBuilder))]
    public class MeshBuilderInspector : Editor
    {
        MeshBuilder t = null;

        List<SerializedProperty> serializedProperties = new List<SerializedProperty>();

        private void OnEnable()
        {
            t = target as MeshBuilder;

            //serializedProperties.Add(serializedObject.FindProperty("savePath"));
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            Draw();

            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }

        private void Draw()
        {
            DrawSerializedProperties();

            DrawFindGeneratedMesh();

            DrawSaveMesh();

            DrawSaveMeshAs();

            DrawHolders();
        }

        private void DrawFindGeneratedMesh()
        {
            Object assetExists = AssetDatabase.LoadAssetAtPath<Object>(t.savePath);
            if (assetExists == null)
                return;

            if (GUI.Button(EditorGUILayout.GetControlRect(), StringConsts.EditorUtility.Find.GeneratedMesh) == false)
                return;

            assetExists.Ping();
        }

        private void DrawSerializedProperties()
        {
            serializedProperties.DrawLayout();
        }

        private void DrawSaveMeshAs()
        {
            string saveMesh = "Save Mesh As";

            if (GUI.Button(EditorGUILayout.GetControlRect(), saveMesh) == false)
                return;

            if (AskForSavePath())
                SaveMesh();
        }

        private void DrawSaveMesh()
        {
            if (string.IsNullOrEmpty(t.savePath))
                return;

            string saveMesh = "Save Mesh";

            if (GUI.Button(EditorGUILayout.GetControlRect(), saveMesh) == false)
                return;

            SaveMesh();
        }

        private bool AskForSavePath()
        {
            string r = EditorUtility.SaveFilePanel(
                StringConsts.Data.Save.Mesh, Application.dataPath, StringConsts.General.Mesh, StringConsts.General.asset);

            if (r.IsInsideProject() == false)
            {
                NKEditorUtility.DisplayDialogNotInsideProjectPath();
                return false;
            }

            t.savePath = r.ToProjectRelative();

            return true;
        }

        private void SaveMesh()
        {
            t.CombineMesh();

            AssetSaver meshSaver = new AssetSaver(t.MyMeshFilter.sharedMesh, t.savePath);
            meshSaver.Save();

            DestroyImmediate(t.MyMeshFilter);
        }

        private void DrawHolders()
        {
            t.RepairHolders();

            DrawAddHolder();

            for (int i = 0; i < t.holders.Count; i++)
            {
                DrawHolder(t.holders[i], i);
            }
        }

        void DrawHolder(GameObject holder, int i)
        {
            Rect[] rects = EditorGUILayout.GetControlRect().Divide(true, 0.8f, 0.2f);

            DrawHolderLabel(rects[0], holder, i);

            DrawHolderSelect(rects[1], holder);
        }

        private void DrawHolderLabel(Rect rect, GameObject holder, int i)
        {
            EditorGUI.LabelField(rect, "" + i + " " + holder.name);
        }

        private void DrawHolderSelect(Rect rect, GameObject holder)
        {
            if (GUI.Button(rect, "Select") == false)
                return;

            holder.Select();
        }

        private void DrawAddHolder()
        {
            if (GUI.Button(
                EditorGUILayout.GetControlRect(),
                StringConsts.General.Add.Add(" ", StringConsts.General.Mesh)) == false)
                return;

            GenericMenu menu = new GenericMenu();

            IEnumerable<string> typeNames = TypeFactory<MeshGeneratorMono>.GetTypeNames();

            foreach (string t in typeNames)
            {
                menu.AddItem(new GUIContent(t.AfterLastOf('.')), false, AddHolder, t);
            }

            menu.ShowAsContext();
        }

        private void AddHolder(object o)
        {
            Type type = TypeFactory<MeshGeneratorMono>.GetType(o.ToString());

            t.AddHolder(type);

            EditorUtility.SetDirty(t);

            t.holders[t.holders.Count - 1].Select();
        }
    }
}