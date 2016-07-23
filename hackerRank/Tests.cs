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
		[TestCase(0, new int[] {1})]
		[TestCase(1, 1, 1, 1)]
		[TestCase(3, 1, 1, 2, 3, 2, 1, 1)]
		[TestCase(2, 1, 4, 2, 1, 1, 1, 2)]
		[TestCase(-1, 1, 4, 1, 1, 1, 2)]
		public void Test(int expectedMid, params int[] arr)
		{
			var res = new Solution.MidFinder().FindMid(arr);

			res.Should().Be(expectedMid);
		}
	}
}
