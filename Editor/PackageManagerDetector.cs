#if UNITY_EDITOR
using UnityEditor;

namespace TinyBuilder
{
    [InitializeOnLoad]
    public static class PackageManagerDetector
    {
        static PackageManagerDetector()
        {
            EditorApplication.delayCall += CheckFirstInstall;
        }

        private static void CheckFirstInstall()
        {
            string key = "tiny_builder_package_installed";
            
            if (EditorPrefs.HasKey(key) == false)
            {
                EditorPrefs.SetBool(key, true);
                BuildSettingsWindow.ShowWindow();
            }
        }
    }
}
#endif