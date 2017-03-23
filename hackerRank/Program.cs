using System;
using System.Collections.Generic;
using System.IO;
class Solution {

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
            string tmp = RollTheString(s2, i);

            int localMaxSubstringLength = GetMaxSubstringLengthInternal(s1, tmp, maxErrorLevel);
            if (maxSubstringLength < localMaxSubstringLength)
                maxSubstringLength = localMaxSubstringLength;
        }
        return maxSubstringLength;
    }

    public static string RollTheString(string s, int i)
    {
        return (i > 0) ? s.Substring(i) + s.Substring(0, i) : s;
    }

    public static int GetMaxSubstringLengthInternal(string s1, string s2, int maxErrorLevel)
    {
        int maxSubstringLen = 0;
        int[] diff = new int[s1.Length];
        int j = 0;
        for (int i=0; i<s1.Length; i++)
        {
            int delta = (s1[i] == s2[i]) ? 0 : 1;
            diff[i] = (i == 0) ? delta : diff[i-1] + delta;

            int errorLevel = diff[i] - ((j == 0) ? 0 : diff[j-1]);
            if (errorLevel > maxErrorLevel)
            {
                int currentSubstringLength = i-j;
                if (maxSubstringLen < currentSubstringLength)
                    maxSubstringLen = currentSubstringLength;
                j++;
            }
        }
        int finalSubstringLength = s1.Length-j;
        if (maxSubstringLen < finalSubstringLength)
            maxSubstringLen = finalSubstringLength;
        return maxSubstringLen;
    }
}