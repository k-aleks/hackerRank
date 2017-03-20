using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
    [TestFixture]
    internal class IntReader_Tests
    {
        [Test]
        public void Test_1()
        {
            var reader = new IntReader();
            reader.StartNew("123");
            reader.ReadNext().Should().Be(123);
        }

        [Test]
        public void Test_2()
        {
            var reader = new IntReader();
            reader.StartNew("123 34 1");
            reader.ReadNext().Should().Be(123);
            reader.ReadNext().Should().Be(34);
            reader.ReadNext().Should().Be(1);
        }
    }
}