using System;
using NUnit.Framework;

namespace TinyBuilder.Tests.Editor
{
    public class SemanticVersionTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void Major_DifferentNumbers_AreEqual(int major)
        {
            var semanticVersion = new SemanticVersion($"{major}.2.3");
            Assert.AreEqual(semanticVersion.Major(), major);
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void Minor_DifferentNumbers_AreEqual(int minor)
        {
            var semanticVersion = new SemanticVersion($"1.{minor}.3");
            Assert.AreEqual(semanticVersion.Minor(), minor);
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void Patch_DifferentNumbers_AreEqual(int patch)
        {
            var semanticVersion = new SemanticVersion($"1.2.{patch}");
            Assert.AreEqual(semanticVersion.Patch(), patch);
        }
        
        [Test]
        public void Major_CharInsteadNumber_FormatException()
        {
            var semanticVersion = new SemanticVersion("s.2.3");
            Assert.Throws<FormatException>(() => semanticVersion.Major());
        }
        
        [Test]
        public void Minor_CharInsteadNumber_FormatException()
        {
            var semanticVersion = new SemanticVersion("1.s.3");
            Assert.Throws<FormatException>(() => semanticVersion.Minor());
        }
        
        [Test]
        public void Patch_CharInsteadNumber_FormatException()
        {
            var semanticVersion = new SemanticVersion("1.2.s");
            Assert.Throws<FormatException>(() => semanticVersion.Patch());
        }
        
        [Test]
        [TestCase("1")]
        [TestCase("1.2")]
        [TestCase("1.2.3.4")]
        [TestCase("1_2_3")]
        [TestCase("1/2/3")]
        public void Major_IncorrectVersionFormat_FormatException(string version)
        {
            var semanticVersion = new SemanticVersion(version);
            Assert.Throws<FormatException>(() => semanticVersion.Major());
        }
        
        [Test]
        [TestCase("1")]
        [TestCase("1.2")]
        [TestCase("1.2.3.4")]
        [TestCase("1_2_3")]
        [TestCase("1/2/3")]
        public void Minor_IncorrectVersionFormat_FormatException(string version)
        {
            var semanticVersion = new SemanticVersion(version);
            Assert.Throws<FormatException>(() => semanticVersion.Minor());
        }
        
        [Test]
        [TestCase("1")]
        [TestCase("1.2")]
        [TestCase("1.2.3.4")]
        [TestCase("1_2_3")]
        [TestCase("1/2/3")]
        public void Patch_IncorrectVersionFormat_FormatException(string version)
        {
            var semanticVersion = new SemanticVersion(version);
            Assert.Throws<FormatException>(() => semanticVersion.Patch());
        }
    }
}