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
        [TestCase(new [] {5, 8, 9, 8, 5}, 1, 2, 3, 4, 5)]
        [TestCase(new [] {12, 6, 15, 12, 6}, 6, 6, 5, 6, 6)]
        public void GetMaxRectangleRight_Test(int[] expectedResult, params int[] arr)
        {
            var res = Solution.GetMaxRectanglesRight(arr);
            res.Should().Equal(expectedResult);
        }

        [TestCase(new [] {1, 2, 3, 4, 5}, 1, 2, 3, 4, 5)]
        [TestCase(new [] {5, 8, 9, 8, 5}, 5, 4, 3, 2, 1)]
        [TestCase(new [] {6, 12, 15, 6, 12}, 6, 6, 5, 6, 6)]
        public void GetMaxRectangleLeft_Test(int[] expectedResult, params int[] arr)
        {
            var res = Solution.GetMaxRectanglesLeft(arr);
            res.Should().Equal(expectedResult);
        }

        [TestCase(9, 1, 2, 3, 4, 5)]
        [TestCase(24, 8, 3, 6, 9, 7, 4, 5, 8, 2)]
        [TestCase(24, 8, 3, 6, 9, 7, 4, 5, 8, 0, 2)]
        [TestCase(26152, 8979, 4570, 6436, 5083, 7780, 3269, 5400, 7579, 2324, 2116)]
        public void SomeTest(int expectedResult, params int[] arr)
        {
            var res = Solution.GetMaxRectangles(arr);
            res.Should().Be(expectedResult);
        }
    }










}