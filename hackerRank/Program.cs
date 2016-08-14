using System;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		int araySize = Int32.Parse(Console.ReadLine());
		int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
	}

	

	public static void Print(int[] ar)
	{
		Console.Out.WriteLine(string.Join(" ", ar));
	}
}