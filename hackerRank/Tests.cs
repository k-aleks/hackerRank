using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
	[TestFixture]
	internal class Solution_Tests
	{
		[Test]
		public void Test_1()
		{
			var ladders = new Dictionary<int, int>
			{
				{32, 62},
				{42, 68},
				{12, 98}
			};
			var snakes = new Dictionary<int, int>
			{
				{95, 13},
				{97, 25},
				{93, 37},
				{79, 27},
				{75, 19},
				{49, 47},
				{67, 17},
			};
			var pathFinder = new Solution.ShortestPathFinder(ladders, snakes);
			var res = pathFinder.FindPath();

			res.Should().Be(3);
		}

		[Test]
		public void Test_2()
		{
			var ladders = new Dictionary<int, int>
			{
				{8,52},
				{6,80},
				{26,42},
				{2,72},
			};
			var snakes = new Dictionary<int, int>
			{
				{51,19},
				{39,11},
				{37,29},
				{81,3},
				{59,5},
				{79,23},
				{53,7},
				{43,33},
				{77,21},
			};
			var pathFinder = new Solution.ShortestPathFinder(ladders, snakes);
			var res = pathFinder.FindPath();

			res.Should().Be(5);
		}
	}
}