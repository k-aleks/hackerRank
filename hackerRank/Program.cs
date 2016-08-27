using System;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		int araySize = Int32.Parse(Console.ReadLine());
		string[] initialArrayOfStrings = new string[araySize];
		int[] initialArrayOfRanks = new int[araySize];
		for (int i = 0; i < araySize; i++)
		{
			string[] strings = Console.ReadLine().Split(' ');
			initialArrayOfRanks[i] = Int32.Parse(strings[0]);
			initialArrayOfStrings[i] = strings[1];
		}
		int[] countingSortedRanks = Count(initialArrayOfRanks);
		int[] startingPositionsOfRanks = CountingSortResultToStartingPositions(countingSortedRanks);

		string[] result = new string[araySize];
		int mid = araySize/2;
		for (int i = 0; i < araySize; i++)
		{
			var str = i < mid ? "-" : initialArrayOfStrings[i];
			int rank = initialArrayOfRanks[i];
			result[startingPositionsOfRanks[rank]] = str;
			startingPositionsOfRanks[rank]++;
		}
		Print(result);

	}

	private static int[] CountingSortResultToStartingPositions(int[] countingSortedRanks)
	{
		int[] startingPositionsOfRanks = new int[countingSortedRanks.Length];
		int lessThenCurrent = 0;
		for (int i = 0; i < countingSortedRanks.Length; i++)
		{
			startingPositionsOfRanks[i] = lessThenCurrent;
			lessThenCurrent += countingSortedRanks[i];
		}
		return startingPositionsOfRanks;
	}

	public static int[] Count(int[] arr)
	{
		var count = new int[100];
		for (int i = 0; i < arr.Length; i++)
		{
			count[arr[i]]++;
		}
		return count;
	}
	

	public static void Print<T>(T[] ar)
	{
		Console.Out.WriteLine(string.Join(" ", ar));
	}
}