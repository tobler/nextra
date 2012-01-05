using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class LuhnAttributeBehavior
	{
        [Test]
        public void IsValid_ShouldReturnTrueForNullValue()
        {
            Assert.That(new LuhnAttribute().IsValid(null), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(new LuhnAttribute().IsValid(""), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForInvalidNumbers()
        {
            Assert.That(new LuhnAttribute().IsValid("7902237516"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForValidNumbers()
        {
            Assert.That(new LuhnAttribute().IsValid("7902237515"), Is.True);
        }
	}
}