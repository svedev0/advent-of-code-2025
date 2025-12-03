namespace AOC2025;

internal class Day03
{
	public static void SolvePart1()
	{
		List<string> input = [.. File.ReadAllLines("Day03\\input.txt")];
		List<long> joltages = [];

		foreach (string bank in input)
		{
			int[] batteries = [.. bank.Select(c => int.Parse($"{c}"))];
			int[] values = GetNHighestInts(2, batteries);
			long joltage = long.Parse(string.Join(string.Empty, values));
			joltages.Add(joltage);
		}

		long anwser = joltages.Sum();
		Console.WriteLine($"[Part 1] Answer: {anwser}");
	}

	public static void SolvePart2()
	{
		List<string> input = [.. File.ReadAllLines("Day03\\input.txt")];
		List<long> joltages = [];

		foreach (string bank in input)
		{
			int[] batteries = [.. bank.Select(c => int.Parse($"{c}"))];
			int[] values = GetNHighestInts(12, batteries);
			long joltage = long.Parse(string.Join(string.Empty, values));
			joltages.Add(joltage);
		}

		long anwser = joltages.Sum();
		Console.WriteLine($"[Part 2] Answer: {anwser}");
	}

	private static int[] GetNHighestInts(int n, int[] intArr)
	{
		int toRemove = intArr.Length - n;
		List<int> result = [];

		foreach (int num in intArr)
		{
			while (result.Count > 0 && result[^1] < num && toRemove > 0)
			{
				result.RemoveAt(result.Count - 1);
				toRemove--;
			}
			result.Add(num);
		}

		result = result[..n];
		return [.. result];
	}
}
