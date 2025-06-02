#if UNITY_EDITOR
namespace TinyBuilder
{
    public abstract record MenuNames
    {
        /// <summary>
        /// The name for the main menu displayed in the top panel of Unity
        /// </summary>
        public const string Build = "Build";
        
        public const string BuildAPKCurrent = "/APK (Current Version)";
        public const string BuildAABCurrent = "/AAB (Current Version)";
        public const string BuildAPKAABCurrent = "/APK + AAB (Current Version)";
        
        public const string BuildAPKIncrement = "/APK (Increment Version)";
        public const string BuildAABIncrement = "/AAB (Increment Version)";
        public const string BuildAPKAABIncrement = "/APK + AAB (Increment Version)";
        
        public const string BuildSettings = "/Build Settings";
    }
}
#endif