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
    internal class IntReader_Tests
    {
        [Test]
        public void Test_1()
        {
            var reader = new IntReader();
            reader.StartNew("123");
            reader.ReadNext().Should().Be(123);
        }

        [Test]
        public void Test_2()
        {
            var reader = new IntReader();
            reader.StartNew("123 34 1");
            reader.ReadNext().Should().Be(123);
            reader.ReadNext().Should().Be(34);
            reader.ReadNext().Should().Be(1);
        }
    }

    [TestFixture]
    internal class Solution_Tests
    {
        [Test]
        public void Test_FindShortestWayToAllNodes_1()
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

        [Test]
        public void Test_FindShortestWayToAllNodes_2()
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
                new Node(5)
                {
                    Connected = new HashSet<Road>()
                    {
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
            res.Should().Equal(24, 3, 15, -1);
        }

        [Test]
        public void Test_FindShortestWayToAllNodes_3()
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
                new Node(5)
                {
                    Connected = new HashSet<Road>()
                    {
                        new Road(6, 1)
                    }
                },
                new Node(6)
                {
                    Connected = new HashSet<Road>()
                    {
                        new Road(5, 1)
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
            res.Should().Equal(24, 3, 15, -1, -1);
        }
    }
}