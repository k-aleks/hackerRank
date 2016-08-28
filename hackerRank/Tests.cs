using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
	[TestFixture]
	internal class Solution_Tests
	{
		[TestCase(new[] {2, 1, 3, 1, 2}, 4)]
		[TestCase(new int[] {}, 0)]
		[TestCase(new[] {1}, 0)]
		[TestCase(new[] {1, 1, 2, 2, 3, 3, 5, 5, 7, 7, 9, 9}, 0)]
		[TestCase(new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}, 45)]
		public void Test(int[] arr, int expectedShifts)
		{
			long shifts = MergeSort.Sort(arr);
			arr.Should().BeInAscendingOrder();
			shifts.Should().Be(expectedShifts);
		}

	
	}
}