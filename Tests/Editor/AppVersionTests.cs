using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine.TestTools;

namespace TinyBuilder.Tests
{
    public class AppVersionTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            var bundleVersion = PlayerSettings.bundleVersion;
            
            string[] versionParts = bundleVersion.Split('.');

            if (versionParts.Length != 3)
            {
                PlayerSettings.bundleVersion = "0.0.1";
            }

            int major = int.Parse(versionParts[0]);
            int minor = int.Parse(versionParts[1]);
            int patch = int.Parse(versionParts[2]);
            patch++;
            
            AppVersion version = new AppVersion(bundleVersion);
        }
    }
}
