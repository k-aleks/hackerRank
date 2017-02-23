using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
	[TestFixture]
	internal class Solution_Tests
	{

	}

    [TestFixture]
    public class AlarmSystem_Tests
    {
        [Test]
        public void CalculateAlarmsCount_ShouldCalculate_1()
        {
            int d = 5;
            int[] arr = new int[] {2, 3, 4, 2, 3, 6, 8, 4, 5};
            var res = new AlarmSystem().CalculateAlarmsCount(arr, d);

            res.Should().Be(2);

        }

        [Test]
        public void TestWithBigData()
        {
            int[] expenditures;
            int d;
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../testData/fraudsystem/input");
            using (var fileStream = new StreamReader(File.OpenRead(path)))
            {
                var firstLineArgs = fileStream.ReadLine().Split(' ');
                int n = Int32.Parse(firstLineArgs[0]);
                d = Int32.Parse(firstLineArgs[1]);

                var secondLineArgs = fileStream.ReadLine().Split(' ');
                expenditures = new int[secondLineArgs.Length];
                for (int i = 0; i < expenditures.Length; i++)
                {
                    expenditures[i] = int.Parse(secondLineArgs[i]);
                }
            }

            var res = new AlarmSystem().CalculateAlarmsCount(expenditures, d);

            res.Should().Be(926);
        }
    }

    [TestFixture]
    public class SortedList_Tests
    {
        [Test]
        public void Replace_ShouldCreateSortedList_1()
        {
            var list = new SortedList(new int[]{4,3,2,1});
            list.Replace(3, 5);

            list.Arr.Should().Equal(1, 2, 4, 5);
        }

        [Test]
        public void Replace_ShouldCreateSortedList_2()
        {
            var list = new SortedList(new int[]{4,3,2,1});
            list.Replace(4, 5);

            list.Arr.Should().Equal(1, 2, 3, 5);
        }


        [Test]
        public void Replace_ShouldCreateSortedList_3()
        {
            var list = new SortedList(new int[]{4,3,2,2});
            list.Replace(2, 1);

            list.Arr.Should().Equal(1, 2, 3, 4);
        }

        [TestCase(new int[]{1}, 1)]
        [TestCase(new int[]{1,2,3}, 2)]
        [TestCase(new int[]{1,2,3,4}, 2.5)]
        [TestCase(new int[]{2,2,2,2}, 2)]
        public void GetMedian_ShouldReturnMedian(int[] arr, double expectedMedian)
        {
            var list = new SortedList(arr);
            var res = list.GetMedian();

            res.Should().Be(expectedMedian);
        }
    }
}