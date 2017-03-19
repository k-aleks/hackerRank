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
                cities.Add(j, new Node(j) {Connected = new HashSet<int>()});
            }
            int roadsCount = p[1];
            for (int j = 0; j < roadsCount; j++)
            {
                int[] road = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                cities[road[0]].Connected.Add(road[1]);
                cities[road[1]].Connected.Add(road[0]);
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
        for (int i = 0; i < nodesCount; i++)
        {
            res[i] = -1;
        }
        res[startNode-1] = 0;

        var visited = new HashSet<int>();
        var currentLevel = new List<int>() {startNode};
        visited.Add(startNode);
        int level = 1;

        while (currentLevel.Count > 0)
        {
            var nextLevel = new List<int>();
            foreach (var id in currentLevel)
            {
                foreach (var nextLevelNode in allNodes[id].Connected)
                {
                    if (visited.Contains(nextLevelNode))
                        continue;
                    visited.Add(nextLevelNode);
                    nextLevel.Add(nextLevelNode);
                    res[nextLevelNode-1] = level * 6;
                }
            }
            currentLevel = nextLevel;
            level++;
        }
        return res;
    }
}

public class Node
{
    public int Id;
    public HashSet<int> Connected;

    public Node(int id)
    {
        Id = id;
    }
}


