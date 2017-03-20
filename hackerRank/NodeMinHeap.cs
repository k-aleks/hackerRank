using System;
using System.Collections.Generic;

public class NodeMinHeap_bak
{
    readonly BinaryTreeIndexer indexer = new BinaryTreeIndexer();
    private readonly List<Node> list;
    private readonly Dictionary<Node, int> mapValueToIndex;

    public NodeMinHeap_bak(int initialCapacity = 16)
    {
        list = new List<Node>(initialCapacity);
        mapValueToIndex = new Dictionary<Node, int>(initialCapacity);
    }

    public void Add(Node newElement)
    {
        list.Add(newElement);
        mapValueToIndex[newElement] = list.Count - 1;
        UpHeapLastElement();
    }

    public void DecreaseKey(Node element)
    {
        var elementIndex = mapValueToIndex[element];
        list[elementIndex] = element;
        UpHeapElement(elementIndex);
    }

    public void Delete(Node element)
    {
        var elementIndex = mapValueToIndex[element];
        mapValueToIndex.Remove(element);
        DeleteAtIndex(elementIndex);
    }

    public Node PopMin()
    {
        Node min = list[0];
        mapValueToIndex.Remove(min);
        DeleteAtIndex(0);
        return min;
    }

    public Node GetMin()
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

            Node leftChild = (leftIndex >= list.Count) ? null : list[leftIndex];
            Node rightChild = (rightIndex >= list.Count) ? null : list[rightIndex];

            if (list[elementIndex].Dist <= Math.Min(leftChild?.Dist ?? int.MaxValue, rightChild?.Dist ?? int.MaxValue))
                return;

            int minIndex = ((leftChild?.Dist ?? int.MaxValue) < (rightChild?.Dist ?? int.MaxValue)) ? leftIndex : rightIndex;

            Node element = list[elementIndex];
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
            if (list[parentIndex].Dist <= list[elementIndex].Dist)
                return;
            Node tmp = list[parentIndex];
            list[parentIndex] = list[elementIndex];
            list[elementIndex] = tmp;
            mapValueToIndex[list[elementIndex]] = elementIndex;
            mapValueToIndex[list[parentIndex]] = parentIndex;
            elementIndex = parentIndex;
        }
    }
}