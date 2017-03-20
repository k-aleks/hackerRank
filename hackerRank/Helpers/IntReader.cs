using System.Collections.Generic;

public class IntReader
{
    private static Dictionary<char, int> dic = new Dictionary<char, int>()
    {
        {'0', 0},
        {'1', 1},
        {'2', 2},
        {'3', 3},
        {'4', 4},
        {'5', 5},
        {'6', 6},
        {'7', 7},
        {'8', 8},
        {'9', 9},
    };
    private string str;
    private int position;

    public void StartNew(string str)
    {
        this.str = str;
        position = 0;
    }

    public int ReadNext()
    {
        int current = dic[str[position]];
        position++;
        while (position < str.Length && str[position] != ' ' )
        {
            current *= 10;
            current += dic[str[position]];
            position++;
        }
        position++;
        return current;
    }
}