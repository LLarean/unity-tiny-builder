#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace TinyBuilder
{
    public class BuildSettingsWindow : EditorWindow
    {
        private static TinyBuilderSettings _tinyBuilderSettings;

        public static void ShowWindow()
        {
            LoadSettings();
            var window = GetWindow<BuildSettingsWindow>("Build Settings");
            window.minSize = new Vector2(400, 300);
        }

        private static void LoadSettings()
        {
            _tinyBuilderSettings = AssetDatabase.LoadAssetAtPath<TinyBuilderSettings>(FolderPaths.BuildSettings);

            if (_tinyBuilderSettings != null) return;
            
            _tinyBuilderSettings = CreateInstance<TinyBuilderSettings>();
            _tinyBuilderSettings.ProjectName = Application.productName;

            AssetDatabase.CreateAsset(_tinyBuilderSettings, FolderPaths.BuildSettings);
            AssetDatabase.SaveAssets();
        }

        private void OnGUI()
        {
            GUILayout.Space(10);
            
            _tinyBuilderSettings.Prefix = EditorGUILayout.TextField("Prefix", _tinyBuilderSettings.Prefix);
            _tinyBuilderSettings.ProjectName = EditorGUILayout.TextField("Project Name", _tinyBuilderSettings.ProjectName);
            _tinyBuilderSettings.Postfix = EditorGUILayout.TextField("Postfix", _tinyBuilderSettings.Postfix);
            
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Keystore Settings", EditorStyles.boldLabel);
            _tinyBuilderSettings.KeystorePath = EditorGUILayout.TextField("Keystore Path", _tinyBuilderSettings.KeystorePath);
            
            if (GUILayout.Button("Select Keystore File", GUILayout.Height(20)))
            {
                string path = EditorUtility.OpenFilePanel("Select Keystore", "../", "keystore");
                if (!string.IsNullOrEmpty(path))
                {
                    _tinyBuilderSettings.KeystorePath = path;
                }
            }
            
            _tinyBuilderSettings.KeystorePassword = EditorGUILayout.PasswordField("Keystore Password", _tinyBuilderSettings.KeystorePassword);
            _tinyBuilderSettings.KeyaliasName = EditorGUILayout.TextField("Key Alias", _tinyBuilderSettings.KeyaliasName);
            _tinyBuilderSettings.KeyaliasPassword = EditorGUILayout.PasswordField("Alias Password", _tinyBuilderSettings.KeyaliasPassword);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Build Paths", EditorStyles.boldLabel);
            _tinyBuilderSettings.APKOutputPath = EditorGUILayout.TextField("APK Output Path", _tinyBuilderSettings.APKOutputPath);
            _tinyBuilderSettings.AABOutputPath = EditorGUILayout.TextField("AAB Output Path", _tinyBuilderSettings.AABOutputPath);

            EditorGUILayout.Space(20);

            if (GUILayout.Button("Save Settings", GUILayout.Height(30)))
            {
                SaveSettings();
                Close();
            }
        }

        private void SaveSettings()
        {
            EditorUtility.SetDirty(_tinyBuilderSettings);
            AssetDatabase.SaveAssets();
            
            FolderPaths.APK = _tinyBuilderSettings.APKOutputPath;
            FolderPaths.AAB = _tinyBuilderSettings.AABOutputPath;
            
            PlayerSettings.Android.keystoreName = _tinyBuilderSettings.KeystorePath;
            PlayerSettings.Android.keystorePass = _tinyBuilderSettings.KeystorePassword;
            PlayerSettings.Android.keyaliasName = _tinyBuilderSettings.KeyaliasName;
            PlayerSettings.Android.keyaliasPass = _tinyBuilderSettings.KeyaliasPassword;
        }
    }
}
#endif