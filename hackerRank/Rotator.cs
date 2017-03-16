using System;

class Rotator
{
    public static Node PerformLeftRotation(Node node)
    {
        Node right = node.right;
        Node rightLeft = node.right.left;
        right.left = node;
        node.right = rightLeft;
        return right;
    }

    public static Node PerformRightRotation(Node node)
    {
        Node left = node.left;
        Node leftRight = node.left.right;
        left.right = node;
        node.left = leftRight;
        return left;
    }

    public static Node PerformLeftRightRotation(Node node, Node rightNode)
    {
        Node newSubtreeRoot = PerformLeftRotation(rightNode);
        node.right = newSubtreeRoot;
        return PerformRightRotation(node);
    }

    public static Node PerformRightLeftRotation(Node node, Node leftNode)
    {
        Node newSubtreeRoot = PerformRightRotation(leftNode);
        node.left = newSubtreeRoot;
        return PerformLeftRotation(node);
    }
}