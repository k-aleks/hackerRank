using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

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
            var res = FindShortestWayToAllNodes(cities, startNode);
            Console.Out.WriteLine(string.Join(" ", res.Where(d => d!= 0)));
        }
    }

    public static int[] FindShortestWayToAllNodes(Dictionary<int, Node> allNodes, int startNode)
    {
        int nodesCount = allNodes.Count;
        var res = new int[nodesCount];

//
//        for (int i = 0; i < nodesCount; i++)
//        {
//            res[i] = -1;
//        }
//        res[startNode-1] = 0;
//
//        var visited = new HashSet<int>();
//        var currentLevel = new List<int>() {startNode};
//        visited.Add(startNode);
//        int level = 1;
//
//        while (currentLevel.Count > 0)
//        {
//            var nextLevel = new List<int>();
//            foreach (var id in currentLevel)
//            {
//                foreach (var nextLevelNode in allNodes[id].Connected)
//                {
//                    if (visited.Contains(nextLevelNode))
//                        continue;
//                    visited.Add(nextLevelNode);
//                    nextLevel.Add(nextLevelNode);
//                    res[nextLevelNode-1] = level * 6;
//                }
//            }
//            currentLevel = nextLevel;
//            level++;
//        }

        return res;
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


