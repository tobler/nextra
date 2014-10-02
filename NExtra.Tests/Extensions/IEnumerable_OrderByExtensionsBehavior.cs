using System.Collections.Generic;
using System.Linq;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class IEnumerable_OrderByExtensionsBehavior
    {
        private List<KeyValuePair<string, int>> _collection;


        [SetUp]
        public void SetUp()
        {
            _collection = new List<KeyValuePair<string, int>> {
                new KeyValuePair<string, int>("DN", 5),
                new KeyValuePair<string, int>("SvD", 5),
                new KeyValuePair<string, int>("DN", 1),
                new KeyValuePair<string, int>("SvD", 1)
            };
        }


        [Test]
        public void OrderBy_ShouldApplyToCollection()
        {
            var original = _collection;
            var result = _collection.OrderBy("Key").ToList();

            Assert.That(result[0], Is.EqualTo(original[0]));
            Assert.That(result[1], Is.EqualTo(original[2]));
            Assert.That(result[2], Is.EqualTo(original[1]));
            Assert.That(result[3], Is.EqualTo(original[3]));
        }

        [Test]
        public void OrderBy_ShouldOverrideLastOrderBy()
        {
            var original = _collection.ToList();
            var result = _collection.OrderBy("Key").OrderBy("Value").ToList();

            Assert.That(result[0], Is.EqualTo(original[2]));
            Assert.That(result[1], Is.EqualTo(original[3]));
            Assert.That(result[2], Is.EqualTo(original[0]));
            Assert.That(result[3], Is.EqualTo(original[1]));
        }

        [Test]
        public void OrderByDescending_ShouldApplyToCollection()
        {
            var original = _collection.ToList();
            var result = _collection.OrderByDescending("Key").ToList();

            Assert.That(result[0], Is.EqualTo(original[1]));
            Assert.That(result[1], Is.EqualTo(original[3]));
            Assert.That(result[2], Is.EqualTo(original[0]));
            Assert.That(result[3], Is.EqualTo(original[2]));
        }

        [Test]
        public void OrderByDescending_ShouldOverrideLastOrderByDescending()
        {
            var original = _collection.ToList();
            var result = _collection.OrderByDescending("Key").OrderByDescending("Value").ToList();

            Assert.That(result[0], Is.EqualTo(original[1]));
            Assert.That(result[1], Is.EqualTo(original[0]));
            Assert.That(result[2], Is.EqualTo(original[3]));
            Assert.That(result[3], Is.EqualTo(original[2]));
        }
    }
}
