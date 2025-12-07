namespace AOC2025;

internal class Day07
{
	public static void SolvePart1()
	{
		List<string> input = [.. File.ReadAllLines("Day07\\input.txt")];

		char[][] lines = [.. input.Select(line => line.ToCharArray())];
		(int answer, long _) = ComputeBeams(lines);

		Console.WriteLine($"[Part 1] Answer: {answer}");
	}

	public static void SolvePart2()
	{
		List<string> input = [.. File.ReadAllLines("Day07\\input.txt")];

		char[][] lines = [.. input.Select(line => line.ToCharArray())];
		(int _, long answer) = ComputeBeams(lines);

		Console.WriteLine($"[Part 2] Answer: {answer}");
	}

	private static (int Splits, long Timelines) ComputeBeams(char[][] lines)
	{
		int numCols = lines[0].Length;
		int splits = 0;
		long[] timelines = new long[numCols];

		for (int row = 0; row < lines.Length; row++)
		{
			long[] nextTimelines = new long[numCols];

			for (int col = 0; col < numCols; col++)
			{
				if (lines[row][col] == 'S')
				{
					nextTimelines[col] = 1;
				}
				else if (lines[row][col] == '^')
				{
					splits += timelines[col] > 0 ? 1 : 0;
					nextTimelines[col - 1] += timelines[col];
					nextTimelines[col + 1] += timelines[col];
				}
				else
				{
					nextTimelines[col] += timelines[col];
				}
			}

			timelines = nextTimelines;
		}

		return (splits, timelines.Sum());
	}
}
