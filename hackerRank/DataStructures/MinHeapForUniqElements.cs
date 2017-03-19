using System;
using System.Collections.Generic;

public class MinHeapForUniqElements : IMinHeap
{
    readonly BinaryTreeIndexer indexer = new BinaryTreeIndexer();
    private readonly List<int> list;
    private readonly Dictionary<int, int> mapValueToIndex;

    public MinHeapForUniqElements(int initialCapacity = 16)
    {
        list = new List<int>(initialCapacity);
        mapValueToIndex = new Dictionary<int, int>(initialCapacity);
    }

    public void Add(int newElement)
    {
        list.Add(newElement);
        mapValueToIndex[newElement] = list.Count - 1;
        UpHeapLastElement();
    }

    public void DecreaseKey(int oldElement, int newElement)
    {
        var elementIndex = mapValueToIndex[oldElement];
        list[elementIndex] = newElement;
        mapValueToIndex.Remove(oldElement);
        mapValueToIndex[newElement] = elementIndex;
        UpHeapElement(elementIndex);
    }

    public void Delete(int element)
    {
        var elementIndex = mapValueToIndex[element];
        mapValueToIndex.Remove(element);
        DeleteAtIndex(elementIndex);
    }

    public int PopMin()
    {
        int min = list[0];
        mapValueToIndex.Remove(min);
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
        mapValueToIndex[list[elementIndex]] = elementIndex;
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
            mapValueToIndex[list[elementIndex]] = elementIndex;
            mapValueToIndex[list[minIndex]] = minIndex;
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
            mapValueToIndex[list[elementIndex]] = elementIndex;
            mapValueToIndex[list[parentIndex]] = parentIndex;
            elementIndex = parentIndex;
        }
    }
}