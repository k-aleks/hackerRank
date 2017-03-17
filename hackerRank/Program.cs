using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
	    int k = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).Skip(1).First();
	    var cookies = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
	    var heap = new MinHeap();
	    foreach (var cookie in cookies)
	    {
	        heap.Add(cookie);
	    }
	    int operationsCount = 0;
	    if (heap.GetMin() >= k)
	    {
	        Console.Out.WriteLine(operationsCount);
	        return;
	    }
	    while (heap.Count > 1)
	    {
	        operationsCount++;
	        int mixedCookie = heap.PopMin() + 2 * heap.PopMin();
	        heap.Add(mixedCookie);
            if (heap.GetMin() >= k)
            {
                Console.Out.WriteLine(operationsCount);
                return;
            }
	    }
	    Console.Out.WriteLine(-1);
	}
}

public class MinHeap
{
    readonly BinaryTreeIndexer indexer = new BinaryTreeIndexer();
    readonly List<int> list = new List<int>();

    public void Add(int newElement)
    {
        list.Add(newElement);
        UpHeapLastElement();
    }

    public void Delete(int element)
    {
        DeleteAtIndex(list.IndexOf(element));
    }

    public int PopMin()
    {
        int min = list[0];
        DeleteAtIndex(0);
        return min;
    }

    public int GetMin()
    {
        return list[0];
    }

    public int Count => list.Count;

    private void DeleteAtIndex(int elementIndex)
    {
        list[elementIndex] = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        if (elementIndex == list.Count)
            return;
        DownHeapElement(elementIndex);
    }

    private void DownHeapElement(int elementIndex)
    {
        while (true)
        {
            int leftIndex = indexer.GetLeftChildIndex(elementIndex);
            int rightIndex = indexer.GetRightChildIndex(elementIndex);

            int leftChild = (leftIndex >= list.Count) ? int.MaxValue : list[leftIndex];
            int rightChild = (rightIndex >= list.Count) ? int.MaxValue : list[rightIndex];

            if (list[elementIndex] <= Math.Min(leftChild, rightChild))
                return;

            int minIndex = (leftChild < rightChild) ? leftIndex : rightIndex;

            int element = list[elementIndex];
            list[elementIndex] = list[minIndex];
            list[minIndex] = element;
            elementIndex = minIndex;
        }
    }

    private void UpHeapLastElement()
    {
        int elementIndex = list.Count - 1;
        while (elementIndex > 0)
        {
            int parentIndex = indexer.GetParentIndex(elementIndex);
            if (list[parentIndex] <= list[elementIndex])
                return;
            int tmp = list[parentIndex];
            list[parentIndex] = list[elementIndex];
            list[elementIndex] = tmp;
            elementIndex = parentIndex;
        }
    }
}

public class BinaryTreeIndexer
{
    public int GetParentIndex(int childIndex)
    {
        int bucketNumber = GetBucketNumber(childIndex);
        int indexInBucket = GetIndexInBucket(childIndex, bucketNumber);
        int indexInBucketOfParent = (int) indexInBucket / 2;
        return GetBucketStartIndex(bucketNumber - 1) + indexInBucketOfParent;
    }

    public int GetLeftChildIndex(int parentIndex)
    {
        int bucketNumber = GetBucketNumber(parentIndex);
        int indexInBucket = GetIndexInBucket(parentIndex, bucketNumber);
        return GetBucketStartIndex(bucketNumber + 1) + 2 * (indexInBucket);
    }

    public int GetRightChildIndex(int parentIndex)
    {
        return GetLeftChildIndex(parentIndex) + 1;
    }

    public int GetBucketNumber(int index)
    {
        return (int)Math.Log(index + 1) + 1;
    }

    public int GetIndexInBucket(int index, int bucketNumber)
    {
        return index - GetBucketStartIndex(bucketNumber);
    }

    public int GetBucketStartIndex(int bucketNumber)
    {

        return (int)Math.Pow(2, bucketNumber) - 1;
    }

    public int GetBucketSize(int bucketNumber)
    {
        return (int) Math.Pow(2, bucketNumber);
    }
}

