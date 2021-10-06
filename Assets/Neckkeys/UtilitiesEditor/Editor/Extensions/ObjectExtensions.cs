using System;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Neckkeys.UtilitiesEditor.Extensions
{
    public static class ObjectExtensions
    {
        public static void Select(this Object t, Action DoAfterSelection = null)
        {
            Selection.activeObject = t;

            DoAfterSelection?.Invoke();
        }

        public static void Ping(this Object t)
        {
            EditorGUIUtility.PingObject(t);
        }
    }
}