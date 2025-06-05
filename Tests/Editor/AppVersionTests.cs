#if UNITY_EDITOR
using NUnit.Framework;
using UnityEditor;

namespace TinyBuilder.Tests.Editor
{
    public class AppVersionTests
    {
        private string _expectedVersion;

        [SetUp]
        public void Setup()
        {
            _expectedVersion = PlayerSettings.bundleVersion;
            PlayerSettings.bundleVersion = "1.0.0";
        }

        [TearDown]
        public void Teardown()
        {
            PlayerSettings.bundleVersion = _expectedVersion;
        }
        
        [Test]
        [TestCase("0.0.1")]
        [TestCase("1.2.3")]
        public void Value_ReturnsCurrentBundleVersion(string expectedVersion)
        {
            PlayerSettings.bundleVersion = expectedVersion;
            var version = new AppVersion();

            Assert.AreEqual(expectedVersion, version.Value());
        }
        
        [Test]
        public void Increment_IncreasesPatchVersion()
        {
            PlayerSettings.bundleVersion = "1.2.3";
            var initialVersion = new AppVersion();
            var newVersion = initialVersion.Increment();
    
            Assert.AreEqual("1.2.4", newVersion.Value());
            Assert.AreEqual("1.2.4", PlayerSettings.bundleVersion);
        }
        
        [Test]
        public void Increment_FromZeroVersion_WorksCorrectly()
        {
            PlayerSettings.bundleVersion = "0.0.0";
            var version = new AppVersion().Increment();
    
            Assert.AreEqual("0.0.1", version.Value());
        }
        
        [Test]
        public void AppVersion_IsImmutable()
        {
            PlayerSettings.bundleVersion = "1.0.0";
            var version1 = new AppVersion();
            var version2 = version1.Increment();
    
            Assert.AreEqual("1.0.0", version1.Value());
            Assert.AreEqual("1.0.1", version2.Value());
        }
    }
}
#endif