#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace TinyBuilder
{
    public abstract class MainMenu
    {
        [MenuItem(MenuNames.Build + MenuNames.BuildAPKCurrent, false, 2)]
        private static void BuildAPKCurrent()
        {
            new Builder().BuildAPK();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAABCurrent, false, 3)]
        private static void BuildAABCurrent()
        {
            new Builder().BuildAAB();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAPKAABCurrent, false, 4)]
        private static void BuildBothCurrent()
        {
            new Builder().BuildAPK();
            new Builder().BuildAAB();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAPKIncrement, false, 21)]
        private static void BuildAPKIncrement()
        {
            var appVersion = new AppVersion(Application.version).Increment();
            new BuildNumber(appVersion.Value()).EqualizeWithAppVersion();

            new Builder().BuildAPK();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAABIncrement, false, 22)]
        private static void BuildAABIncrement()
        {
            var appVersion = new AppVersion(Application.version).Increment();
            new BuildNumber(appVersion.Value()).EqualizeWithAppVersion();

            new Builder().BuildAAB();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildAPKAABIncrement, false, 23)]
        private static void BuildBothIncrement()
        {
            var appVersion = new AppVersion(Application.version).Increment();
            new BuildNumber(appVersion.Value()).EqualizeWithAppVersion();

            new Builder().BuildAPK();
            new Builder().BuildAAB();
        }

        [MenuItem(MenuNames.Build + MenuNames.BuildSettings, false, 41)]
        private static void ShowBuildSettings()
        {
            BuildSettingsWindow.ShowWindow();
        }
    }
}
#endif