using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using FluentAssertions;
using NUnit.Framework;

class Solution
{
    static void Main(String[] args)
    {
        int arraySize = 0;
        int rotatesCount = 0;
        int queriesCount = 0;
        ParseFirstLineArguments(out arraySize, out rotatesCount, out queriesCount, Console.ReadLine());

        LinkedList<string> arr = ParseArray(Console.ReadLine());

        RotateArray(arr, rotatesCount);

        foreach (var queryResult in PerformQueries(arr, ReadQueries(queriesCount)))
        {
            Console.WriteLine(queryResult);
        }
    }

    public static IEnumerable<string> PerformQueries(LinkedList<string> list, IEnumerable<int> queriesEnum)
    {
        var queries = queriesEnum.ToArray();
        Array.Sort(queries);

        int currentQueryIndex = 0;
        int currentElementIndex = 0;

        foreach (var number in list)
        {
            if (currentQueryIndex >= queries.Length)
                yield break;
            if (queries[currentQueryIndex] == currentElementIndex++)
            {
                int nextQuery;
                int prevQuery;
                do
                {
                    nextQuery = currentQueryIndex >= queries.Length - 1 ? -1 : queries[currentQueryIndex + 1];
                    prevQuery = queries[currentQueryIndex];
                    currentQueryIndex++;
                    yield return number;
                } while (nextQuery == prevQuery);

            }
        }
    }

    private static IEnumerable<int> ReadQueries(int queriesCount)
    {
        for (int i = 0; i < queriesCount; i++)
        {
            yield return Int32.Parse(Console.ReadLine());
        }
    }

    public static void RotateArray(LinkedList<string> arr, int rotatesCount)
    {
        for (int i = 0; i < rotatesCount; i++)
        {
            RotateArray(arr);
        }
    }

    public static void RotateArray(LinkedList<string> arr)
    {
        var last = arr.Last;
        arr.RemoveLast();
        arr.AddFirst(last.Value);
    }

    private static LinkedList<string> ParseArray(string input)
    {
        return new LinkedList<string>(input.Split(' '));
    }

    public static void ParseFirstLineArguments(out int arraySize, out int rotatesCount, out int queriesCount, string input)
    {
        var parts = input.Split(' ');
        arraySize = Int32.Parse(parts[0]);
        rotatesCount = Int32.Parse(parts[1]);
        queriesCount = Int32.Parse(parts[2]);
    }
}

[TestFixture]
public class Tests
{
    [Test]
    public void ParseFirstLineArguments()
    {
        int arraySize, rotatesCount, queriesCount;
        Solution.ParseFirstLineArguments(out arraySize, out rotatesCount, out queriesCount, "1 2 3");

        arraySize.Should().Be(1);
        rotatesCount.Should().Be(2);
        queriesCount.Should().Be(3);
    }

    [Test]
    public void RotateArray()
    {
        var arr = new LinkedList<string>(new string[] {"1","2","3"});
        Solution.RotateArray(arr);

        arr.Should().Equal("3", "1", "2");
    }

    [Test]
    public void RotateArrayTwoTimes()
    {
        var arr = new LinkedList<string>(new string[] {"1","2","3"});
        Solution.RotateArray(arr, 2);

        arr.Should().Equal("2", "3", "1");
    }

    [Test]
    public void RotateArrayThreeTimes()
    {
        var arr = new LinkedList<string>(new string[] {"1","2","3"});
        Solution.RotateArray(arr, 3);

        arr.Should().Equal("1", "2", "3");
    }

    [Test]
    public void PerformQueries1()
    {
        PerformQueries(new string[] {"1", "2", "3", "4"}, new int[] {0, 1, 2, 3}, new string[] {"1", "2", "3", "4"});
        PerformQueries(new string[] {"1", "2", "3", "4"}, new int[] {3, 2, 1, 0}, new string[] {"1", "2", "3", "4"});
        PerformQueries(new string[] {"1", "2", "3", "4"}, new int[] {3, 2, 1, 0}, new string[] {"1", "2", "3", "4"});
        PerformQueries(new string[] {"1", "2", "3", "4"}, new int[] {3, 3, 2, 2, 1, 1, 0, 0}, new string[] {"1", "1", "2","2", "3", "3", "4", "4"});
        PerformQueries(new string[] {"1", "2", "3", "4"}, new int[] {1, 2}, new string[] {"2", "3"});
        PerformQueries(new string[] {"1", "2", "3", "4"}, new int[] {0, 1}, new string[] {"1", "2"});
        PerformQueries(new string[] {"1", "2", "3", "4"}, new int[] {2, 3}, new string[] {"3", "4"});
        return;
    }

    public void PerformQueries(string[] list, int[] queries, string[] expectedResult)
    {
        var result = Solution.PerformQueries(new LinkedList<string>(list), queries).ToArray();
        result.Should().Equal(expectedResult);
    }


}