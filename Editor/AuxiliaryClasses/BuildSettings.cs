#if UNITY_EDITOR
using UnityEngine;

namespace TinyBuilder
{
    public class BuildSettings : ScriptableObject
    {
        public string ProjectName = "MyGame";
        
        public string Version = Application.version;
        
        public string KeystorePath = "";
        public string KeystorePassword = "";
        public string KeyaliasName = "";
        public string KeyaliasPassword = "";
        
        public string ApkOutputPath = "Builds/APK";
        public string AabOutputPath = "Builds/AAB";
    }
}
#endif