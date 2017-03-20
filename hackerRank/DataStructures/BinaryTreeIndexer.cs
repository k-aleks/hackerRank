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
        return LogTwo(index + 1);
    }

    public int GetIndexInBucket(int index, int bucketNumber)
    {
        int bucketStartIndex = GetBucketStartIndex(bucketNumber);
        return index - bucketStartIndex;
    }

    public int GetBucketStartIndex(int bucketNumber)
    {
        return PowOfTwo(bucketNumber) - 1;
    }

    public int GetBucketSize(int bucketNumber)
    {
        return PowOfTwo(bucketNumber);
    }

    private int PowOfTwo(int pow)
    {
        if (pow == 0)
            return 1;
        int res = 2;
        for (int i = 0; i < pow - 1; i++)
        {
            res *= 2;
        }
        return res;
    }

    public int LogTwo(int i)
    {
        if (i <= 1)
            return 0;
        int pow = 1;
        int cur = 2;
        while (cur <= i)
        {
            cur *= 2;
            pow++;
        }
        return pow - 1;
    }
}