#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using Debug = UnityEngine.Debug;

namespace TinyBuilder
{
    public record Builder
    {
        private BuildDirectory _buildDirectory;

        public void BuildAPK()
        {
            _buildDirectory = new BuildDirectory(FolderPaths.APK).Initialize();

            var settings = AssetDatabase.LoadAssetAtPath<BuildSettings>(FolderPaths.BuildSettings);
            string fileName = new Settings(settings).BuildFileName() + FileNameParts.ApkExtension;
            
            new Builder().Build(FolderPaths.APK, fileName);
        }

        public void BuildAAB()
        {
            _buildDirectory = new BuildDirectory(FolderPaths.AAB).Initialize();

            var settings = AssetDatabase.LoadAssetAtPath<BuildSettings>(FolderPaths.BuildSettings);
            string fileName = new Settings(settings).BuildFileName() + FileNameParts.AabExtension;

            new Builder().Build(FolderPaths.APK, fileName);
        }
        
        private void Build(string filePath, string fileName)
        {
            var assetBundleCleaner = new AssetBundleCleaner();
            assetBundleCleaner.CleanAssetBundleFolder(FolderPaths.AssetBundle);

            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
            {
                locationPathName = Path.Combine(filePath, fileName),
                target = BuildTarget.Android,
                options = BuildOptions.None
            };

            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            BuildSummary summary = report.summary;

            ShowResult(summary);
        }

        private void ShowResult(BuildSummary buildSummary)
        {
            if (buildSummary.result == BuildResult.Succeeded)
            {
                _buildDirectory.Open();
                Debug.Log("Build succeeded: " + buildSummary.outputPath);
            }
            else if (buildSummary.result == BuildResult.Failed)
            {
                Debug.LogError("Build failed");
            }
            else
            {
                Debug.LogError("BuildSummary.result = " + buildSummary.result);
            }
        }
    }
}
#endif