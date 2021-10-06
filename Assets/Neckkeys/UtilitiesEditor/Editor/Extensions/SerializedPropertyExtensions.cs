using System.Collections.Generic;
using UnityEditor;

namespace Neckkeys.UtilitiesEditor.Extensions
{
    public static class SerializedPropertyExtensions
    {
        public static void DrawLayout(this List<SerializedProperty> t)
        {
            for (int i = 0; i < t.Count; i++)
            {
                t[i].DrawLayout();
            }
        }

        public static void DrawLayout(this SerializedProperty t)
        {
            EditorGUILayout.PropertyField(t);
        }
    }
}