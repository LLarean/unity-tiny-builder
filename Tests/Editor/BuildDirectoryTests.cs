#if UNITY_EDITOR
using System.IO;
using NUnit.Framework;

namespace TinyBuilder.Tests.Editor
{
    public class BuildDirectoryTests
    {
        private string _testFolderPath;

        [SetUp]
        public void Setup()
        {
            _testFolderPath = Path.Combine(Path.GetTempPath(), "TestBuildDir");
            
            if (Directory.Exists(_testFolderPath))
            {
                Directory.Delete(_testFolderPath, true);
            }
        }

        [TearDown]
        public void Teardown()
        {
            if (Directory.Exists(_testFolderPath))
            {
                Directory.Delete(_testFolderPath, true);
            }
        }

        [Test]
        public void Create_WhenDirectoryNotExists_CreatesDirectory()
        {
            var buildDir = new BuildDirectory(_testFolderPath);
            buildDir.Create();
            
            Assert.IsTrue(Directory.Exists(_testFolderPath));
        }

        [Test]
        public void Create_WhenDirectoryExists_DoesNotThrow()
        {
            Directory.CreateDirectory(_testFolderPath);
            var buildDir = new BuildDirectory(_testFolderPath);
            
            Assert.DoesNotThrow(() => buildDir.Create());
        }
    }
}
#endif