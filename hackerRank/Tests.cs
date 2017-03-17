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
    internal class MinHeap_Tests
    {
        [Test]
        public void Test()
        {
            var heap = new MinHeap();

            heap.Add(5);
            heap.GetMin().Should().Be(5);

            heap.Add(10);
            heap.GetMin().Should().Be(5);

            heap.Delete(5);
            heap.GetMin().Should().Be(10);

            heap.Add(5);
            heap.GetMin().Should().Be(5);

            heap.Add(4);
            heap.Add(6);
            heap.Add(2);
            heap.GetMin().Should().Be(2);
        }

        [Test]
        public void Test_DeleteAll()
        {
            var heap = new MinHeap();

            heap.Add(5);
            heap.Add(10);
            heap.GetMin().Should().Be(5);

            heap.Delete(5);
            heap.Delete(10);

            heap.Add(5);
            heap.Add(10);
            heap.GetMin().Should().Be(5);
        }

        [Test]
        public void Test_NegativeNumbers()
        {
            var heap = new MinHeap();

            heap.Add(5);
            heap.Add(10);
            heap.Add(-10);
            heap.GetMin().Should().Be(-10);

            heap.Add(6);
            heap.Add(11);
            heap.GetMin().Should().Be(-10);
        }

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