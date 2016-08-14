using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		int valueToSearch = Int32.Parse(Console.ReadLine());
		int araySize = Int32.Parse(Console.ReadLine());
		var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray() ;
		var res = BinSearch(arr, valueToSearch);
		Console.Out.WriteLine(res);

	}

	public static int BinSearch(int[] arr, int value)
	{
		int left = 0;
		int right = arr.Length;
		int mid;
		while (left <= right)
		{
			mid = (left + right)/2;
			if (value < arr[mid])
			{
				right = mid - 1;
			}
			else if (value > arr[mid])
			{
				left = mid + 1;
			}
			else
				return mid;
		}
		return -1;
	}
}
