#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using Debug = UnityEngine.Debug;

namespace TinyBuilder
{
    public record Build
    {
        private BuildDirectory _buildDirectory;

        public void APK()
        {
            CreateBuildDirectory(FolderPaths.APK);
            string fileName = GetFileName() + FileNameParts.ApkExtension;
            string folderPath = GetAPKFilePath();
            BuildPipeline(folderPath, fileName);
        }
        
        public void AAB()
        {
            CreateBuildDirectory(FolderPaths.AAB);
            string fileName = GetFileName() + FileNameParts.AabExtension;
            string folderPath = GetAPKFilePath();
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

        private void CreateBuildDirectory(string directoryPath)
        {
            _buildDirectory = new BuildDirectory(directoryPath);
            
            if (_buildDirectory.Exists() == false)
            {
                _buildDirectory = _buildDirectory.Create(directoryPath);
            }
        }
        
        private string GetFileName()
        {
            var settings = new BuildSettings(FolderPaths.BuildSettings);

            if (settings.HaveFile() == false)
            {
                throw new FileNotFoundException($"File does not exist: {FolderPaths.BuildSettings}");
            }

            return settings.FileName();
        }
        
        private string GetAPKFilePath()
        {
            var settings = new BuildSettings(FolderPaths.BuildSettings);

            if (settings.HaveFile() == false)
            {
                throw new FileNotFoundException($"File does not exist: {FolderPaths.BuildSettings}");
            }

            return settings.APKFilePath();
        }
        
        private string GetAABFilePath()
        {
            var settings = new BuildSettings(FolderPaths.BuildSettings);

            if (settings.HaveFile() == false)
            {
                throw new FileNotFoundException($"File does not exist: {FolderPaths.BuildSettings}");
            }

            return settings.AABFilePath();
        }
    }
}
#endif