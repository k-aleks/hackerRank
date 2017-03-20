using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
    private static void Main(String[] args)
    {
        int queriesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < queriesCount; i++)
        {
            int[] p = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int citiesCount = p[0];
            var cities = new Dictionary<int, Node>(citiesCount);
            for (int j = 1; j <= citiesCount; j++)
            {
                cities.Add(j, new Node(j) {Connected = new HashSet<Road>()});
            }
            int roadsCount = p[1];
            for (int j = 0; j < roadsCount; j++)
            {
                int[] road = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                int city1 = road[0];
                int city2 = road[1];
                int roadCost = road[2];
                cities[city1].Connected.Add(new Road(city2, roadCost));
                cities[city2].Connected.Add(new Road(city1, roadCost));
            }
            int startNode = int.Parse(Console.ReadLine());
            FindShortestWayToAllNodes(cities, startNode);

            var res = new List<int>();
            for (int k = 1; k < cities.Count+1; k++)
            {
                if (k == 1)
                     continue;

                var n = cities[k];
                res.Add(n.Dist == int.MaxValue ? -1 : n.Dist);
            }
            Console.Out.WriteLine(string.Join(" ", res));
        }
    }

    public static void FindShortestWayToAllNodes(Dictionary<int, Node> allNodes, int startNode)
    {
        int nodesCount = allNodes.Count;
        var visited = new HashSet<int>();

        var heap = new NodeMinHeap(nodesCount);
        foreach (var node in allNodes.Values)
        {
            node.Dist = (node.Id == startNode) ? 0 : int.MaxValue;
            heap.Add(node);
        }

        while (heap.Count > 0 && heap.GetMin().Dist < int.MaxValue)
        {
            var node = heap.PopMin();
            visited.Add(node.Id);
            foreach (var road in node.Connected)
            {
                if (!visited.Contains(road.Destination))
                {
                    var destNode = allNodes[road.Destination];
                    var newDistance = node.Dist + road.Cost;
                    if (newDistance < destNode.Dist)
                    {
                        destNode.Dist = newDistance;
                        heap.DecreaseKey(destNode);
                    }
                }
            }
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

public class Road
{
    public Road(int destination, int cost)
    {
        Destination = destination;
        Cost = cost;
    }

    public int Destination;
    public int Cost;
}


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
