using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Solution
{
    private static void Main(String[] args)
    {
        InternalMain();
    }

    private static void InternalMain()
    {
        int queriesCount = int.Parse(Console.ReadLine());
        var intReader = new IntReader();

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
                var line = Console.ReadLine();
                intReader.StartNew(line);
                int city1 = intReader.ReadNext();
                int city2 = intReader.ReadNext();
                int roadCost = intReader.ReadNext();
                cities[city1].Connected.Add(new Road(city2, roadCost));
                cities[city2].Connected.Add(new Road(city1, roadCost));
            }
            int startNode = int.Parse(Console.ReadLine());
            FindShortestWayToAllNodes(cities, startNode);

            var res = new List<int>();
            for (int k = 1; k < cities.Count + 1; k++)
            {
                if (k == startNode)
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



