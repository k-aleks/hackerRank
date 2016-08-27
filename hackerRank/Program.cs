using System;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		int araySize = Int32.Parse(Console.ReadLine());
		var arr = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
		int median = FindTheMedian(arr);
		Console.Out.WriteLine(median);
	}

	public static int FindTheMedian(int[] arr)
	{
		int medianIndex = arr.Length/2;
		int left = 0;
		int right = arr.Length - 1;

		while (true)
		{
			int pivot = arr[right];
			int firstThatBigger = -1;
			for (int i = left; i <= right; i++)
			{
				if (arr[i] > pivot && firstThatBigger == -1)
				{
					firstThatBigger = i;
				}
				else if (arr[i] <= pivot && firstThatBigger >= 0)
				{
					Swap(arr, i, firstThatBigger);
					firstThatBigger++;
				}
			}
			int pivotIndex;
			if (firstThatBigger >= 0)
				pivotIndex = firstThatBigger - 1;
			else
				pivotIndex = right;

			if (pivotIndex == medianIndex)
				return pivot;

			if (pivotIndex < medianIndex)
			{
				left = pivotIndex + 1;
			}
			else
			{
				right = pivotIndex - 1;
			}
		}
	}

	private static void Swap(int[] arr, int index1, int index2)
	{
		int tmp = arr[index1];
		arr[index1] = arr[index2];
		arr[index2] = tmp;
	}


	public static void Print<T>(T[] ar)
	{
		Console.Out.WriteLine(string.Join(" ", ar));
	}
}