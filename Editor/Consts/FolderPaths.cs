#if UNITY_EDITOR
namespace TinyBuilder
{
    public abstract class FolderPaths
    {
        public const string AssetBundle = "Assets/ServerData/Android";
        public const string Bundle = "../ServerData/Android";
        
        public static string APK = "C:/Builds/My-Game/Android/APK";
        public static string AAB = "C:/Builds/My-Game/Android/AAB";
        
        public const string BuildSettings = "Assets/Editor/BuildSettings.asset";
    }
}
#endif