using System;
using System.Collections.Generic;

public class MinHeap : IMinHeap
{
    readonly BinaryTreeIndexer indexer = new BinaryTreeIndexer();
    private readonly List<int> list;

    public MinHeap(int initialCapacity = 16)
    {
        list = new List<int>(initialCapacity);
    }

    public void Add(int newElement)
    {
        list.Add(newElement);
        UpHeapLastElement();
    }

    public void DecreaseKey(int oldElement, int newElement)
    {
        var elementIndex = list.IndexOf(oldElement);
        list[elementIndex] = newElement;
        UpHeapElement(elementIndex);
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
            int rightIndex = leftIndex + 1;

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
        UpHeapElement(elementIndex);
    }

    private void UpHeapElement(int elementIndex)
    {
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