using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
	//Reasoning about size: 
	// 1) Array sum <= 10^5 * 2*N^4 <= 2*10^9 < 2^31
	// => array's sum fits Int32
	// 2) Can I read a whole array string in memory? 
	// length (2*10000 + ' ') == 6 
	// Max array string length = 10^5*6 ~ 600 KB
	// => yes, I can
	// 3) Can I parse and keep in RAM whole array of ints? 
	// 

	static void Main(String[] args)
	{
		var midFinder = new MidFinder();

		int testCasesCount = ReadTestCasesCount();

		for (int i = 0; i < testCasesCount; i++)
		{
			int arraySize = ReadArraySize();
			int[] arr = ReadArray(arraySize);
			var res = midFinder.FindMid(arr);
			if (res >= 0)
				Console.Out.WriteLine("YES");
			else
				Console.Out.WriteLine("NO");
		}
	}

	private static int[] ReadArray(int arraySize)
	{
		return Console.ReadLine().Split(' ').Take(arraySize).Select(Int32.Parse).ToArray();
	}

	private static int ReadArraySize()
	{
		return Int32.Parse(Console.ReadLine());
	}

	private static int ReadTestCasesCount()
	{
		return Int32.Parse(Console.ReadLine());
	}

	public class MidFinder
	{
		public int FindMid(int[] arr)
		{
			if (arr.Length == 1)
				return 0;

			int sumLeft = 0, sumRight = 0;
			int left = 0;
			int right = arr.Length - 1;
			while (left != right)
			{
				if (sumLeft < sumRight)
				{
					sumLeft += arr[left];
					left++;
				}
				else
				{
					sumRight += arr[right];
					right--;
				}
			}
			if (sumLeft == sumRight)
				return left;
			return -1;

		}
	}
}

