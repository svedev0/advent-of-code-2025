namespace AOC2025;

internal class Day04
{
	public static void SolvePart1()
	{
		List<string> input = [.. File.ReadAllLines("Day04\\input.txt")];
		bool[][] map = [.. input
			.Select(line => line
				.Select(c => c == '@').ToArray())];

		int numAccessible = 0;

		for (int row = 0; row < map.Length; row++)
		{
			for (int col = 0; col < map[0].Length; col++)
			{
				if (!map[row][col])
				{
					continue;
				}

				bool[] adjacent = GetAdjacent(map, row, col);
				if (adjacent.Count(b => b) < 4)
				{
					numAccessible++;
				}
			}
		}

		Console.WriteLine($"[Part 1] Answer: {numAccessible}");
	}

	public static void SolvePart2()
	{
		List<string> input = [.. File.ReadAllLines("Day04\\input.txt")];
		bool[][] map = [.. input
			.Select(line => line
				.Select(c => c == '@').ToArray())];

		int numAccessible = 0;
		bool removed = true;

		while (removed)
		{
			removed = false;

			for (int row = 0; row < map.Length; row++)
			{
				for (int col = 0; col < map[0].Length; col++)
				{
					if (!map[row][col])
					{
						continue;
					}

					bool[] adjacent = GetAdjacent(map, row, col);
					if (adjacent.Count(b => b) < 4)
					{
						map[row][col] = false;
						removed = true;
						numAccessible++;
					}
				}
			}
		}

		Console.WriteLine($"[Part 2] Answer: {numAccessible}");
	}

	private static bool[] GetAdjacent(bool[][] map, int row, int col)
	{
		int numRows = map.Length;
		int numCols = map[0].Length;

		return [
			row > 0 && col > 0 && map[row - 1][col - 1],                     // top-left
			row > 0 && map[row - 1][col],                                    // top-middle
			row > 0 && col < numCols - 1 && map[row - 1][col + 1],           // top-right
			col > 0 && map[row][col - 1],                                    // middle-left
			col < numCols - 1 && map[row][col + 1],                          // middle-right
			row < numRows - 1 && col > 0 && map[row + 1][col - 1],           // bottom-left
			row < numRows - 1 && map[row + 1][col],                          // bottom-middle
			row < numRows - 1 && col < numCols - 1 && map[row + 1][col + 1], // bottom-right
		];
	}
}
