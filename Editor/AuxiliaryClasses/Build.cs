#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using Debug = UnityEngine.Debug;

namespace TinyBuilder
{
    public record Build
    {
        private readonly BuildSettings _buildSettings;
        
        private BuildDirectory _buildDirectory;

        public Build(BuildSettings buildSettings)
        {
            _buildSettings = buildSettings;
        }
        
        public void APK()
        {
            new BuildDirectory(FolderPaths.APK).Create();
            string folderPath = _buildSettings.DirectoryAPK();
            string fileName = _buildSettings.FileNameAPK();
            BuildPipeline(folderPath, fileName);
        }
        
        public void AAB()
        {
            new BuildDirectory(FolderPaths.AAB).Create();
            string folderPath = _buildSettings.DirectoryAAB();
            string fileName = _buildSettings.FileNameAAB();
            BuildPipeline(folderPath, fileName);
        }
        
        private void BuildPipeline(string filePath, string fileName)
        {
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
            {
                locationPathName = Path.Combine(filePath, fileName),
                target = BuildTarget.Android,
                options = BuildOptions.None
            };

            BuildReport report = UnityEditor.BuildPipeline.BuildPlayer(buildPlayerOptions);
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