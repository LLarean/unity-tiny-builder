#if UNITY_EDITOR
using System.IO;
using UnityEngine;

namespace TinyBuilder
{
    public class AssetBundleCleaner
    {
        public void CleanAssetBundleFolder(string folderPath)
        {
            var dataPath = Application.dataPath;
            
            string normalizedDataPath = dataPath.Replace("/", "\\");
            string normalizedFolderPath = folderPath.Replace("/", "\\");
            string bundlesPath = Path.Combine(normalizedDataPath, normalizedFolderPath);
            
            if (Directory.Exists(bundlesPath) == true)
            {
                foreach (var file in Directory.GetFiles(bundlesPath))
                {
                    File.Delete(file);
                }

                Debug.Log("Cleaned Asset Bundle folder: " + bundlesPath);
            }
            else
            {
                Debug.LogWarning("Asset Bundle folder not found: " + bundlesPath);
            }
        }
    }
}
#endif