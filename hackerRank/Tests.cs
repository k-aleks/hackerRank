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
			List<Person> p = new List<Person>()
			{
				new Person("p1"),
				new Person("p2"),
				new Person("p3"),
			};

			List<Event> e = new List<Event>()
			{
				new Event("p1"),
				new Event("p2"),
				new Event("p3"),
			};

			int currentDepth = 0;
			int maxDepth = 0;
			Solution.FindMaxHappy(p, e, ref currentDepth, ref maxDepth);

			maxDepth.Should().Be(3);
		}

		[Test]
		public void Test2()
		{
			List<Person> p = new List<Person>()
			{
				new Person("p1"),
				new Person("p2"),
				new Person("p3"),
			};

			List<Event> e = new List<Event>()
			{
				new Event("p1"),
				new Event("p1"),
				new Event("p1"),
			};

			int currentDepth = 0;
			int maxDepth = 0;
			Solution.FindMaxHappy(p, e, ref currentDepth, ref maxDepth);

			maxDepth.Should().Be(1);
		}

		[Test]
		public void Test3()
		{
			List<Person> p = new List<Person>()
			{
				new Person("p1"),
				new Person("p2"),
				new Person("p3"),
			};

			List<Event> e = new List<Event>()
			{
				new Event("p2"),
				new Event("p2"),
				new Event("p2"),
			};

			int currentDepth = 0;
			int maxDepth = 0;
			Solution.FindMaxHappy(p, e, ref currentDepth, ref maxDepth);

			maxDepth.Should().Be(1);
		}

		[Test]
		public void Test4()
		{
			List<Person> p = new List<Person>()
			{
				new Person("p1"),
				new Person("p2"),
				new Person("p3"),
			};

			List<Event> e = new List<Event>()
			{
				new Event("p3"),
				new Event("p2"),
				new Event("p1"),
			};

			int currentDepth = 0;
			int maxDepth = 0;
			Solution.FindMaxHappy(p, e, ref currentDepth, ref maxDepth);

			maxDepth.Should().Be(3);
		}

	}
}