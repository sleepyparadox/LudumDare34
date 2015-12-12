using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.Audio;

namespace uSquid.Editor
{
    public class AssetTreeBuilder : CSCodeBuilder
    {
        const string StaticClassName = "MyAssets";
        const string StaticClassLocalPath = "MyAssets.cs";

        [MenuItem("uSquid/Regenerate " + StaticClassLocalPath)]
        public static void Generate()
        {
            var assetsDirectory = uSquidUtility.CleanPath(Application.dataPath);

            Debug.Log(assetsDirectory);

            var assetTreeBuilder = new AssetTreeBuilder();
            assetTreeBuilder.AppendUnityProjectAssets(staticClassName: StaticClassName);

            File.WriteAllText(string.Format("{0}/{1}", Application.dataPath, StaticClassLocalPath), assetTreeBuilder.ToString());
        }

        static Dictionary<string, Type> SupportedFileTypes = new Dictionary<string, Type>()
        {
            {"anim", typeof(Animation)},
            {"mixer", typeof(AudioMixer)},
            {"wav", typeof(AudioSource)},
            {"mp3", typeof(AudioSource)},
            {"ogg", typeof(AudioSource)},
            {"compute", typeof(ComputeShader)},
            {"flare", typeof(Flare)},
            {"fontsettings", typeof(Font)},
            {"ttf", typeof(Font)},
            {"prefab", typeof(GameObject)},
            {"guiskin", typeof(GUISkin)},
            {"giparams", typeof(LightmapParameters)},
            {"mat", typeof(Material)},
            {"cs", typeof(MonoScript)},
            {"js", typeof(MonoScript)},
            {"physicMaterial", typeof(PhysicMaterial)},
            {"physicsMaterial2D", typeof(PhysicsMaterial2D)},
            {"renderTexture", typeof(RenderTexture)},
            {"shader", typeof(Shader)},
            {"shadervariants", typeof(ShaderVariantCollection)},
            {"txt", typeof(TextAsset)},
            {"png", typeof(Texture2D)},
            {"gif", typeof(Texture2D)},
            {"bmp", typeof(Texture2D)},
            {"jpg", typeof(Texture2D)},
            {"jpeg", typeof(Texture2D)},
        };
        private string _assetsDirectory;

        private DirectoryInfo GetDirectoryOrNull(string path)
        {
            if (!Directory.Exists(path))
                return null;

            return new DirectoryInfo(path);
        }

        public void AppendUnityProjectAssets(string staticClassName)
        {
            _assetsDirectory = uSquidUtility.CleanPath(Application.dataPath) + '/';
            var assetsDir = new DirectoryInfo(Application.dataPath);
            var childDirectories = new Dictionary<DirectoryInfo, string>();
            
            var resourcesDir = GetDirectoryOrNull(string.Format("{0}/Resources", Application.dataPath));
            var streamingDir = GetDirectoryOrNull(string.Format("{0}/StreamingAssets", Application.dataPath));
            
            if(resourcesDir != null)
                childDirectories.Add(resourcesDir, uSquidUtility.MakeCodeSafe(resourcesDir.Name));
            if(streamingDir != null)
                childDirectories.Add(streamingDir, uSquidUtility.MakeCodeSafe(resourcesDir.Name).Replace("Assets", ""));

            //Style
            var styleHeader = File.ReadAllLines(string.Format("{0}/uSquid/Editor/Resources/Header.cs.style", Application.dataPath));
            foreach (var line in styleHeader)
            {
                AppendLine(line.Replace("$CREATED_AT", DateTime.Now.ToString()));
            }

            AppendLine("using uSquid.Assets;");
            AppendLine("using UnityEngine;");

            AppendLine(string.Format("public static class {0}", staticClassName));
            BeginBlock();
            {
                AppendLine(string.Format("public static {0}Node Root = new {0}Node();", staticClassName));
                foreach(var child in childDirectories)
                {
                    AppendLine(string.Format("public static {0}Node.{1}Node {1} {{ get {{ return Root.{1}; }} }}", staticClassName, child.Value));
                }

                var childDirectoriesArray = string.Join(", ", childDirectories.Values.ToArray());
                AppendLine(string.Format("public static IDirectoryNode[] GetDirectories() {{ return new IDirectoryNode[] {{ {0} }}; }}", childDirectoriesArray));
            }
            EndBlock();

            WriteDirectoryClassRecursive(assetsDir, staticClassName, childDirectories);
        }

