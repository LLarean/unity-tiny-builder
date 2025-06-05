#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;

namespace TinyBuilder
{
    public abstract class MainMenu
    {
        [MenuItem(MenuNames.Build + MenuNames.BuildAPKCurrent, false, 2)]
        private static void BuildAPKCurrent()
        {
            new Build(GetBuildSettings()).APK();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAABCurrent, false, 3)]
        private static void BuildAABCurrent()
        {
            new Build(GetBuildSettings()).AAB();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAPKAABCurrent, false, 4)]
        private static void BuildBothCurrent()
        {
            new Build(GetBuildSettings()).APK();
            new Build(GetBuildSettings()).AAB();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAPKIncrement, false, 21)]
        private static void BuildAPKIncrement()
        {
            var appVersion = new AppVersion().Increment();
            new BuildNumber(appVersion.Value()).EqualizeWithAppVersion();

            new Build(GetBuildSettings()).APK();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAABIncrement, false, 22)]
        private static void BuildAABIncrement()
        {
            var appVersion = new AppVersion().Increment();
            new BuildNumber(appVersion.Value()).EqualizeWithAppVersion();

            new Build(GetBuildSettings()).AAB();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAPKAABIncrement, false, 23)]
        private static void BuildBothIncrement()
        {
            var appVersion = new AppVersion().Increment();
            new BuildNumber(appVersion.Value()).EqualizeWithAppVersion();

            new Build(GetBuildSettings()).APK();
            new Build(GetBuildSettings()).AAB();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildSettings, false, 41)]
        private static void ShowBuildSettings()
        {
            BuildSettingsWindow.ShowWindow();
        }

        private static BuildSettings GetBuildSettings()
        {
            var buildSettings = new BuildSettings(FolderPaths.BuildSettings);

            if (buildSettings.Exists() == false)
            {
                throw new FileNotFoundException($"File does not exist: {FolderPaths.BuildSettings}");
            }

            if (buildSettings.Filled() == false)
            {
                BuildSettingsWindow.ShowWindow();
                throw new InvalidOperationException("Settings not set");
            }
            
            return buildSettings;
        }
    }
}
#endif