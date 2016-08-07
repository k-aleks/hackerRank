using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
	[TestFixture]
	internal class Solution_Tests
	{
		[TestCase("abab", new int[]{4,0,2,0})]
		[TestCase("ababa", new int[]{5,0,3,0,1})]
		[TestCase("aaabbb", new int[]{6,2,1,0,0,0})]
		[TestCase("ababaa", new int[] {6,0,3,0, 1,1})]
		[TestCase("", new int[] {})]
		[TestCase("a", new int[] {1})]
		[TestCase("aa", new int[] {2,1})]
		[TestCase("aaa", new int[] {3,2,1})]
		public void Test(string s, int[] expectedResult)
		{
			var res = Solution.GetZFunction(s);
			res.Should().Equal(expectedResult);
		}
	}
}