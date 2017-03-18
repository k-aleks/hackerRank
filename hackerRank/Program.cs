using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
    private static void Main(String[] args)
    {
        int queriesCount = int.Parse(Console.ReadLine());

        List<int> results = new List<int>();

        for (int i = 0; i < queriesCount; i++)
        {
            int[] p = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int citiesCount = p[0];
            var cities = new Dictionary<int, Node>();
            for (int j = 1; j <= citiesCount; j++)
            {
                cities.Add(j, new Node(j) {Connected = new HashSet<int>()});
            }
            int roadsCount = p[1];
            for (int j = 0; j < roadsCount; j++)
            {
                int[] road = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                cities[road[0]].Connected.Add(road[1]);
                cities[road[1]].Connected.Add(road[0]);
            }
            int libCost = p[2];
            int roadCost = p[3];
            int res = BuildLibraries(cities, libCost, roadCost);
            results.Add(res);
        }

        foreach (var result in results)
        {
            Console.Out.WriteLine(result);
        }
    }

    public static int BuildLibraries(Dictionary<int, Node> allNodes, int libCost, int roadCost)
    {
        if (roadCost >= libCost)
            return allNodes.Count * libCost;

        int totalCost = 0;
        while (allNodes.Count > 0)
        {
            Node firstNode = allNodes.First().Value;
            totalCost += libCost;
            var buffer = new List<Node>()
            {
                firstNode
            };
            allNodes.Remove(firstNode.Id);
            while (buffer.Count > 0)
            {
                var newBuffer = new List<Node>();
                foreach (var node in buffer)
                {
                    foreach (var connectedNodeId in node.Connected)
                    {
                        if (!allNodes.ContainsKey(connectedNodeId)) //already visited
                            continue;
                        totalCost += roadCost;
                        newBuffer.Add(allNodes[connectedNodeId]);
                        allNodes.Remove(connectedNodeId);
                    }
                }
                buffer = newBuffer;
            }
        }
        return totalCost;
    }
}

public class Node : IEquatable<Node>
{
    public int Id;
    public HashSet<int> Connected;

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
}


