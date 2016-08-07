using System;
using System.IO;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		Console.SetIn(File.OpenText(@"C:\dev\hackerRank\hackerRank\testData\StringSimilarity\case10input"));
		int testCasesCount = int.Parse(Console.ReadLine());
		string[] testCases = new string[testCasesCount];
		for (int i = 0; i < testCasesCount; i++)
		{
			testCases[i] = Console.ReadLine();
		}
		foreach (var testCase in testCases)
		{
			var res = StringSimularity(testCase);
			Console.Out.WriteLine(res);
		}
	}

	private static long StringSimularity(string testCase)
	{
		long res = GetZFunction(testCase).Sum(i => (long) i);
		return res;
	}

	public static int[] GetZFunction(string s)
	{
		int[] z = new int[s.Length];
		if (s.Length == 0)
			return z;
		z[0] = s.Length;
		int n = s.Length;
		int l = 0, r = 0;
		for (int i = 1; i < n; i++)
		{
			if (i <= r)
			{
				z[i] = Math.Min(r - i + 1, z[i - l]);
			}
			while (i + z[i] < n && s[z[i]] == s[i + z[i]])
				z[i]++;
			if (i + z[i] - 1 > r)
			{
				r = i + z[i] - 1;
				l = i;
			}
		}
		return z;
	}
}