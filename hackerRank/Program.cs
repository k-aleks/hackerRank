using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

internal class Solution
{
	private static void Main(String[] args)
	{
		int testCasesCount = Int32.Parse(Console.ReadLine());
		var testCases = new Tuple<string, string>[testCasesCount];
		for (int i = 0; i < testCasesCount; i++)
		{
			var line1 = Console.ReadLine();
			var line2 = Console.ReadLine();
			testCases[i] = new Tuple<string, string>(line1, line2);
		}
		foreach (var testCase in testCases)
		{
			var res = FindIntro(testCase.Item1, testCase.Item2);
			Console.Out.WriteLine(res ? "YES" : "NO");
		}
	}

	public static bool FindIntro(string line1, string line2)
	{
		int[] letters1 = new int['z' - 'a' + 1];
		int[] letters2 = new int['z' - 'a' + 1];
		foreach (int letter in line1)
		{
			letters1[letter - 'a'] = 1;
		}
		foreach (int letter in line2)
		{
			letters2[letter - 'a'] = 1;
		}
		for (int i = 0; i < letters1.Length; i++)
		{
			if (letters1[i] == 1 && letters2[i] == 1)
				return true;
		}
		return false;
	}
}