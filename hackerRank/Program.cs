using System;
using System.IO;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
	    var firstLineArgs = Console.ReadLine().Split(' ');
	    int n = Int32.Parse(firstLineArgs[0]);
	    int d = Int32.Parse(firstLineArgs[1]);

	    var secondLineArgs = Console.ReadLine().Split(' ');
        int[] expenditures = new int[secondLineArgs.Length];
		for (int i = 0; i < expenditures.Length; i++)
		{
		    expenditures[i] = int.Parse(secondLineArgs[i]);
		}

	    var result = new AlarmSystem().CalculateAlarmsCount(expenditures, d);
	    Console.Out.WriteLine(result);
	}
}

public class AlarmSystem
{
    public int CalculateAlarmsCount(int[] expenditures, int analysisPeriod)
    {
        if (analysisPeriod >= expenditures.Length)
            return 0;

        var sortedList = CreateSortedList(expenditures, analysisPeriod);

        int alarmsCount = 0;
        for (int i = analysisPeriod; i < expenditures.Length; i++)
        {
            if (expenditures[i] >= sortedList.GetMedian() * 2)
                alarmsCount++;

            var valueToAdd = expenditures[i];
            var valueToRemove = expenditures[i - analysisPeriod];
            sortedList.Replace(valueToRemove, valueToAdd);
        }

        return alarmsCount;
    }

    private SortedList CreateSortedList(int[] expenditures, int analysisPeriod)
    {
        var initialExpenditures = new int[analysisPeriod];
        Array.Copy(expenditures, 0, initialExpenditures, 0, analysisPeriod);
        return new SortedList(initialExpenditures);
    }
}

public class SortedList
{
    int[] arr;
    bool isEven;

    public SortedList(int[] initialArray)
    {
        arr = initialArray;
        Array.Sort(arr);
        isEven = arr.Length % 2 == 0;
    }

    public void Replace(int oldElement, int newElement)
    {
        if (oldElement == newElement)
            return;

        int oldElementPosition = BinSearchPosition(oldElement);
        int newElementPosition = BinSearchPosition(newElement);

        if (oldElementPosition == newElementPosition)
        {
            arr[newElementPosition] = newElement;
            return;
        }

        if (oldElementPosition < newElementPosition)
        {
            for (int i = oldElementPosition; i < newElementPosition; i++)
            {
                arr[i] = arr[i+1];
            }
            arr[newElementPosition] = newElement;
        }
        else
        {
            for (int i = oldElementPosition; i > newElementPosition; i--)
            {
                arr[i] = arr[i-1];
            }
            arr[newElementPosition] = newElement;
        }
    }

    public double GetMedian()
    {
        if (isEven)
        {
            var i = arr.Length / 2;
            return (arr[i-1] + arr[i]) / 2d;
        }
        else
        {
            if (arr.Length == 1)
                return arr[0];
            return arr[arr.Length / 2];
        }
    }

    public int[] Arr
    {
        get { return arr; }
    }

    private int BinSearchPosition(int element)
    {
        if (element <= arr[0])
            return 0;
        if (element >= arr[arr.Length-1])
            return arr.Length - 1;

        return BinSearchPosition(element, arr, 0, arr.Length-1);
    }

    private int BinSearchPosition(int element, int[] arr, int from, int to)
    {
        if (from == to)
            return to;

        var mid = from + (to - from + 1) / 2;

        if (element < arr[mid])
            return BinSearchPosition(element, arr, from, mid-1);
        else
            return BinSearchPosition(element, arr, mid, to);
    }
}
