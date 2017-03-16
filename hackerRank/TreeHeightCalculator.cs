using System;
using System.Collections.Generic;

internal class TreeHeightCalculator
{
    public static void CalcHeighForEachNode(Node root)
    {
        CalcHeighForEachNode(root, new Stack<Node>());
    }

    private static void CalcHeighForEachNode(Node node, Stack<Node> stack)
    {
        stack.Push(node);
        if (node.left != null)
        {
            CalcHeighForEachNode(node.left, stack);
        }
        else
        {
            Node fromStack;
            do
            {
                if (stack.Count == 0)
                    return;
                fromStack = stack.Pop();
                CalcNodeHeightFromChildren(fromStack);
            } while (fromStack.right == null);

            CalcHeighForEachNode(fromStack.right, stack);
            CalcNodeHeightFromChildren(fromStack);
        }
    }

    private static void CalcNodeHeightFromChildren(Node node)
    {
        if (node.left == null && node.right == null)
        {
            node.ht = 0;
            return;
        }
        var leftHeight = node.left?.ht ?? 0;
        var rightHeight = node.right?.ht ?? 0;
        node.ht = Math.Max(leftHeight, rightHeight) + 1;
    }
}