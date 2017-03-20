using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
    [TestFixture]
    internal class Solution_Tests
    {
        [Test]
        public void Test_FindShortestWayToAllNodes()
        {
            var nodes = new[]
            {
                new Node(1)
                {
                    Connected = new HashSet<Road>()
                    {
                        new Road(2, 24),
                        new Road(4, 20),
                        new Road(3, 3),
                    }
                },
                new Node(2)
                {
                    Connected = new HashSet<Road>()
                    {
                        new Road(1, 24),
                    }
                },
                new Node(3)
                {
                    Connected = new HashSet<Road>()
                    {
                        new Road(1, 3),
                        new Road(4, 12),
                    }
                },
                new Node(4)
                {
                    Connected = new HashSet<Road>()
                    {
                        new Road(1, 20),
                        new Road(3, 12),
                    }
                },
            }.ToDictionary(node => node.Id);

            Solution.FindShortestWayToAllNodes(nodes, 1);

            var res = new List<int>();
            for (int i = 1; i < nodes.Count+1; i++)
            {
                if (i == 1)
                     continue;

                var n = nodes[i];
                res.Add(n.Dist == int.MaxValue ? -1 : n.Dist);
            }
            res.Should().Equal(24, 3, 15);
        }
    }
}