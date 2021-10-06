using Neckkeys.MeshPrototypesBuilder;
using Neckkeys.Utilities.Extensions;
using Neckkeys.Utilities.ResourcesNamespace;
using Neckkeys.Utilities.StringServices;
using Neckkeys.UtilitiesEditor;
using Neckkeys.UtilitiesEditor.Extensions;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Neckkeys.MeshPrototypesBuilderEditor
{
    [CustomEditor(typeof(MeshGeneratorMono), true)]
    public class MeshGeneratorMonoInspector : Editor
    {
        MeshGeneratorMono t = null;

        List<SerializedProperty> serializedProperties = new List<SerializedProperty>();

        private void OnEnable()
        {
            t = target as MeshGeneratorMono;

            try
            {
                serializedProperties.Clear();
                serializedProperties.Add(serializedObject.FindProperty(StringConsts.General.rules));
            }
            catch
            {

            }
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            Draw();

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }

            DrawActionButtons();
        }

        private void Draw()
        {
            AddMissingParentComponent();

            GenerateMesh();

            DrawSerializedProperties();
        }

        private void AddMissingParentComponent()
        {
            t.AddMissingParentComponent();
        }

        private void DrawActionButtons()
        {
            Rect[] rects = EditorGUILayout.GetControlRect().Divide(true, 0.9f, 0.1f);

            DrawSelectParent(rects[0]);
            DrawDelete(rects[1]);

            DrawPreviewShaderSelection();
        }

        private void DrawPreviewShaderSelection()
        {
            if (GUI.Button(EditorGUILayout.GetControlRect(),
                StringConsts.EditorUtility.Select.PreviewShader) == false)
                return;

            GenericMenu menu = new GenericMenu();

            menu.AddItem(
                new GUIContent(StringConsts.UserShaderNames.VertexColorUnlit), false,
                SetPreviewShader,
                ResourcesLib.Utilities.Materials.ParticlesStandardUnlitOpaqueColor);

            menu.AddItem(
                new GUIContent(StringConsts.General.Default), false,
                SetPreviewShader,
                ResourcesLib.Utilities.Materials.Default);

            menu.ShowAsContext();
        }

        private void SetPreviewShader(object obj)
        {
            Material previewMaterial = obj as Material;
            if (previewMaterial == null)
                return;

            t.Material = previewMaterial;
        }

        private void DrawDelete(Rect rect)
        {
            if (GUI.Button(rect, "X") == false)
                return;

            NKEditorUtility.DisplayDialogComplexDeleteObject(StringConsts.General.Mesh, t.gameObject);
        }

        private void DrawSelectParent(Rect rect)
        {
            if (GUI.Button(rect, StringConsts.EditorUtility.Select.Parent) == false)
                return;

            SelectParent();
        }

        private void SelectParent()
        {
            t.transform.parent.gameObject.Select();
        }

        private void DrawSerializedProperties()
        {
            foreach (SerializedProperty t in serializedProperties)
            {
                EditorGUILayout.PropertyField(t, true);
            }
        }

        private void GenerateMesh()
        {
            t.GenerateMesh();
        }
    }
}