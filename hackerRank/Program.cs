using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;

/// <summary>
/// Plan:
/// 1) Rotator with height recalculation
/// </summary>
internal class Solution
{
	private static void Main(String[] args)
	{
	}

    public static Node InsertNode(Node treeRoot, int value)
    {
        var newNode = new Node()
        {
            val = value,
            ht = 1
        };

        if (treeRoot == null)
        {
            treeRoot = newNode;
            return treeRoot;
        }

        List<Node> path = new List<Node>();
        FindParent(treeRoot, value, path);

        Node parent = path.Last();

        if (value < parent.val)
        {
            parent.left = newNode;
        }
        else if (value > parent.val)
        {
            parent.right = newNode;
        }
        else
        {
            throw new Exception("Unexpected error");
        }

        if (!RecalculateHeight(path))
            return treeRoot;

        RebalanceIfNeeded(path, newNode);

        return treeRoot;
    }

    private static bool RecalculateHeight(List<Node> path)
    {
        if (path.Last().ht == 1)
            return false; //parent had one child and height didn't change
        foreach (var node in path)
        {
            node.ht++;
        }
        return true;
    }

    private static Node RebalanceIfNeeded(List<Node> path, Node newNode)
    {
        Node root = path[0];
        Node node;
        for (int i = path.Count - 1; i >= 0; i--)
        {
            node = path[i];
            int balanceFactor = GetBalanceFactor(node);

            if (balanceFactor == 2)
            {

                return root;
            }

            if (balanceFactor == -2)
            {
                Node newSubtreeRoot;
                Node rightNode = node.right;

                if (GetBalanceFactor(rightNode) > 0)
                {
                    newSubtreeRoot = Rotator.PerformLeftRightRotation(node, rightNode);
                    TreeHeightCalculator.CalcHeighForEachNode(newSubtreeRoot);
                }
                else
                {
                    newSubtreeRoot = Rotator.PerformLeftRotation(node);
                    TreeHeightCalculator.CalcHeighForEachNode(newSubtreeRoot);
                }

                if (i == 0)
                    root = newSubtreeRoot;
                else
                {
                    path[i - 1].right = newSubtreeRoot;
                    RecalculateHeightUpToTheRoot(path, i - 1, newSubtreeRoot.ht + 1);
                }

                return root;
            }

            if (balanceFactor > 2 || balanceFactor < -2)
            {
                throw new Exception($"Unexpected balanceFactor {balanceFactor}");
            }
        }

        return root;
    }

    private static void RecalculateHeightUpToTheRoot(List<Node> path, int startingIndex, int minHeight)
    {
        for (int j = startingIndex, i = 0; j >= 0; j--, i++)
        {
            path[j].ht = minHeight + i;
        }
    }


    private static int GetBalanceFactor(Node node)
    {
        return GetNodeHight(node.left) - GetNodeHight(node.right);
    }

    private static void FindParent(Node node, int value, List<Node> path)
    {
        path.Add(node);
        if (value < node.val)
        {
            if (node.left == null)
                return ;
            FindParent(node.left, value, path);
        }
        else if (value > node.val)
        {
            if (node.right == null)
                return;
            FindParent(node.right, value, path);
        }
        else
            throw new Exception("Unexpected error");
    }

    private static int GetNodeHight(Node node)
    {
        if (node == null)
            return 0;
        return node.ht;
    }
}


class Node
{
    public int val;   //Value
    public int ht = -1;      //Height
    public Node left;   //Left child
    public Node right;   //Right child
}
