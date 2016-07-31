using System;
using System.Collections.Generic;
using System.Linq;

namespace hackerRank
{
	internal class Class1
	{
		public List<string> getDirectFriendsForUser(string user)
		{
			throw new NotImplementedException();
		}

		public List<string> getAttendedCoursesForUser(string user)
		{
			throw new NotImplementedException();
		}

		public List<string> getRankedCourses(string user)
		{
			var attendedCourses = new HashSet<string>(getAttendedCoursesForUser(user));

			var handledUsers = new HashSet<string>();

			var coursesWithRank = new Dictionary<string, int>();

			foreach (var directFriend in getDirectFriendsForUser(user))
			{
				HandleUser(directFriend, handledUsers, coursesWithRank, attendedCourses);
				foreach (var directFriendOfDirectFriend in getDirectFriendsForUser(directFriend))
				{
					HandleUser(directFriendOfDirectFriend, handledUsers, coursesWithRank, attendedCourses);
				}
			}

			var courses = coursesWithRank.Select(pair => new Course(pair.Key, pair.Value)).ToArray();
			return courses.OrderByDescending(course => course.Rank).Select(course => course.CourseId).ToList();
		}

		private void HandleUser(string friend, HashSet<string> handledUsers, Dictionary<string, int> coursesWithRank, HashSet<string> attendedCourses)
		{
			if (handledUsers.Contains(friend))
				return;
			handledUsers.Add(friend);

			foreach (var courseId in getAttendedCoursesForUser(friend))
			{
				if (!attendedCourses.Contains(courseId))
				{
					if (!coursesWithRank.ContainsKey(courseId))
						coursesWithRank.Add(courseId, 0);
					coursesWithRank[courseId] += 1;
				}
			}
		}

		struct Course
		{
			public Course(string courseId, int rank)
			{
				CourseId = courseId;
				Rank = rank;
			}

			public string CourseId;
			public int Rank;
		}
	}

}