using System;
using FluentAssertions;
using NUnit.Framework;

[TestFixture]
public class Rotator_Tests
{
    /// <summary>
    ///    0                2
    ///   /  \             / \
    ///  1    2      ->   0   4       
    ///      / \         / \                              
    ///     3   4       1   3  
    /// </summary>
    [Test]
    public void Test_PerformLeftRotation()
    {
        var root = new Node(0)
        {
           left = new Node(1),
           right = new Node(2)
           {
               left = new Node(3),
               right = new Node(4)
           }
        };

        var newRoot = Rotator.PerformLeftRotation(root);

        newRoot.val.Should().Be(2);

        newRoot.left.val.Should().Be(0);
        newRoot.left.left.val.Should().Be(1);
        newRoot.left.right.val.Should().Be(3);
        newRoot.left.left.left.Should().BeNull();
        newRoot.left.left.right.Should().BeNull();
        newRoot.left.right.left.Should().BeNull();
        newRoot.left.right.right.Should().BeNull();

        newRoot.right.val.Should().Be(4);
        newRoot.right.left.Should().BeNull();
        newRoot.right.right.Should().BeNull();

    }

    /// <summary>
    ///     2          0     
    ///    / \    ->  /  \    
    ///   0   4      1    2        
    ///  / \             / \                              
    /// 1   3           3   4 
    /// </summary>
    [Test]
    public void Test_PerformRightRotation()
    {
        var root = new Node(2)
        {
            right = new Node(4),
            left = new Node(0)
            {
                left = new Node(1),
                right = new Node(3)
            }
        };

        var newRoot = Rotator.PerformRightRotation(root);

        newRoot.val.Should().Be(0);

        newRoot.left.val.Should().Be(1);
        newRoot.left.left.Should().BeNull();
        newRoot.left.right.Should().BeNull();

        newRoot.right.val.Should().Be(2);
        newRoot.right.left.val.Should().Be(3);
        newRoot.right.right.val.Should().Be(4);
        newRoot.right.left.left.Should().BeNull();
        newRoot.right.left.right.Should().BeNull();
        newRoot.right.right.left.Should().BeNull();
        newRoot.right.right.right.Should().BeNull();
    }

    /// <summary>
    ///    0                3
    ///   / \              / \
    ///  1   2       ->   0   2       
    ///      /           /                               
    ///     3           1     
    /// </summary>
    [Test]
    public void Test_PerformRightLeftRotation()
    {
        var root = new Node(0)
        {
           left = new Node(1),
           right = new Node(2)
           {
               left = new Node(3),
           }
        };

        var newRoot = Rotator.PerformRightLeftRotation(root, root.right);

        newRoot.val.Should().Be(3);

        newRoot.left.val.Should().Be(0);
        newRoot.left.left.val.Should().Be(1);
        newRoot.left.right.Should().BeNull();
        newRoot.left.left.left.Should().BeNull();
        newRoot.left.left.right.Should().BeNull();

        newRoot.right.val.Should().Be(2);
        newRoot.right.right.Should().BeNull();
        newRoot.right.left.Should().BeNull();
    }
}

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

    public static Node PerformLeftRightRotation(Node node, Node leftNode)
    {
        Node newSubtreeRoot = PerformLeftRotation(leftNode);
        node.left = newSubtreeRoot;
        return PerformRightRotation(node);
    }

    public static Node PerformRightLeftRotation(Node node, Node rightNode)
    {
        Node newSubtreeRoot = PerformRightRotation(rightNode);
        node.right = newSubtreeRoot;
        return PerformLeftRotation(node);
    }
}