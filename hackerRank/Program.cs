using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		int testCasesCount = Int32.Parse(Console.ReadLine());
		List<TestCase> testCases = ReadTestCases(testCasesCount);

		foreach (var testCase in testCases)
		{
			var pathFinder = new ShortestPathFinder(testCase.Ladders, testCase.Snakes);
			var res = pathFinder.FindPath();
			Console.Out.WriteLine(res);
		}
	}

	private static List<TestCase> ReadTestCases(int testCasesCount)
	{
		var testCases = new List<TestCase>();
		for (int i = 0; i < testCasesCount; i++)
		{
			var tc = new TestCase();
			int laddersCount = Int32.Parse(Console.ReadLine());
			for (int j = 0; j < laddersCount; j++)
			{
				int[] fromTo = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
				tc.Ladders.Add(fromTo[0], fromTo[1]);
			}
			int snakesCount = Int32.Parse(Console.ReadLine());
			for (int j = 0; j < snakesCount; j++)
			{
				int[] fromTo = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
				tc.Snakes.Add(fromTo[0], fromTo[1]);
			}
			testCases.Add(tc);
		}
		return testCases;
	}

	public class TestCase
	{
		public Dictionary<int, int> Ladders = new Dictionary<int, int>();
		public Dictionary<int, int> Snakes = new Dictionary<int, int>();
	}

	public class ShortestPathFinder
	{
		private readonly Dictionary<int, int> ladders;
		private readonly Dictionary<int, int> snakes;

		public ShortestPathFinder(Dictionary<int, int> ladders, Dictionary<int, int> snakes)
		{
			this.ladders = ladders;
			this.snakes = snakes;
		}

		public int FindPath()
		{
			int step = 0;
			int[] visitedSells = new int[100];
			var currentPositions = new List<int>();
			var nextPositions = new List<int>();
			List<int> tmp;
			currentPositions.Add(1);
			while (true)
			{
				step++;
				foreach (var currentPosition in currentPositions)
				{
					foreach (var nextCell in GetNextCells(currentPosition))
					{
						if (nextCell == 100)
							return step;
						if (visitedSells[nextCell] == 0)
						{
							nextPositions.Add(nextCell);
							visitedSells[nextCell] = 1;
						}	
					}
				}
				if (nextPositions.Count == 0)
					return -1;
				tmp = currentPositions;
				currentPositions = nextPositions;
				nextPositions = tmp;
				nextPositions.Clear();
			}
		}

		private IEnumerable<int> GetNextCells(int cell)
		{
			for (int i = 1; i < 7; i++)
			{
				var nextCell = cell + i;
				int transportationCell;
				if (ladders.TryGetValue(nextCell, out transportationCell))
					nextCell = transportationCell;
				if (!snakes.ContainsKey(nextCell))
					yield return nextCell;
			}
		}
	}

}