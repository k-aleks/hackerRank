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
			var ar = new int[]{1};
			Solution.InsertionSort(ar);
			ar.Should().Equal(1);
		}

		[Test]
		public void Test_2()
		{
			var ar = new int[]{1, 2};
			Solution.InsertionSort(ar);
			ar.Should().Equal(1, 2);
		}

		[Test]
		public void Test_3()
		{
			var ar = new int[]{1,3,2};
			Solution.InsertionSort(ar);
			ar.Should().Equal(1, 2, 3);
		}

		[Test]
		public void Test_4()
		{
			var ar = new int[]{1, 1};
			Solution.InsertionSort(ar);
			ar.Should().Equal(1, 1);
		}

		[Test]
		public void Test_5()
		{
			var ar = new int[]{2, 1};
			Solution.InsertionSort(ar);
			ar.Should().Equal(1, 2);
		}

		[Test]
		public void Test_6()
		{
			var ar = new int[]{4, 5, 0, 3, 2, 1};
			Solution.InsertionSort(ar);
			ar.Should().Equal(0,1,2,3,4,5);
		}

	}
}