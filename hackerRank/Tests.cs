using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
    [TestFixture]
    internal class Solution_Tests
    {
        [Test]
        public void Test()
        {
            var n = new Node(3,
                new Node(5, new Node(1, null, null), new Node(4, null, null)),
                new Node(3, new Node(6, null, null), null));
            preOrder(n);
        }


        public void preOrder(Node root)
        {
            LinkedList<Node> q = new LinkedList<Node>();
            preOrder(root, q);
        }

        public void preOrder(Node n, LinkedList<Node> q)
        {
            Console.Out.Write(n.data + " ");
            q.AddLast(n);
            if (n.left != null)
                preOrder(n.left, q);
            else
            {
                Node fromQ;
                do
                {
                    if (q.Count == 0)
                        return;

                    fromQ = q.Last();
                    q.RemoveLast();
                } while (fromQ.right == null);
                preOrder(fromQ.right);
            }

        }

        internal class Node
        {
            public Node(int data, Node left, Node right)
            {
                this.data = data;
                this.left = left;
                this.right = right;
            }

            public int data;
            public Node left;
            public Node right;
        }


    }
}