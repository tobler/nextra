using NExtra.Web.Security;
using NUnit.Framework;

namespace NExtra.Web.Tests.Security
{
    [TestFixture]
    public class Md5GeneratorBehavior
    {
        private FormsAuthenticationBasedMd5Generator _hashGenerator;


        [SetUp]
        public void SetUp()
        {
            _hashGenerator = new FormsAuthenticationBasedMd5Generator();
        }


        [Test]
        public void GenerateHashValue_ShouldGenerateHashValueWithCorrectLength()
        {
            Assert.That(_hashGenerator.GenerateHashValue("test string").Length, Is.EqualTo(32));
        }

        [Test]
        public void GenerateHashValue_ShouldGenerateCaseSensitiveHashValue()
        {
            Assert.That(_hashGenerator.GenerateHashValue("test string"), Is.EqualTo(_hashGenerator.GenerateHashValue("test string")));
            Assert.That(_hashGenerator.GenerateHashValue("test string"), Is.Not.EqualTo(_hashGenerator.GenerateHashValue("Test string")));
        }

		[Test]
        public void GenerateHashValue_ShouldHandleAnyObject()
        {
            Assert.That(_hashGenerator.GenerateHashValue(5), Is.EqualTo(_hashGenerator.GenerateHashValue("5")));
		}
    }
}