#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace TinyBuilder
{
    public class AppVersionIncrementer
    {
        public void Increment()
        {
            string[] versionParts = PlayerSettings.bundleVersion.Split('.');

            if (versionParts.Length != 3)
            {
                PlayerSettings.bundleVersion = "0.0.1";
                return;
            }

            int major = int.Parse(versionParts[0]);
            int minor = int.Parse(versionParts[1]);
            int patch = int.Parse(versionParts[2]);
            patch++;

            PlayerSettings.bundleVersion = $"{major}.{minor}.{patch}";

#if UNITY_ANDROID
            PlayerSettings.Android.bundleVersionCode = patch;
            Debug.Log("Bundle Version Code incremented to: " + PlayerSettings.bundleVersion);
#endif
        }
    }
}
#endif