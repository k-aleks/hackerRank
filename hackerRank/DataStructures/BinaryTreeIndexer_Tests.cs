using System;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
    [TestFixture]
    internal class BinaryTreeIndexer_Tests
    {
        private readonly BinaryTreeIndexer indexer = new BinaryTreeIndexer();

        [TestCase(0, 1)]
        [TestCase(1, 3)]
        [TestCase(2, 5)]
        [TestCase(3, 7)]
        [TestCase(4, 9)]
        [TestCase(5, 11)]
        [TestCase(6, 13)]
        [TestCase(7, 15)]
        [TestCase(8, 17)]
        [TestCase(14, 29)]
        public void Test_GetLeftChildIndex(int parentIndex, int expected)
        {
            indexer.GetLeftChildIndex(parentIndex).Should().Be(expected);
        }

        [TestCase(0, 1)]
        [TestCase(1, 3)]
        [TestCase(1, 4)]
        [TestCase(2, 5)]
        [TestCase(2, 6)]
        [TestCase(3, 7)]
        [TestCase(3, 8)]
        [TestCase(4, 9)]
        [TestCase(4, 10)]
        [TestCase(5, 11)]
        [TestCase(5, 12)]
        [TestCase(6, 13)]
        [TestCase(6, 14)]
        [TestCase(7, 15)]
        [TestCase(7, 16)]
        [TestCase(8, 17)]
        [TestCase(8, 18)]
        public void Test_GetParentIndex(int expected, int childIndex)
        {
            indexer.GetParentIndex(childIndex).Should().Be(expected);
        }

        [Test]
        public void Test_Log2()
        {
            for (int i = 1; i < 100; i++)
            {
                indexer.LogTwo(i).Should().Be((int)Math.Log(i, 2));
            }
        }
    }
}