using UnityEngine;

namespace Neckkeys.Utilities.Extensions
{
    public static class EventExtensions
    {
        public static bool IsRightClick(this Event t)
        {
            return t.type == EventType.MouseDown && t.button == 1;
        }

        public static bool LeftClickDrag(this Event t)
        {
            return t.type == EventType.MouseDrag && t.button == 0;
        }

        public static bool LeftClickDown(this Event t)
        {
            return t.type == EventType.MouseDown && t.button == 0;
        }
        public static bool LeftClickUp(this Event t)
        {
            return t.type == EventType.MouseUp && t.button == 0;
        }

        public static bool IsKeyDown(this Event t, KeyCode keyCode)
        {
            return t.type == EventType.KeyDown && t.keyCode == keyCode;
        }
    }
}