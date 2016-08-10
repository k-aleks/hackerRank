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
		public void TestUnixTimeConverter()
		{
			var dt = Solution.UnixTimeStampToDateTime(1467720000);
			dt.Date.Should().Be(new DateTime(2016, 07, 05));

		}
	}
}