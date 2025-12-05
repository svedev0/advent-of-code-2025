namespace AOC2025;

internal class Day05
{
	public static void SolvePart1()
	{
		List<string> input = [.. File.ReadAllLines("Day05\\input.txt")];

		List<(long, long)> freshRanges = ParseFreshIdRanges(input);
		long[] availableIds = ParseAvailableIds(input);
		List<long> freshIds = [];

		foreach ((long start, long end) in freshRanges)
		{
			foreach (long id in availableIds)
			{
				if (id >= start && id <= end && !freshIds.Contains(id))
				{
					freshIds.Add(id);
				}
			}
		}

		long answer = freshIds.Count;
		Console.WriteLine($"[Part 1] Answer: {answer}");
	}

	public static void SolvePart2()
	{
		List<string> input = [.. File.ReadAllLines("Day05\\input.txt")];

		List<(long, long)> freshRanges = [.. ParseFreshIdRanges(input)
			.OrderBy(r => r.Item1)];
		List<(long Start, long End)> mergedRanges = [freshRanges[0]];

		foreach ((long start, long end) in freshRanges.Skip(1))
		{
			(long lastStart, long lastEnd) = mergedRanges[^1];
			if (start <= lastEnd && end >= lastStart)
			{
				mergedRanges[^1] = (lastStart, Math.Max(lastEnd, end));
				continue;
			}
			mergedRanges.Add((start, end));
		}

		long answer = mergedRanges.Sum(r => r.End - r.Start + 1);
		Console.WriteLine($"[Part 2] Answer: {answer}");
	}

	private static List<(long, long)> ParseFreshIdRanges(List<string> input)
	{
		return [.. input
			.Where(l => l.Contains('-'))
			.Select(l =>
			{
				string[] parts = l.Split('-');
				return (long.Parse(parts[0]), long.Parse(parts[1]));
			})];
	}

	private static long[] ParseAvailableIds(List<string> input)
	{
		return [.. input
			.Where(l => !l.Contains('-') && !string.IsNullOrEmpty(l))
			.Select(long.Parse)];
	}
}
