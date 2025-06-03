#if UNITY_EDITOR
using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;

namespace TinyBuilder
{
    public record BuildDirectory
    {
        private readonly string _folderPath;

        public BuildDirectory(string folderPath)
        {
            _folderPath = folderPath;
        }
        
        public void Create()
        {
            if (Directory.Exists(_folderPath) == false)
            {
                Directory.CreateDirectory(_folderPath);
                Debug.Log("The directory has been created: " + _folderPath);
            }
            else
            {
                Debug.Log("The directory of the assembly: " + _folderPath);
            }
        }

        public void Open()
        {
            string normalizedPath = _folderPath.Replace("/", "\\");

            if (Directory.Exists(normalizedPath) == true)
            {
                Process.Start("explorer.exe", normalizedPath);
                Debug.Log("Opened Explorer at: " + normalizedPath);
            }
            else
            {
                throw new DirectoryNotFoundException($"Folder does not exist: {normalizedPath}");
            }
        }
    }
}
#endif