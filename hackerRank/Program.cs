using System;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		int araySize = Int32.Parse(Console.ReadLine());
		int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
		InsertionSort(arr);
	}

	public static void InsertionSort(int[] ar)
	{
		int shift = 0;
		for (int i = 1; i < ar.Length; i++)
		{
			InsertionSort(ar, i, ref shift);
			//Print(ar);
		}
		Console.Out.WriteLine(shift);
	}

	public static void InsertionSort(int[] ar, int elementIndex, ref int shift)
	{
		int elementToInsert = ar[elementIndex];
		for (int i = elementIndex - 1; i >= 0; i--)
		{
			if (ar[i] > elementToInsert)
			{
				ar[i + 1] = ar[i];
				shift++;
			}
			else
			{
				ar[i + 1] = elementToInsert;
				return;
			}
		}
		ar[0] = elementToInsert;
	}

	public static void Print(int[] ar)
	{
		Console.Out.WriteLine(string.Join(" ", ar));
	}
}