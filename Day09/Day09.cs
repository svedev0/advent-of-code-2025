namespace AOC2025;

internal class Day09
{
	private record Tile(int X, int Y);
	private record Line(Tile A, Tile B);

	public static void SolvePart1()
	{
		List<string> input = [.. File.ReadAllLines("Day09\\input.txt")];

		Tile[] redTiles = [.. input
			.Select(line => line.Split(','))
			.Select(parts => new Tile(
				int.Parse(parts[0]),
				int.Parse(parts[1]))
			)];
		long largestArea = 0L;

		for (int i = 0; i < redTiles.Length; i++)
		{
			Tile a = redTiles[i];

			for (int j = 0; j < redTiles.Length; j++)
			{
				Tile b = redTiles[j];
				long area = GetArea(a, b);

				if (area > largestArea)
				{
					largestArea = area;
				}
			}
		}

		Console.WriteLine($"[Part 1] Answer: {largestArea}");
	}

	public static void SolvePart2()
	{
		List<string> input = [.. File.ReadAllLines("Day09\\input.txt")];

		Tile[] redTiles = [.. input
			.Select(line => line.Split(','))
			.Select(parts => new Tile(
				int.Parse(parts[0]),
				int.Parse(parts[1]))
			)];
		int numRedTiles = redTiles.Length;

		Line[] lines = new Line[numRedTiles];
		for (int i = 0; i < numRedTiles; i++)
		{
			lines[i] = new Line(redTiles[i], redTiles[(i + 1) % numRedTiles]);
		}

		long largestArea = 0;

		for (int i = 0; i < numRedTiles; i++)
		{
			Tile a = redTiles[i];
			long localMax = 0L;

			for (int j = 0; j < numRedTiles; j++)
			{
				Tile b = redTiles[j];
				long area = GetArea(a, b);

				if (area > localMax)
				{
					bool hasIntersection = false;

					foreach (Line l in lines)
					{
						hasIntersection |= LinesIntersect(l.A, l.B, a, b);
						if (hasIntersection)
						{
							break;
						}
					}

					localMax = hasIntersection ? localMax : area;
				}
			}

			if (localMax > largestArea)
			{
				largestArea = localMax;
			}
		}

		Console.WriteLine($"[Part 2] Answer: {largestArea}");
	}

	private static long GetArea(Tile a, Tile b)
	{
		return
			((long)Math.Abs(a.X - b.X) + 1) *
			((long)Math.Abs(a.Y - b.Y) + 1);
	}

	private static bool LinesIntersect(Tile a1, Tile a2, Tile b1, Tile b2)
	{
		(int aMinX, int aMaxX) = MinMax(a1.X, a2.X);
		(int aMinY, int aMaxY) = MinMax(a1.Y, a2.Y);
		(int bMinX, int bMaxX) = MinMax(b1.X, b2.X);
		(int bMinY, int bMaxY) = MinMax(b1.Y, b2.Y);

		return bMaxX > aMinX && bMinX < aMaxX && bMaxY > aMinY && bMinY < aMaxY;
	}

	private static (int Min, int Max) MinMax(int a, int b)
	{
		return a < b ? (a, b) : (b, a);
	}
}
