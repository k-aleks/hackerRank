using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

internal class Solution
{
    private static void Main(String[] args)
    {
        List<ulong> results = new List<ulong>();

        var sw = Stopwatch.StartNew();
        using (FileStream fs = File.OpenRead(@"../../../testData/roadsAndLibs/inbox.txt"))
        {
            Console.SetIn(new StreamReader(fs));
            int queriesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < queriesCount; i++)
            {
                int[] p = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                int citiesCount = p[0];
                var cities = new Dictionary<int, Node>(citiesCount);
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
                Console.Out.WriteLine($"[{i}] begin building elapsed={sw.Elapsed}");
                ulong res = BuildLibraries(cities, libCost, roadCost);
                Console.Out.WriteLine($"[{i}] end building elapsed={sw.Elapsed}");
                results.Add(res);
            }
        }

        foreach (var result in results)
        {
            Console.Out.WriteLine(result);
        }
    }

    public static ulong BuildLibraries(Dictionary<int, Node> allNodes, int libCost, int roadCost)
    {
        if (roadCost >= libCost)
            return (ulong)allNodes.Count * (ulong) libCost;

        ulong totalCost = 0;
        while (allNodes.Count > 0)
        {
            Node firstNode = allNodes.First().Value;
            totalCost += (ulong) libCost;
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
                        totalCost += (ulong) roadCost;
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


