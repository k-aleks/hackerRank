using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
	    int count = Int32.Parse(Console.ReadLine());

	}
}

public class BinaryHeap
{
    List<int> list = new List<int>();

    public void Add(int newElement)
    {
        list.Add(newElement);
        UpHeapLastElement();
    }

    private void UpHeapLastElement()
    {
        throw new NotImplementedException();
    }
}

public class BinaryTreeIndexer
{
    public int GetParentIndex(int childIndex)
    {
        int bucketNumber = GetBucketNumber(childIndex);
        int indexInBucket = GetIndexInBucket(childIndex, bucketNumber);
        int parentBucketSize = GetBucketSize(bucketNumber - 1);
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

