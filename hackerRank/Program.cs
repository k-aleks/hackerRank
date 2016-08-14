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
		InsertionSort(arr);

	}

	public static void InsertionSort(int[] arr)
	{
	}
}
