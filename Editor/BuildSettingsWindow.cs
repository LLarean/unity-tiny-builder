#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace TinyBuilder
{
    public class BuildSettingsWindow : EditorWindow
    {
        private static BuildSettings _buildSettings;

        public static void ShowWindow()
        {
            LoadSettings();
            var window = GetWindow<BuildSettingsWindow>("Build Settings");
            window.minSize = new Vector2(400, 300);
        }

        private static void LoadSettings()
        {
            _buildSettings = AssetDatabase.LoadAssetAtPath<BuildSettings>(FolderPaths.BuildSettings);

            if (_buildSettings != null) return;
            
            _buildSettings = CreateInstance<BuildSettings>();
            _buildSettings.ProjectName = Application.productName;

            AssetDatabase.CreateAsset(_buildSettings, FolderPaths.BuildSettings);
            AssetDatabase.SaveAssets();
        }

        private void OnGUI()
        {
            GUILayout.Space(10);
            
            _buildSettings.Prefix = EditorGUILayout.TextField("Prefix", _buildSettings.Prefix);
            _buildSettings.ProjectName = EditorGUILayout.TextField("Project Name", _buildSettings.ProjectName);
            _buildSettings.HasVersion = EditorGUILayout.Toggle("Has Version", _buildSettings.HasVersion);
            _buildSettings.Postfix = EditorGUILayout.TextField("Postfix", _buildSettings.Postfix);
            
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Keystore Settings", EditorStyles.boldLabel);
            _buildSettings.KeystorePath = EditorGUILayout.TextField("Keystore Path", _buildSettings.KeystorePath);
            
            if (GUILayout.Button("Select Keystore File", GUILayout.Height(20)))
            {
                string path = EditorUtility.OpenFilePanel("Select Keystore", "../", "keystore");
                if (!string.IsNullOrEmpty(path))
                {
                    _buildSettings.KeystorePath = path;
                }
            }
            
            _buildSettings.KeystorePassword = EditorGUILayout.PasswordField("Keystore Password", _buildSettings.KeystorePassword);
            _buildSettings.KeyaliasName = EditorGUILayout.TextField("Key Alias", _buildSettings.KeyaliasName);
            _buildSettings.KeyaliasPassword = EditorGUILayout.PasswordField("Alias Password", _buildSettings.KeyaliasPassword);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Build Paths", EditorStyles.boldLabel);
            _buildSettings.ApkOutputPath = EditorGUILayout.TextField("APK Output Path", _buildSettings.ApkOutputPath);
            _buildSettings.AabOutputPath = EditorGUILayout.TextField("AAB Output Path", _buildSettings.AabOutputPath);

            EditorGUILayout.Space(20);

            if (GUILayout.Button("Save Settings", GUILayout.Height(30)))
            {
                SaveSettings();
                Close();
            }
        }

        private void SaveSettings()
        {
            EditorUtility.SetDirty(_buildSettings);
            AssetDatabase.SaveAssets();
            
            FolderPaths.APK = _buildSettings.ApkOutputPath;
            FolderPaths.AAB = _buildSettings.AabOutputPath;
            
            PlayerSettings.Android.keystoreName = _buildSettings.KeystorePath;
            PlayerSettings.Android.keystorePass = _buildSettings.KeystorePassword;
            PlayerSettings.Android.keyaliasName = _buildSettings.KeyaliasName;
            PlayerSettings.Android.keyaliasPass = _buildSettings.KeyaliasPassword;
        }
    }
}
#endif