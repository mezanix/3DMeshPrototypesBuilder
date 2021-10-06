using UnityEditor;

namespace Neckkeys.UtilitiesEditor.DataServices
{
    public class PersistentPath
    {
        string path = "";
        string key = "";

        public PersistentPath(string path, string key)
        {
            this.path = path;
            this.key = key;

            SetPath();
        }

        public void SetPath(string path)
        {
            this.path = path;
            SetPath();
        }

        void SetPath()
        {
            EditorPrefs.SetString(key, path);
        }

        public string GetPath()
        {
            return EditorPrefs.GetString(key, path);
        }
    }
}