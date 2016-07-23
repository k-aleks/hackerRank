using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		var stack = new Stack<int>(10000);
		var hashSet = new int[10000];
		if (FindPermutation(stack, hashSet, 1, testCase))
		{
			return stack.Reverse().ToList();
		}
		return new List<int>() {-1};
	}

	private static bool FindPermutation(Stack<int> stack, int[] hashSet, int currentPosition, TestCase testCase)
	{
		if (currentPosition > testCase.N)
		{
			//TODO: more precise correctness checking with bit mask
			return stack.Sum() == testCase.CheckSum;
		}
		var candidates = GetCandidates(currentPosition, testCase);
		if (FindPermutation(stack, hashSet, currentPosition, testCase, candidates.Min)) 
			return true;
		if (FindPermutation(stack, hashSet, currentPosition, testCase, candidates.Max)) 
			return true;
		return false;
	}

	private static bool FindPermutation(Stack<int> stack, int[] hashSet, int currentPosition, TestCase testCase, int item)
	{
		if (item >= 1 && item <= testCase.N && hashSet[item] == 0)
		{
			stack.Push(item);
			hashSet[item] = 1;
			if (FindPermutation(stack, hashSet, currentPosition + 1, testCase))
				return true;
			hashSet[item] = 0;
			stack.Pop();
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

internal class IntSet
{
	int[] state;

	public IntSet(int copasity = 512)
	{
		state = new int[copasity];
		for (int i = 0; i < copasity; i++)
		{
			state[i] = 0;
		}
	}

	public void Add(int i)
	{
		int bucketIndex = i/8;
		int bucket = state[bucketIndex];

	}

	private int GetStateBucket(int i)
	{
		throw new NotImplementedException();
	}

	public void Remove(int i)
	{
		
	}

	public void Contains(int i)
	{
		
	}
}