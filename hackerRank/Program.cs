using System;
using System.Collections.Generic;

internal class Solution
{
	private static void Main(String[] args)
	{
	}

	public static int[][] getLockerDistanceGrid(int cityLength, int cityWidth, int[] lockerXCoordinates, int[] lockerYCoordinates) 
	{
		var cityMap = InitEmptyCityMap(cityLength, cityWidth);

		var points = new List<Coord>();

		FillMapAndPointsWithLockersLocations(lockerXCoordinates, lockerYCoordinates, points, cityMap);

		var nextPoints = new List<Coord>();
		while (points.Count > 0)
		{
			foreach (var point in points)
			{
				HandlePoint(cityMap, point, nextPoints);
			}
			if (nextPoints.Count == 0)
				return cityMap;
			points = nextPoints;
			nextPoints = new List<Coord>();
		}
		return cityMap;
	}

	private static void FillMapAndPointsWithLockersLocations(int[] lockerXCoordinates, int[] lockerYCoordinates,
		List<Coord> points, int[][] cityMap)
	{
		for (int i = 0; i < lockerXCoordinates.Length; i++)
		{
			int x = lockerXCoordinates[i] - 1;
			int y = lockerYCoordinates[i] - 1;
			points.Add(new Coord(x, y));
			cityMap[x][y] = 0;
		}
	}

	private static int[][] InitEmptyCityMap(int cityLength, int cityWidth)
	{
		int[][] cityMap = new int[cityLength][];
		for (int i = 0; i < cityLength; i++)
		{
			cityMap[i] = new int[cityWidth];
			for (int j = 0; j < cityWidth; j++)
			{
				cityMap[i][j] = -1;
			}
		}
		return cityMap;
	}

	private static void HandlePoint(int[][] cityMap, Coord point, List<Coord> nextPoints)
	{
		HandleNextPoint(cityMap, point, point.X+1, point.Y, nextPoints);
		HandleNextPoint(cityMap, point, point.X-1, point.Y, nextPoints);
		HandleNextPoint(cityMap, point, point.X, point.Y+1, nextPoints);
		HandleNextPoint(cityMap, point, point.X, point.Y-1, nextPoints);
	}

	private static void HandleNextPoint(int[][] cityMap, Coord point, int nextPointX, int nextPointY, List<Coord> nextPoints)
	{
		if (   nextPointX < cityMap.Length && nextPointX >= 0
		    && nextPointY < cityMap[0].Length &&  nextPointY >= 0
		    && cityMap[nextPointX][nextPointY] == -1)
		{
			cityMap[nextPointX][nextPointY] = cityMap[point.X][point.Y] + 1;
			nextPoints.Add(new Coord(nextPointX, nextPointY));
		}
	}

	struct Coord
	{
		public Coord(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X;
		public int Y;
	}
}