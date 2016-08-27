using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
	[TestFixture]
	internal class Solution_Tests
	{
		[TestCase(new []{1}, 1)]
		[TestCase(new []{1, 2, 3}, 2)]
		public void Test(int[] arr, int expectedMedian)
		{
			var res = Solution.FindTheMedian(arr);
			res.Should().Be(expectedMedian);
		}
	}
}