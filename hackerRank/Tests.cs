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
        public void Test_ExpansiveLibs0()
        {
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>()
            {
                {1, new Node(1){Connected = new HashSet<int>(){}}},
                {2, new Node(2){Connected = new HashSet<int>(){}}},
                {3, new Node(3){Connected = new HashSet<int>(){}}},
            };

            Solution.BuildLibraries(allNodes, 2, 1).Should().Be(2+2+2);
        }

        [Test]
        public void Test_ExpansiveLibs1()
        {
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>()
            {
                {1, new Node(1){Connected = new HashSet<int>(){2,3}}},
                {2, new Node(2){Connected = new HashSet<int>(){1,3}}},
                {3, new Node(3){Connected = new HashSet<int>(){2,3}}},
            };

            Solution.BuildLibraries(allNodes, 2, 1).Should().Be(2+1+1);
        }

        [Test]
        public void Test_ExpansiveLibs2()
        {
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>()
            {
                {1, new Node(1){Connected = new HashSet<int>(){2,3}}},
                {2, new Node(2){Connected = new HashSet<int>(){1,3}}},
                {3, new Node(3){Connected = new HashSet<int>(){2,3}}},

                {4, new Node(4){Connected = new HashSet<int>(){5,6}}},
                {5, new Node(5){Connected = new HashSet<int>(){4,6}}},
                {6, new Node(6){Connected = new HashSet<int>(){4,5}}},
            };

            Solution.BuildLibraries(allNodes, 2, 1).Should().Be((2+1+1) + (2+1+1));
        }

        [Test]
        public void Test_ExpansiveRoads()
        {
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>()
            {
                {1, new Node(1){Connected = new HashSet<int>(){2,3}}},
                {2, new Node(2){Connected = new HashSet<int>(){1,3}}},
                {3, new Node(3){Connected = new HashSet<int>(){2,3}}}
            };

            Solution.BuildLibraries(allNodes, 2, 2).Should().Be(2 * 3);
            Solution.BuildLibraries(allNodes, 2, 3).Should().Be(2 * 3);
        }

    }

}