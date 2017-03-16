using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
	    int count = Int32.Parse(Console.ReadLine());
	    int[] arr = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
	    var res =  GetMaxRectangles(arr);

	    Console.Out.WriteLine(res);

	}

    public static int GetMaxRectangles(int[] arr)
    {
        var r = GetMaxRectanglesRight(arr);
        var l = GetMaxRectanglesLeft(arr);
        int max = 0;
        for (int i = 0; i < r.Length; i++)
        {
            var localMax = r[i] + l[i] - arr[i];
            if (localMax > max)
                max = localMax;
        }
        return max;
    }

    public static int[] GetMaxRectanglesRight(int[] arr)
    {
        var stack = new Stack<StackElement>();
        int[] maxRectangles = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            while (stack.Count > 0 && arr[i] < stack.Peek().Value)
            {
                PopElementAndCalcRectangleRight(stack, i, maxRectangles);
            }
            stack.Push(new StackElement
            {
                Value = arr[i],
                IndexInArray = i
            });
        }
        while (stack.Count > 0)
        {
            PopElementAndCalcRectangleRight(stack, arr.Length, maxRectangles);
        }

        return maxRectangles;
    }

    public static int[] GetMaxRectanglesLeft(int[] arr)
    {
        var stack = new Stack<StackElement>();
        int[] maxRectangles = new int[arr.Length];
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && arr[i] < stack.Peek().Value)
            {
                PopElementAndCalcRectangleLeft(stack, i, maxRectangles);
            }
            stack.Push(new StackElement
            {
                Value = arr[i],
                IndexInArray = i
            });
        }
        while (stack.Count > 0)
        {
            PopElementAndCalcRectangleLeft(stack, -1, maxRectangles);
        }

        return maxRectangles;
    }

    private static void PopElementAndCalcRectangleRight(Stack<StackElement> stack, int currentIndex, int[] maxRectangles)
    {
        StackElement element = stack.Pop();
        int curRectangle = element.Value * (currentIndex - element.IndexInArray);
        maxRectangles[element.IndexInArray] += curRectangle;
    }

    private static void PopElementAndCalcRectangleLeft(Stack<StackElement> stack, int currentIndex, int[] maxRectangles)
    {
        StackElement element = stack.Pop();
        int curRectangle = element.Value * (element.IndexInArray - currentIndex);
        maxRectangles[element.IndexInArray] += curRectangle;
    }
}

public class StackElement
{
    public int Value;
    public int IndexInArray;
}
