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
		var stack = new Stack<int>();
		var hashSet = new HashSet<int>();
		if (FindPermutation(stack, hashSet, 1, testCase))
		{
			return stack.Reverse().ToList();
		}
		return new List<int>() {-1};
	}

	private static bool FindPermutation(Stack<int> stack, HashSet<int> hashSet, int currentPosition, TestCase testCase)
	{
		if (currentPosition > testCase.N)
		{
			//TODO: more precise correctness checking with bit mask
			return stack.Sum() == testCase.CheckSum;
		}
		var candidates = GetCandidates(currentPosition, testCase);
		if (candidates.Min >= 1 && candidates.Min <= testCase.N && !hashSet.Contains(candidates.Min))
		{
			stack.Push(candidates.Min);
			hashSet.Add(candidates.Min);
			if (FindPermutation(stack, hashSet, currentPosition + 1, testCase))
				return true;
			hashSet.Remove(stack.Pop());
		}
		if (candidates.Max >= 1 && candidates.Max <= testCase.N && !hashSet.Contains(candidates.Max))
		{
			stack.Push(candidates.Max);
			hashSet.Add(candidates.Max);
			if (FindPermutation(stack, hashSet, currentPosition + 1, testCase))
				return true;
			hashSet.Remove(stack.Pop());
		}
		return false;
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