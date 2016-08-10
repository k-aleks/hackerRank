using System;
using System.Collections.Generic;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		int x = Int32.Parse(Console.ReadLine());
		for (int i = 0; i < x; i++)
		{
			int ratingsCount = Int32.Parse(Console.ReadLine());
			bool res = AnalizeRatings(ratingsCount);
			if (res)
				Console.Out.WriteLine("ORDER EXISTS");
			else
				Console.Out.WriteLine("ORDER VIOLATION");
		}
	}

	private static bool AnalizeRatings(int ratingsCount)
	{
		var graph = new Dictionary<string, Node>();
		for (int i = 0; i < ratingsCount; i++)
		{
			string[] attractions = Console.ReadLine().Split(',');
			for (int j = 0; j < attractions.Length - 1; j++)
			{
				string curr = attractions[j];
				string next = attractions[j + 1];
				EnsureExistsInDic(graph, curr);
				EnsureExistsInDic(graph, next);
				AddChild(graph, curr, next);
			}
		}
		List<Node> rootNodes = graph.Where(pair => !pair.Value.HasParent).Select(pair => pair.Value).ToList();
		foreach (Node rootNode in rootNodes)
		{
			if (FindCycle(rootNode, graph))
			{
				return false;
			}
		}
		if (graph.Count > 0)
			return false;
		return true;
	}

	public static bool FindCycle(Node node, Dictionary<string, Node> graph)
	{
		graph.Remove(node.Key);

		if (!node.IsWhite)
			return true;
		if (node.Children == null)
			return false;
		node.IsWhite = false;
		foreach (Node child in node.Children)
		{
			if (FindCycle(child, graph))
				return true;
		}
		node.IsWhite = true;
		return false;
	}

	private static void AddChild(Dictionary<string, Node> graph, string parentKey, string childKey)
	{
		Node parent = graph[parentKey];
		Node child = graph[childKey];
		child.HasParent = true;
		parent.AddChild(child);
	}

	private static void EnsureExistsInDic(Dictionary<string, Node> graph, string key)
	{
		if (!graph.ContainsKey(key))
			graph.Add(key, new Node(key));
	}
}

internal class Node
{
	public HashSet<Node> Children;
	public bool HasParent = false;
	public bool IsWhite = true;
	public string Key;

	public Node(string key)
	{
		Key = key;
	}

	public void AddChild(Node child)
	{
		if (Children == null)
			Children = new HashSet<Node>();
		Children.Add(child);
	}
}