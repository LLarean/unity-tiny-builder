using UnityEditor;
using UnityEngine;

namespace TinyBuilder
{
    public record BuildNumber
    {
        private readonly string _appVersion;

        public BuildNumber(string appVersion)
        {
            _appVersion = appVersion;
        }
        
        public int Value()
        {
#if UNITY_ANDROID
            return PlayerSettings.Android.bundleVersionCode;
#endif
            return 0;
        }

        public BuildNumber EqualizeWithAppVersion()
        {
            string[] versionParts = _appVersion.Split('.');
            
            int major = 0;
            int minor = 0;
            int patch = 1;
            
            if (versionParts.Length != 3)
            {
                Debug.LogWarning("Invalid version format");
            }
            else
            {
                major = int.Parse(versionParts[0]);
                minor = int.Parse(versionParts[1]);
                patch = int.Parse(versionParts[2]);
            }
            
#if UNITY_ANDROID
            PlayerSettings.Android.bundleVersionCode = patch;
            Debug.Log("Bundle Version Code has been changed to: " + PlayerSettings.bundleVersion);
#endif

            var appVersion = $"{major}.{minor}.{patch}";
            return new BuildNumber(appVersion);
        }
    }
}