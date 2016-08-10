using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;

internal class Solution
{
	private static void Main(String[] args)
	{
		int[] parameters = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();

		var dic = new Dictionary<string, Passion>();
		for (int i = 0; i < parameters[0]; i++)
		{
			var passion = Console.ReadLine();
			dic.Add(passion, new Passion(i));
		}

		var reviews = new List<Review>();
		for (int i = 0; i < parameters[1]; i++)
		{
			var lineTokens = Console.ReadLine().Split(' ').ToArray();
			int reviewerId = int.Parse(lineTokens[0]);
			var reviewTime = UnixTimeStampToDateTime(double.Parse(lineTokens[1]));
			var reviewText = Console.ReadLine();
			reviews.Add(new Review(reviewerId, GetTextScore(reviewTime, reviewText), reviewText));
		}

		HandleReviews(dic, reviews);
		foreach (var pair in dic.OrderBy(pair => pair.Value.InitialOrger))
		{
			var res = pair.Value.Max == null ? -1 : pair.Value.Max.ReviewerId;
			Console.Out.WriteLine(res);
		}
	}

	private static void HandleReviews(Dictionary<string, Passion> dic, List<Review> reviews)
	{
		var orderedReviews = reviews.OrderBy(review => review.ReviewerId).ToList();
		foreach (var review in orderedReviews)
		{
			var handledTokens = new HashSet<string>();
			foreach (var textToken in review.Text.Split(' '))
			{
				if (dic.ContainsKey(textToken) && !handledTokens.Contains(textToken))
				{
					handledTokens.Add(textToken);
					var passion = dic[textToken];
					if (passion.Current == null)
					{
						passion.Current = new PassionScore(review.ReviewerId, review.Score);
					}
					else
					{
						if (passion.Current.ReviewerId != review.ReviewerId)
						{
							passion.PromoteCurrentToMax();
							passion.Current = new PassionScore(review.ReviewerId, review.Score);
						}
						else
						{
							passion.Current.ReviewerScore += review.Score;
						}
					}
				}
			}
		}
		foreach (var passion in dic)
		{
			passion.Value.PromoteCurrentToMax();	
		}
	}

	public static int GetTextScore(DateTime time, string text)
	{
		var score = 0;
		if (time >= new DateTime(2016, 06, 15, 12, 00, 00) && time <= new DateTime(2016, 07, 15, 12, 00, 00))
			score += 20;
		else
			score += 10;

		if (text.Length >= 100)
			score += 20;
		else
			score += 10;

		return score;
	}

	public static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
	{
	    // Unix timestamp is seconds past epoch
	    System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
	    dtDateTime = dtDateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
	    return dtDateTime;
	}
}

internal class Passion
{
	public Passion(int initialOrger)
	{
		InitialOrger = initialOrger;
	}

	public int InitialOrger;
	public PassionScore Max;
	public PassionScore Current;

	public void PromoteCurrentToMax()
	{
		if (Max == null)
		{
			Max = Current;
			return;
		}
		if (Current.ReviewerScore > Max.ReviewerScore)
		{
			Max = Current;
			return;
		}
		if (Current.ReviewerScore == Max.ReviewerScore && Current.ReviewerId < Max.ReviewerId)
		{
			Max = Current;
			return;
		}
		Current = null;
	}
}

internal class PassionScore
{
	public PassionScore(int reviewerId, int reviewerScore)
	{
		ReviewerId = reviewerId;
		ReviewerScore = reviewerScore;
	}

	public int ReviewerId;
	public int ReviewerScore;
}

internal class Review
{
	public Review(int reviewerId, int score, string text)
	{
		ReviewerId = reviewerId;
		Score = score;
		Text = text;
	}

	public int ReviewerId;
	public int Score;
	public string Text;
}
