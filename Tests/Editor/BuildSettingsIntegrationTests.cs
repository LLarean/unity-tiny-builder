#if UNITY_EDITOR
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace TinyBuilder.Tests.Editor
{
    public class BuildSettingsIntegrationTests
    {
        private const string TEST_ASSET_PATH = "Assets/TinyBuilderSettings_Test.asset";
        
        private const string Prefix = "Prefix_";
        private const string ProjectName = "ProjectName";
        private const string Postfix = "_postfix";

        private const string APKOutputPath = "C:/Builds/My-Game/Android/APK";
        private const string AABOutputPath = "C:/Builds/My-Game/Android/AAB";
        
        [SetUp]
        public void Setup()
        {
            var settings = ScriptableObject.CreateInstance<TinyBuilderSettings>();
            settings.Prefix = Prefix;
            settings.ProjectName = ProjectName;
            settings.Postfix = Postfix;
            settings.APKOutputPath = APKOutputPath;
            settings.AABOutputPath = AABOutputPath;
            
            AssetDatabase.CreateAsset(settings, TEST_ASSET_PATH);
            
            AssetDatabase.SaveAssets();
        }

        [TearDown]
        public void Teardown()
        {
            AssetDatabase.DeleteAsset(TEST_ASSET_PATH);
        }

        [Test]
        public void Exists_WithRealAsset_ReturnsTrue()
        {
            var buildSettings = new BuildSettings(TEST_ASSET_PATH);
            bool result = buildSettings.Exists();
            Assert.IsTrue(result);
        }
        
        [Test]
        public void FileNameAPK_WithRealAsset_IsNotNull()
        {
            var buildSettings = new BuildSettings(TEST_ASSET_PATH);
            string fileNameAPK = buildSettings.FileNameAPK();
            Assert.IsTrue(fileNameAPK != null);
        }
        
        [Test]
        public void FileNameAAB_WithRealAsset_IsNotNull()
        {
            var buildSettings = new BuildSettings(TEST_ASSET_PATH);
            string fileNameAAB = buildSettings.FileNameAAB();
            Assert.IsTrue(fileNameAAB != null);
        }
        
        [Test]
        public void DirectoryAPK_WithRealAsset_AreEqual()
        {
            var buildSettings = new BuildSettings(TEST_ASSET_PATH);
            string fileNameAPK = buildSettings.DirectoryAPK();
            Assert.AreEqual(fileNameAPK, APKOutputPath);
        }
        
        
        [Test]
        public void DirectoryAAB_WithRealAsset_AreEqual()
        {
            var buildSettings = new BuildSettings(TEST_ASSET_PATH);
            string fileNameAAB = buildSettings.DirectoryAAB();
            Assert.AreEqual(fileNameAAB, AABOutputPath);
        }
    }
}
#endif