namespace AOC2025;

internal class Day06
{
	public static void SolvePart1()
	{
		string[] input = File.ReadAllLines("Day06\\input.txt");

		List<string[]> columns = ParseBlocks(input);
		List<long> results = [];

		foreach (string[] rows in columns)
		{
			long[] nums = [.. rows[..^1].Select(long.Parse)];
			char op = rows[^1][0];
			long result = SolveProblem(nums, op);
			results.Add(result);
		}

		long answer = results.Sum();
		Console.WriteLine($"[Part 1] Answer: {answer}");
	}

	public static void SolvePart2()
	{
		string[] input = File.ReadAllLines("Day06\\input.txt");

		List<string[]> columns = ParseBlocks(input);
		List<string[]> transposedRows = [];

		foreach (string[] rows in columns)
		{
			List<string> transposed = [];
			for (int colIdx = 0; colIdx < rows[0].Length; colIdx++)
			{
				transposed.Add(GetColumn(rows, colIdx));
			}
			transposedRows.Add([.. transposed]);
		}

		List<long> results = [];

		foreach (string[] cols in transposedRows)
		{
			long[] nums = [.. cols.Select(col => long.Parse(col[..^1]))];
			char op = cols[0][^1];
			long result = SolveProblem(nums, op);
			results.Add(result);
		}

		long answer = results.Sum();
		Console.WriteLine($"[Part 2] Answer: {answer}");
	}

	private static long SolveProblem(long[] nums, char op)
	{
		return op switch
		{
			'+' => nums.Sum(),
			'*' => nums.Aggregate(1L, (acc, val) => acc * val),
			_ => throw new Exception("Invalid operator"),
		};
	}

	private static List<string[]> ParseBlocks(string[] input)
	{
		int numCols = input[0].Length;
		int blockStart = 0;

		List<string[]> blocks = [];

		for (int colIdx = 0; colIdx < numCols; colIdx++)
		{
			if (GetColumn(input, colIdx).Trim() == string.Empty)
			{
				blocks.Add(GetBlock(input, blockStart, colIdx));
				blockStart = colIdx + 1;
			}
		}

		blocks.Add(GetBlock(input, blockStart, numCols));
		return blocks;
	}

	private static string[] GetBlock(string[] lines, int fromColIdx, int toColIdx)
	{
		return [.. lines.Select(l => l[fromColIdx..toColIdx])];
	}

	private static string GetColumn(string[] lines, int colIdx)
	{
		return string.Join(string.Empty, lines.Select(l => l[colIdx]));
	}
}
