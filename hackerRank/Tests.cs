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
        /// <summary>
        ///     3              3    
        ///   /  \            /  \              
        ///  2    4          2    5 
        ///        \            /  \     
        ///         5          4   6  
        /// </summary>
        [Test]
        public void Test_InsertNode()
        {
            var root = new Node(3)
            {
                left = new Node(2),
                right = new Node(4)
                {
                    right = new Node(5)
                }
            };

            TreeHeightCalculator.CalcHeighForEachNode(root);

            var newRoot = Solution.InsertNode(root, 6);
            newRoot.val.Should().Be(3);
            newRoot.left.val.Should().Be(2);
            newRoot.right.val.Should().Be(5);
            newRoot.right.left.val.Should().Be(4);
            newRoot.right.right.val.Should().Be(6);


        }

        [Test]
        public void Test_GetBalanceFactor_1()
        {
            var node = new Node();
            Solution.GetBalanceFactor(node).Should().Be(0);
        }

        [Test]
        public void Test_GetBalanceFactor_2()
        {
            var node = new Node()
            {
                ht = 1,
                left = new Node()
                {
                    ht = 0
                }
            };
            Solution.GetBalanceFactor(node).Should().Be(1);
        }

        [Test]
        public void Test_GetBalanceFactor_3()
        {
            var node = new Node()
            {
                ht = 1,
                right = new Node()
                {
                    ht = 0
                }
            };
            Solution.GetBalanceFactor(node).Should().Be(-1);
        }

    }
}