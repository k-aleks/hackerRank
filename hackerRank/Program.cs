using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static void Main(String[] args)
    {
        int cases = int.Parse(Console.ReadLine());
        for (int i=0; i<cases; i++) {
            string[] p = Console.ReadLine().Split(' ');
            int s = int.Parse(p[0]);
            int res = GetMaxSubstringLength(p[1], p[2], s);
            Console.WriteLine(res);
        }
    }

    public static int GetMaxSubstringLength(string s1, string s2, int maxErrorLevel)
    {
        int maxSubstringLength = int.MinValue;
        for (int i=0; i<s1.Length; i++)
        {
            string tmp;
            int localMaxSubstringLength;

            tmp = s2.Substring(i);

            localMaxSubstringLength = GetMaxSubstringLengthInternal(s1, tmp, 0, tmp.Length-1, maxErrorLevel);
            if (maxSubstringLength < localMaxSubstringLength)
                maxSubstringLength = localMaxSubstringLength;

            if (i == 0)
                continue;

            tmp = s2.Substring(0, i);

            localMaxSubstringLength = GetMaxSubstringLengthInternal(s1, tmp, s1.Length - tmp.Length, s1.Length - 1, maxErrorLevel);
            if (maxSubstringLength < localMaxSubstringLength)
                maxSubstringLength = localMaxSubstringLength;
        }
        return maxSubstringLength;
    }

    public static int GetMaxSubstringLengthInternal(string s1, string s2, int from, int to, int maxErrorLevel)
    {
        int maxSubstringLen = 0;
        int[] diff = new int[s1.Length];
        int j = from;
        for (int i=from, k=0; i<=to; i++,k++)
        {
            int delta = (s1[i] == s2[k]) ? 0 : 1;
            diff[i] = (i == from) ? delta : diff[i-1] + delta;

            int errorLevel = diff[i] - ((j == from) ? 0 : diff[j-1]);
            if (errorLevel > maxErrorLevel)
            {
                int currentSubstringLength = k-(j-from);
                if (maxSubstringLen < currentSubstringLength)
                    maxSubstringLen = currentSubstringLength;
                j++;
            }
        }
        int finalSubstringLength = s2.Length-(j-from);
        if (maxSubstringLen < finalSubstringLength)
            maxSubstringLen = finalSubstringLength;
        return maxSubstringLen;
    }
}