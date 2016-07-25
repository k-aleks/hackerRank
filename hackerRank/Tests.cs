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
		public void Test_1()
		{
			var res = Solution.getLockerDistanceGrid(3, 5, new[] {1}, new[] {1});
			for (int i = 0; i < res.Length; i++)
			{
				foreach (int r in res[i])
				{
					Console.Out.Write(r);
				}
				Console.Out.WriteLine("");
			}
//			res[0].Should().Equal(0, 1, 2);
//			res[1].Should().Equal(1,2,3);
//			res[2].Should().Equal(2,3,4);
//			res[3].Should().Equal(3,4,5);
//			res[4].Should().Equal(4,5,6);
		}

		[Test]
		public void Test_2()
		{
			var res = Solution.getLockerDistanceGrid(5, 7, new[] {2,4}, new[] {3,7});
			for (int i = 0; i < res.Length; i++)
			{
				foreach (int r in res[i])
				{
					Console.Out.Write(r);
				}
				Console.Out.WriteLine("");
			}
//			res[0].Should().Equal(3,2,3, 4,5);
//			res[1].Should().Equal(2,1,2,3,4);
//			res[2].Should().Equal(1,0,1,2,3);
//			res[3].Should().Equal(2,1,2,3,4);
//			res[4].Should().Equal(3,2,3,2,3);
//			res[5].Should().Equal(4,3,2,1,2);
//			res[6].Should().Equal(3,2,1,0,1);
		}
	}
}