using System;
using System.Collections.Generic;

public class NodeMinHeap
{
    readonly BinaryTreeIndexer indexer = new BinaryTreeIndexer();
    private readonly List<Node> list;
    private readonly Dictionary<Node, int> mapValueToIndex;

    public NodeMinHeap(int initialCapacity = 16)
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

public class Node : IEquatable<Node>
{
    public int Id;
    public HashSet<Road> Connected;
    public int Dist;

    public Node(int id)
    {
        Id = id;
        Connected = new HashSet<Road>();
    }

    public bool Equals(Node other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Node) obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public static bool operator ==(Node left, Node right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Node left, Node right)
    {
        return !Equals(left, right);
    }

    private sealed class DistRelationalComparer : Comparer<Node>
    {
        public override int Compare(Node x, Node y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            return x.Dist.CompareTo(y.Dist);
        }
    }

    public static Comparer<Node> DistComparer { get; } = new DistRelationalComparer();
}

public struct Road
{
    public Road(int destination, int cost)
    {
        Destination = destination;
        Cost = cost;
    }

    public int Destination;
    public int Cost;
}
