using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
    [TestFixture]
    internal class Solution_Tests
    {
    }

    [TestFixture]
    internal class BinaryTreeIndexer_Tests
    {
        private BinaryTreeIndexer indexer = new BinaryTreeIndexer();

        [TestCase(0, 1)]
        [TestCase(1, 3)]
        [TestCase(2, 5)]
        [TestCase(3, 7)]
        [TestCase(4, 9)]
        [TestCase(5, 11)]
        [TestCase(6, 13)]
        public void Test_GetLeftChildIndex(int parentIndex, int expected)
        {
            indexer.GetLeftChildIndex(parentIndex).Should().Be(expected);
        }

        [TestCase(0, 1)]
        [TestCase(1, 3)]
        [TestCase(2, 5)]
        [TestCase(3, 7)]
        [TestCase(3, 8)]
        [TestCase(4, 9)]
        [TestCase(4, 10)]
        [TestCase(5, 11)]
        [TestCase(5, 12)]
        [TestCase(6, 13)]
        [TestCase(6, 14)]
        public void Test_GetParentIndex(int expected, int childIndex)
        {
            indexer.GetParentIndex(childIndex).Should().Be(expected);
        }

    }









}