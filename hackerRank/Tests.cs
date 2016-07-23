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
		[TestCase(2, 1, 2, 1)]
		[TestCase(3, 0, 1, 2, 3)]
		[TestCase(3, 2, new []{-1})]
		[TestCase(5, 1, new []{-1})]
		[TestCase(5, 2, new []{1, 4, 5, 2, 3} )]
		[TestCase(5, 3, new []{-1})]
		[TestCase(5, 4, new []{-1})]
		[TestCase(5, 4, new []{-1})]
		public void HandleTestCase(int n, int k, params int[] expectedResult)
		{
			var testCase = new TestCase(n, k);

			List<int> result = Solution.HandleTestCase(testCase);

			result.Should().Equal(expectedResult);
		}
	}
}