        private void WriteDirectoryClassRecursive(DirectoryInfo directory, string safeName, Dictionary<DirectoryInfo, string> overrideChildren = null)
        {
            var files = directory.GetFiles().Where(f => !ShouldIgnore(f)).GroupBy(f => uSquidUtility.MakeCodeSafe(f.Name.Split('.').First()));
            var childDirectories = directory.GetDirectories().ToDictionary(d => d, d => uSquidUtility.MakeCodeSafe(d.Name));

            if (overrideChildren != null)
                childDirectories = overrideChildren;

            //Debug.LogWarning(string.Format("Writing for {0}, {1} files, {2} children", directory.Name, files.Keys.Count, childDirectories.Keys.Count));
            var assets = new List<string>();

            AppendLine(string.Format("public class {0}Node : IDirectoryNode", safeName));
            BeginBlock();
            {
                AppendLine(string.Format("public string Name {{ get {{ return \"{0}\"; }} }}", directory.Name));
                AppendLine(string.Format("public string Path {{ get {{ return \"{0}\"; }} }}", uSquidUtility.CleanPath(directory.FullName).Replace(_assetsDirectory, "")));

                // File instances
                foreach (var group in files)
                    AppendLine(string.Format("public {0}Node {0} = new {0}Node();", group.Key));

                // Dir instances
                foreach (var pair in childDirectories)
                    AppendLine(string.Format("public {0}Node {0} = new {0}Node();", pair.Value));

                // File classes
                foreach (var group in files)
                    WriteFileClass(group, assets);

                // Dir classes
                foreach (var pair in childDirectories)
                    WriteDirectoryClassRecursive(pair.Key, pair.Value);

                //Helper functions
                var assetsArray = string.Join(", ", assets.ToArray());
                AppendLine(string.Format("public Asset[] GetAssets() {{ return new Asset[] {{ {0} }}; }}", assetsArray));

                var childFileNodesArray = string.Join(", ", files.Select(g => g.Key).ToArray());
                AppendLine(string.Format("public IAssetNode[] GetAssetNodes() {{ return new IAssetNode[] {{ {0} }}; }}", childFileNodesArray));

                var childDirectoriesArray = string.Join(", ", childDirectories.Values.ToArray());
                AppendLine(string.Format("public IDirectoryNode[] GetDirectories() {{ return new IDirectoryNode[] {{ {0} }}; }}", childDirectoriesArray));
            }
            EndBlock();
        }

        void WriteFileClass(IGrouping<string, FileInfo> group, List<string> assets)
        {
            AppendLine(string.Format("public class {0}Node : IAssetNode", group.Key));
            BeginBlock();
            {
                var fileTypes = new List<string>();

                foreach (var fileInfo in group)
                {
                    var fileType = fileInfo.Name.Split('.').Last();
                    if (!SupportedFileTypes.ContainsKey(fileType))
                    {
                        AppendLine("// unsupported filetype: " + fileInfo.Name);
                        continue;
                    }
                    var assetType =  SupportedFileTypes[fileType];

                    fileTypes.Add(fileType);
                    AppendLine(string.Format("public Asset<{1}> {0} = new Asset<{1}>(\"{2}\", \"{3}\");", fileType, assetType, fileInfo.Name, uSquidUtility.CleanPath(fileInfo.FullName).Replace(_assetsDirectory, "")));
                }

                var fileTypesArray = string.Join(", ", fileTypes.ToArray());
                AppendLine(string.Format("public Asset[] GetAssets() {{ return new Asset[] {{ {0} }}; }}", fileTypesArray));

                assets.AddRange(fileTypes.Select(ft => group.Key + "." + ft));
            }
            EndBlock();
        }

        bool ShouldIgnore(FileInfo file)
        {
            return file.Name.Contains(".meta") || file.Name.Contains(".cs");
            //return file.Name.Length >= 4 && file.Name.Substring(file.Name.Length - 4, 4) == ".meta";
        }
    }

}
