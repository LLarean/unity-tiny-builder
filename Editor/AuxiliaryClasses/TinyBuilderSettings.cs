#if UNITY_EDITOR
using UnityEngine;

namespace TinyBuilder
{
    public class TinyBuilderSettings : ScriptableObject
    {
        public string Prefix = "";
        public string ProjectName = "MyGame_";
        public string Postfix = "";
        
        public string KeystorePath = "";
        public string KeystorePassword = "";
        public string KeyaliasName = "";
        public string KeyaliasPassword = "";
        
        public string APKOutputPath = "C:/Builds/My-Game/Android/APK";
        public string AABOutputPath = "C:/Builds/My-Game/Android/AAB";
    }
}
#endif