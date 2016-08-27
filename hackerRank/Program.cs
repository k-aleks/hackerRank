using System;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		int araySize = Int32.Parse(Console.ReadLine());
		var arr = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
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