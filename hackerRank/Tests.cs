using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
	[TestFixture]
	internal class Solution_Tests
	{
		[TestCase("hello", "world", true)]
		[TestCase("hi", "world", false)]
		public void Test(string line1, string line2, bool expected)
		{
			var res = Solution.FindIntro(line1, line2);

			res.Should().Be(expected);

		}
	}
}