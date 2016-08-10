using System;
using System.IO;
using System.Linq;
using System.Numerics;

internal class Solution
{
	private static void Main(String[] args)
	{
		var input = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
		BigInteger res = CalcWaysCount(input[0], input[1], input[2]);
		Console.Out.WriteLine(res);
	}

	public static BigInteger CalcWaysCount(int n, int m, int c)
	{
		int uniqCities = (n - c) + (m - c) + c;
		int mult = uniqCities - 1;
		BigInteger result = mult;
		mult--;
		while (mult > 0)
		{
			result *= mult;
			mult--;
		}
		return result;
	}
}