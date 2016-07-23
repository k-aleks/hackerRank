using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
	[TestFixture]
	class Solution_Tests
	{
		[TestCase(new []{1}, new [] {1}, TestName = "1")]
		[TestCase(new []{1, 2}, new [] {1, 2}, TestName = "1 2")]
		[TestCase(new []{2, 1}, new [] {1, 2}, TestName = "2 1")]
		[TestCase(new []{2, 2}, new [] {2, 2}, TestName = "2 2")]
		[TestCase(new []{3, 2, 1}, new [] {1, 2, 3}, TestName = "3 2 1")]
		[TestCase(new []{1, 3, 9, 8, 2, 7, 5}, new [] {1, 2, 3, 5, 7, 8, 9}, TestName = "1 3 9 8 2 7 5")]
		public void Test(int[] arr, int[] expected)
		{
			Solution.QuickSort(arr);

			arr.Should().Equal(expected);
		}
	}
}
