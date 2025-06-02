#if UNITY_EDITOR
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace TinyBuilder
{
    public static class TinyBuilder
    {
        #region Build Current

        [MenuItem(MenuNames.Build + MenuNames.BuildAPKCurrent, false, 2)]
        private static void BuildAPKCurrent()
        {
            BuildAPK();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildABBCurrent, false, 3)]
        private static void BuildABBCurrent()
        {
            BuildABB();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAPKABBCurrent, false, 4)]
        private static void BuildBothCurrent()
        {
            BuildAPK();
            BuildABB();
        }

        #endregion

        #region Build Increment

        [MenuItem(MenuNames.Build + MenuNames.BuildAPKIncrement, false, 21)]
        private static void BuildAPKIncrement()
        {
            var appVersion = new AppVersion(Application.version).Increment();
            new BuildNumber(appVersion.Value()).EqualizeWithAppVersion();
            
            BuildAPK();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildABBIncrement, false, 22)]
        private static void BuildABBIncrement()
        {
            var appVersion = new AppVersion(Application.version).Increment();
            new BuildNumber(appVersion.Value()).EqualizeWithAppVersion();
            
            BuildABB();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAPKABBIncrement, false, 23)]
        private static void BuildBothIncrement()
        {
            var appVersion = new AppVersion(Application.version).Increment();
            new BuildNumber(appVersion.Value()).EqualizeWithAppVersion();

            BuildAPK();
            BuildABB();
        }

        #endregion

        #region Build Settings

        [MenuItem(MenuNames.Build + MenuNames.BuildSettings, false, 41)]
        private static void ShowBuildSettings()
        {
            BuildSettingsWindow.ShowWindow();
        }

        #endregion

        private static void BuildAPK()
        {
            CreateDirectory(FolderPaths.APK);

            string fileName = FileNameParts.Main + Application.version + FileNameParts.Postfix + FileNameParts.ApkExtension;
            Build(FolderPaths.APK, fileName);
        }

        private static void BuildABB()
        {
            CreateDirectory(FolderPaths.AAB);

            string fileName = FileNameParts.Main + Application.version + FileNameParts.AabExtension;
            Build(FolderPaths.AAB, fileName);
        }

        private static void Build(string filePath, string fileName)
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

        private static void ShowResult(BuildSummary summary)
        {
            if (summary.result == BuildResult.Succeeded)
            {
                string bundlesPath = Path.Combine(Application.dataPath, FolderPaths.Bundle);
                OpenFolder(bundlesPath);
                OpenFolder(FolderPaths.APK);

                Debug.Log("Build succeeded: " + summary.outputPath);
            }
            else if (summary.result == BuildResult.Failed)
            {
                Debug.LogError("Build failed");
            }
        }

        private static void OpenFolder(string path)
        {
            string normalizedPath = path.Replace("/", "\\");

            if (Directory.Exists(normalizedPath) == true)
            {
                Process.Start("explorer.exe", normalizedPath);
                Debug.Log("Opened Explorer at: " + normalizedPath);
            }
            else
            {
                Debug.LogError("Folder does not exist: " + normalizedPath);
            }
        }

        private static void CreateDirectory(string folderPath)
        {
            if (Directory.Exists(folderPath) == false)
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}
#endif