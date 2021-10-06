using Neckkeys.Utilities.Extensions;

namespace Neckkeys.Utilities.StringServices
{
    public static class StringConsts
    {
        public static class General
        {
            public const string Neckkeys = "Neckkeys";
            public const string VisualScripting = "VisualScripting";

            public const string Graph = "Graph";
            public const string Class = "Class";
            public const string Flow = "Flow";

            public const string New = "New";

            public const string Utilities = "Utilities";
            public const string Materials = "Materials";
            public const string Colors = "Colors";

            public const string Color = "Color";
            public const string Opaque = "Opaque";
            public const string Unlit = "Unlit";
            public const string Standard = "Standard";
            public const string Particles = "Particles";


            public const string Mesh = "Mesh";
            public const string mesh = "mesh";
            public const string Meshes = "Meshes";
            public const string Generated = "Generated";

            public const string Asset = "Asset";
            public const string Assets = "Assets";
            public const string asset = "asset";

            public const string Texture = "Texture";

            public const string project = "project";
            public const string relative = "relative";
            public const string path = "path";
            public const string Please = "Please";

            public const string select = "select";
            public const string Select = "Select";
            public const string Find = "Find";
            public const string Save = "Save";

            public const string folder = "folder";
            public const string inside = "inside";

            public const string your = "your";
            public const string Not = "Not";
            public const string a = "a";

            public const string Ok = "Ok";
            public const string Delete = "Delete";
            public const string Are = "Are";
            public const string you = "you";

            public const string sure = "sure";
            public const string want = "want";
            public const string to = "to";

            public const string delete = "delete";
            public const string _this = "this";
            public const string Yes = "Yes";
            public const string No = "No";

            public const string Replace = "Replace";
            public const string exists = "exists";
            public const string replace = "replace";
            public const string it = "it";

            public const string are = "are";
            public const string Parent = "Parent";
            public const string rules = "rules";
            public const string Vertices = "Vertices";
            public const string Vertex = "Vertex";
            public const string generation = "generation";

            public const string Type = "Type";
            public const string Found = "Found";
            public const string Add = "Add";
            public const string Test = "Test";
            public const string Preview = "Preview";
            public const string Shader = "Shader";
            public const string Default = "Default";
        }

        public static class Resources
        {
            public static class Utilities
            {
                const string path = General.Neckkeys + "/" + General.Utilities;

                public static class Materials
                {
                    const string path = Utilities.path + "/" + General.Materials;

                    public const string ParticlesStandardUnlitOpaqueColor = path + "/" +
                        General.Particles + General.Standard + General.Unlit +
                        General.Opaque + General.Color;

                    public const string UnlitTexture = path + "/" +
                        General.Unlit + General.Texture;

                    public const string Default = path + "/" +
                        General.Default;
                }
            }
        }

        public static class Data
        {
            public static string NotAProjectRelativePath =>
                General.Not.Add(" ", General.a, General.project, General.relative, General.path);

            public static string NotInsideProjectPath =>
                General.Not.Add(" ", General.inside, General.project, General.path);

            public static string PleaseSelectAFolderInsideYourProjectAssetsFolder =>
                General.Please.Add(" ", General.select, General.a, General.folder, General.inside, General.your, General.project, General.Assets,
                    General.folder);

            public static string AreYouSureYouWantToDeleteThis =>
                General.Are.Add(" ", General.you, General.sure, General.you, General.want, General.to, General.delete, General._this);

            public static string areYouSureYouWantToReplaceIt =>
                General.are.Add(" ", General.you, General.sure, General.you, General.want, General.to, General.replace, General.it);

            public static string existsAreYouSureYouWantToReplaceIt =>
                General.exists.Add(" ", areYouSureYouWantToReplaceIt);

            public static class Save
            {
                public static string Mesh => General.Save.Add(" ", General.Mesh);
            }
        }

        public static class Reflection
        {
            public static string TypeNotFound => General.Type.Add(" ", General.Not, General.Found);
        }

        public static class EditorUtility
        {
            public static class Select
            {
                public static string GeneratedMesh => General.Select.Add(" ", General.Generated, General.Mesh);
                public static string Parent => General.Select.Add(" ", General.Parent);
                public static string PreviewShader =>
                    General.Select.Add(" ", General.Preview, General.Shader);
            }

            public static class Find
            {
                public static string GeneratedMesh => General.Find.Add(" ", General.Generated, General.Mesh);
            }
        }

        public static class EditorPrefs
        {
            public static class Keys
            {
                public const string ScriptsIdePath = "kScriptsDefaultApp";

                public const string meshSavingPath = "EditorMeshSavingPath";
            }
        }
    
        public static class UserShaderNames
        {
            public static string VertexColorUnlit => General.Vertex.Add(" ",
                General.Color, General.Unlit);
        }
    }
}