using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
	    int testCasesCount = GetTestCasesCount();

	    foreach (TestCase testCase in ReadTestCases(testCasesCount))
	    {
		    var result = HandleTestCase(testCase);
		    foreach (var i in result)
		    {
			    Console.Write(i + " ");
		    }
			Console.WriteLine();
	    }
    }

	private static List<TestCase> ReadTestCases(int testCasesCount)
	{
		var testCases = new List<TestCase>(testCasesCount);
		for (int i = 0; i < testCasesCount; i++)
		{
			var inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			testCases.Add(new TestCase(inputNumbers[0], inputNumbers[1]));
		}
		return testCases;
	}

	public static List<int> HandleTestCase(TestCase testCase)
	{
		if (testCase.K == 0)
		{
			return CreatePrimitiveresult(testCase);
		}
		var used = new int[testCase.N+1];
		var result = new int[testCase.N+1];
		int tail = testCase.N;
		while (tail>=1)
		{
			for (int i = 0; i < testCase.K && tail >= 1; i++)
			{
				if (!TryFillCell(testCase, tail, used, result))
					return new List<int>(){-1};
				tail--;
			}
			tail -= testCase.K;
		}
		int head = 1 + (testCase.N % testCase.K);
		while (head <= testCase.N)
		{
			for (int i = 0; i < testCase.K && head <= testCase.N; i++)
			{
				if (! TryFillCell(testCase, head, used, result))
					return new List<int>(){-1};
				head++;
			}
			head += testCase.K;
		}
		return result.Skip(1).ToList();
	}

	private static List<int> CreatePrimitiveresult(TestCase testCase)
	{
		var res = new List<int>(testCase.N);
		for (int i = 1; i <= testCase.N; i++)
		{
			res.Add(i);
		}
		return res;
	}

	private static bool TryFillCell(TestCase testCase, int position, int[] used, int[] result)
	{
		var cand = GetCandidates(position, testCase);
		if (TestCandidate(used, testCase, cand.Min))
		{
			result[position] = cand.Min;
			used[cand.Min] = 1;
			return true;
		}
		if (TestCandidate(used, testCase, cand.Max))
		{
			result[position] = cand.Max;
			used[cand.Max] = 1;
			return true;
		}
		return false;
	}

	private static bool TestCandidate(int[] used, TestCase testCase, int item)
	{
		return item >= 1 && item <= testCase.N && used[item] == 0;
	}

	private static int GetTestCasesCount()
	{
		return int.Parse(Console.ReadLine());
	}

	public static Candidates GetCandidates(int position, TestCase testCase)
	{
		var c1 = Math.Abs(position - testCase.K);
		var c2 = Math.Abs(position + testCase.K);
		return c1 < c2
			? new Candidates() {Min = c1, Max = c2}
			: new Candidates() {Min = c2, Max = c1};
	}

}

internal struct Candidates
{
	public int Min;
	public int Max;
}

internal class TestCase
{
	public TestCase(int n, int k)
	{
		N = n;
		K = k;
		CheckSum = GetArithmeticSequenceSum(1, n, n);
	}

	public int N { get; private set; }
	public int K { get; private set; }
	public int CheckSum { get; private set; }

	private static int GetArithmeticSequenceSum(int first, int last, int elementsCount)
	{
		return (elementsCount*(first + last))/2;
	}
}

