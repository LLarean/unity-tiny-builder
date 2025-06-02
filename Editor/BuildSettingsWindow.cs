#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace TinyBuilder
{
    public class BuildSettingsWindow : EditorWindow
    {
        private static BuildSettings _settings;

        public static void ShowWindow()
        {
            LoadSettings();
            var window = GetWindow<BuildSettingsWindow>("Build Settings");
            window.minSize = new Vector2(400, 300);
        }

        private static void LoadSettings()
        {
            _settings = AssetDatabase.LoadAssetAtPath<BuildSettings>(FolderPaths.BuildSettings);

            if (_settings != null) return;
            
            _settings = CreateInstance<BuildSettings>();
            AssetDatabase.CreateAsset(_settings, FolderPaths.BuildSettings);
            AssetDatabase.SaveAssets();
        }

        private void OnGUI()
        {
            GUILayout.Space(10);
            
            _settings.ProjectName = EditorGUILayout.TextField("Project Name", _settings.ProjectName);
            
            _settings.Version = EditorGUILayout.TextField("Version", Application.version);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Android Settings", EditorStyles.boldLabel);
            _settings.KeystorePath = EditorGUILayout.TextField("Keystore Path", _settings.KeystorePath);
            
            if (GUILayout.Button("Select Keystore File", GUILayout.Height(20)))
            {
                string path = EditorUtility.OpenFilePanel("Select Keystore", "../", "keystore");
                if (!string.IsNullOrEmpty(path))
                {
                    _settings.KeystorePath = path;
                }
            }
            
            _settings.KeystorePassword = EditorGUILayout.PasswordField("Keystore Password", _settings.KeystorePassword);
            _settings.KeyaliasName = EditorGUILayout.TextField("Key Alias", _settings.KeyaliasName);
            _settings.KeyaliasPassword = EditorGUILayout.PasswordField("Alias Password", _settings.KeyaliasPassword);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Build Paths", EditorStyles.boldLabel);
            _settings.ApkOutputPath = EditorGUILayout.TextField("APK Output Path", _settings.ApkOutputPath);
            _settings.AabOutputPath = EditorGUILayout.TextField("AAB Output Path", _settings.AabOutputPath);

            EditorGUILayout.Space(20);
            if (GUILayout.Button("Save Settings", GUILayout.Height(30)))
            {
                SaveSettings();
                Close();
            }


        }

        private void SaveSettings()
        {
            EditorUtility.SetDirty(_settings);
            AssetDatabase.SaveAssets();
            
            FileNameParts.Main = $"{_settings.ProjectName}_{_settings.Version}";
            FolderPaths.APK = _settings.ApkOutputPath;
            FolderPaths.AAB = _settings.AabOutputPath;
            
            PlayerSettings.Android.keystoreName = _settings.KeystorePath;
            PlayerSettings.Android.keystorePass = _settings.KeystorePassword;
            PlayerSettings.Android.keyaliasName = _settings.KeyaliasName;
            PlayerSettings.Android.keyaliasPass = _settings.KeyaliasPassword;
        }
    }
}
#endif