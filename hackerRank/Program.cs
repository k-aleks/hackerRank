using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Solution
{
	private static void Main(String[] args)
	{
		int n = int.Parse(Console.ReadLine());
		var persons = new List<Person>();
		for (int i = 0; i < n; i++)
		{
			var personPassions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Skip(2).ToArray();
			persons.Add(new Person(personPassions));
		}
		var events = new List<Event>();
		for (int i = 0; i < n; i++)
		{
			var eventPassions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
			events.Add(new Event(eventPassions));
		}

		int currentDepth = 0;
		int maxDepth = 0;
		FindMaxHappy(persons, events, ref currentDepth, ref maxDepth);

		Console.Out.WriteLine(maxDepth);
	}

	public static void FindMaxHappy(List<Person> persons, List<Event> events, ref int currentDepth, ref int maxDepth)
	{
		foreach (var person in persons.Where(p => !p.Taken))
		{
			person.Taken = true;
			List<Event> possibleEvents = GetPossibleEvents(person, events);
			foreach (var ev in possibleEvents)
			{
				ev.Taken = true;
				currentDepth++;
				if (maxDepth < currentDepth)
					maxDepth = currentDepth;
				FindMaxHappy(persons, events, ref currentDepth, ref maxDepth);
				currentDepth--;
				ev.Taken = false;
			}
			person.Taken = false;
		}
	}

	private static List<Event> GetPossibleEvents(Person person, List<Event> events)
	{
		var res = new List<Event>();
		foreach (var ev in events)
		{
			if (!ev.Taken && person.Passions.Any(passion => ev.Passions.Contains(passion)))
			{
				res.Add(ev);
			}
		}
		return res;
	}
}

class Event
{
	public Event(params string[] passions)
	{
		Passions = new HashSet<string>(passions);
	}

	public bool Taken = false;
	public HashSet<string> Passions;
}

class Person
{
	public Person(params string[] passions)
	{
		Passions = new List<string>(passions);
	}

	public bool Taken = false;
	public List<string> Passions;
}