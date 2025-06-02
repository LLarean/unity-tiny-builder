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

        public bool HaveFile()
        {
            var buildSettings = AssetDatabase.LoadAssetAtPath<TinyBuilderSettings>(_buildSettingsPath);
            return buildSettings != null;
        }

        public string FileName()
        {
            var buildSettings = AssetDatabase.LoadAssetAtPath<TinyBuilderSettings>(_buildSettingsPath);
            return buildSettings.Prefix + buildSettings.ProjectName + Application.version + buildSettings.Postfix;
        }
        
        public string APKFilePath()
        {
            var buildSettings = AssetDatabase.LoadAssetAtPath<TinyBuilderSettings>(_buildSettingsPath);
            return buildSettings.APKOutputPath;
        }
        
        public string AABFilePath()
        {
            var buildSettings = AssetDatabase.LoadAssetAtPath<TinyBuilderSettings>(_buildSettingsPath);
            return buildSettings.AABOutputPath;
        }
    }
}
#endif