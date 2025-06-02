#if UNITY_EDITOR
using UnityEngine;

namespace TinyBuilder
{
    public class BuildSettings : ScriptableObject
    {
        public string Prefix = "";
        public string ProjectName = "MyGame_";
        public bool HasVersion;
        public string Postfix = "";
        
        public string KeystorePath = "";
        public string KeystorePassword = "";
        public string KeyaliasName = "";
        public string KeyaliasPassword = "";
        
        public string ApkOutputPath = "";
        public string AabOutputPath = "";
    }
}
#endif