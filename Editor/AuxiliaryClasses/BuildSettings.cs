#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace TinyBuilder
{
    public record BuildSettings
    {
        private readonly string _buildSettingsPath;

        public BuildSettings(string buildSettingsPath)
        {
            _buildSettingsPath = buildSettingsPath;
        }

        public bool Exists()
        {
            var buildSettings = AssetDatabase.LoadAssetAtPath<TinyBuilderSettings>(_buildSettingsPath);
            return buildSettings != null;
        }
        
        public string FileNameAPK()
        {
            var buildSettings = AssetDatabase.LoadAssetAtPath<TinyBuilderSettings>(_buildSettingsPath);
            return buildSettings.Prefix + buildSettings.ProjectName + Application.version + buildSettings.Postfix + FileNameParts.ApkExtension;
        }
        
        public string FileNameAAB()
        {
            var buildSettings = AssetDatabase.LoadAssetAtPath<TinyBuilderSettings>(_buildSettingsPath);
            return buildSettings.Prefix + buildSettings.ProjectName + Application.version + buildSettings.Postfix + FileNameParts.AabExtension;
        }
        
        public string DirectoryAPK()
        {
            var buildSettings = AssetDatabase.LoadAssetAtPath<TinyBuilderSettings>(_buildSettingsPath);
            return buildSettings.APKOutputPath;
        }
        
        public string DirectoryAAB()
        {
            var buildSettings = AssetDatabase.LoadAssetAtPath<TinyBuilderSettings>(_buildSettingsPath);
            return buildSettings.AABOutputPath;
        }
        
        public bool Filled()
        {
            var buildSettings = AssetDatabase.LoadAssetAtPath<TinyBuilderSettings>(_buildSettingsPath);

            if (PlayerSettings.Android.keystorePass != buildSettings.KeystorePassword) return false;
            if (PlayerSettings.Android.keystoreName != buildSettings.KeystorePath)return false;
            if (PlayerSettings.Android.keyaliasName != buildSettings.KeyaliasName)return false;
            if (PlayerSettings.Android.keyaliasPass != buildSettings.KeyaliasPassword)return false;
            
            return true;
        }

    }
}
#endif