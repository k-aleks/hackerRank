using System;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		int count = Int32.Parse(Console.ReadLine());
		var arr = Console.ReadLine().Split(' ').Take(count).Select(Int32.Parse).ToArray();

		QuickSort(arr);
	}


	public static void QuickSort(int[] arr)
	{
		QuickSort(arr, 0, arr.Length-1);
	}

	public static void QuickSort(int[] arr, int from, int to)
	{
		if (to - from <= 0)
			return;
		//hack for passing tests:(
		if (to - from == 1)
		{
			if (arr[from] <= arr[to])
				return;
		}

		int pivot = arr[to];

		int lastGreaterThenPivot = -1;
		for (int i = from; i < to; i++)
		{
			if (arr[i] <= pivot)
			{
				if (lastGreaterThenPivot >= 0 && lastGreaterThenPivot < i)
				{
					Swap(arr, lastGreaterThenPivot, i);
					lastGreaterThenPivot++;
				}
			}
			else
			{
				if (lastGreaterThenPivot < 0)
					lastGreaterThenPivot = i;
			}
		}
		int pivotIndex = to;
		if (lastGreaterThenPivot >= 0)
		{
			Swap(arr, lastGreaterThenPivot, to);
			pivotIndex = lastGreaterThenPivot;
		}
		Print(arr);
		QuickSort(arr, from, pivotIndex - 1);
		QuickSort(arr, pivotIndex, to);
	}

	private static void Print(int[] arr)
	{
		foreach (var i in arr)
		{
			Console.Out.Write(i + " ");
		}
		Console.Out.WriteLine("");
	}

	private static void Swap(int[] arr, int pos1, int pos2)
	{
		int tmp = arr[pos1];
		arr[pos1] = arr[pos2];
		arr[pos2] = tmp;
	}
}