using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
	[TestFixture]
	internal class Solution_Tests
	{
		[Test]
		public void Test1()
		{
			var node = new Node("1");
			var res = Solution.FindCycle(node, new Dictionary<string, Node>());
			res.Should().BeFalse();
		}

		[Test]
		public void Test2()
		{
			var node1 = new Node("1");
			var node2 = new Node("2");
			var node3 = new Node("3");
			node1.AddChild(node2);
			node1.AddChild(node3);
			var res = Solution.FindCycle(node1, new Dictionary<string, Node>());
			res.Should().BeFalse();
		}

		[Test]
		public void Test3()
		{
			var node1 = new Node("1");
			var node2 = new Node("2");
			node1.AddChild(node2);
			node2.AddChild(node1);
			var res = Solution.FindCycle(node1, new Dictionary<string, Node>());
			res.Should().BeTrue();
		}

		[Test]
		public void Test4()
		{
			var node1 = new Node("1");
			var node2 = new Node("2");
			var node3 = new Node("3");
			node1.AddChild(node2);
			node2.AddChild(node3);
			node3.AddChild(node1);
			var res = Solution.FindCycle(node1, new Dictionary<string, Node>());
			res.Should().BeTrue();
		}

	}
}