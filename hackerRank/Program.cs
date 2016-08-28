using System;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		int experimentsCount = Int32.Parse(Console.ReadLine());

		for (int i = 0; i < experimentsCount; i++)
		{
			int araySize = Int32.Parse(Console.ReadLine());
			int[] arr = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();

			long shifts = MergeSort.Sort(arr);
			Console.Out.WriteLine(shifts);
		}
	}

	public static void Print<T>(T[] ar)
	{
		Console.Out.WriteLine(string.Join(" ", ar));
	}
}

public static class MergeSort
{
	public static long Sort(int[] arr)
	{
		long shifts = 0;
		Sort(arr, 0, arr.Length - 1, new int[arr.Length], ref shifts);
		return shifts;
	}

	private static void Sort(int[] arr, int left, int right, int[] tmp, ref long shifts)
	{
		if (left >= right)
			return;
		int mid = (right + left)/2;
		Sort(arr, left, mid, tmp, ref shifts);
		Sort(arr, mid + 1, right, tmp, ref shifts);

		Merge(arr, left, mid, right, tmp, ref shifts);
	}

	private static void Merge(int[] arr, int left, int mid, int right, int[] tmp, ref long shifts)
	{
		Array.Copy(arr, left, tmp, left, right - left + 1);
		int i = left;
		int j = mid + 1;
		int iter = 0;
		while (i <= mid && j <= right)
		{
			if (tmp[i] <= tmp[j])
				arr[left + iter++] = tmp[i++];
			else
			{
				arr[left + iter] = tmp[j];
				shifts += j - (left + iter);
				iter++;
				j++;
			}
		}
		if (i <= mid)
		{
			Array.Copy(tmp, i, arr, left + iter, mid - i + 1);
		}
	}
}