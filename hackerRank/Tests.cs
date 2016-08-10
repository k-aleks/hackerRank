using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
	[TestFixture]
	internal class Solution_Tests
	{
		[Test]
		public void Test()
		{
			var res = Solution.CalcWaysCount(3, 4, 2);
			res.Should().Be(24);
		}
	}
}