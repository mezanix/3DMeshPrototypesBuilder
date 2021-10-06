using UnityEditor;
using UnityEngine;

namespace Neckkeys.UtilitiesEditor
{
    public static class NKEditorGUI
    {
        public static void LabelField(Rect rect, string text, Color color)
        {
            Color old = GUI.color;

            GUI.color = color;
            EditorGUI.LabelField(rect, text);

            GUI.color = old;
        }
    }
}