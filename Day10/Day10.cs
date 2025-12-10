namespace AOC2025;

internal class Day10
{
	private record Machine(int Lights, int[] Buttons, int[] Joltages);

	public static void SolvePart1()
	{
		List<string> input = [.. File.ReadAllLines("Day10\\input.txt")];

		Machine[] machines = [.. input.Select(ParseMachine)];
		int result = 0;

		foreach (Machine m in machines)
		{
			int limit = 1 << m.Buttons.Length;
			int[] tries = [.. Enumerable.Range(0, limit).OrderBy(CountBits)];

			int matchingMask = -1;
			foreach (int mask in tries)
			{
				if ((ExclusiveOr(m.Buttons, mask) ^ m.Lights) == 0)
				{
					matchingMask = mask;
					break;
				}
			}

			if (matchingMask == -1)
			{
				throw new Exception();
			}

			result += CountBits(matchingMask);
		}

		Console.WriteLine($"[Part 1] Answer: {result}");
	}

	public static void SolvePart2()
	{
		// I gave up on this one
		Console.WriteLine($"[Part 2] Answer: ???");
	}

	private static Machine ParseMachine(string line)
	{
		string[] parts = line.Split(' ');

		string lightsBitsStr = string.Join(string.Empty,
			parts.First()[1..^1]
				.Replace('.', '0')
				.Replace('#', '1')
				.Reverse());
		int lights = Convert.ToInt32(lightsBitsStr, 2);

		int[] buttons = [.. parts[1..^1]
			.Select(s => s[1..^1]
				.Split(',')
				.Select(int.Parse)
				.Select(d => 1 << d)
				.Sum())];

		int[] jolts = [.. parts.Last()[1..^1].Split(",").Select(int.Parse)];

		return new Machine(lights, buttons, jolts);
	}

	private static int CountBits(int mask)
	{
		int result = 0;

		while (mask != 0)
		{
			mask &= mask - 1;
			result++;
		}

		return result;
	}

	private static int ExclusiveOr(int[] buttons, int mask)
	{
		int result = 0;
		int idx = 0;

		while (mask != 0)
		{
			if ((mask & 1) != 0)
			{
				result ^= buttons[idx];
			}

			mask >>= 1;
			idx++;
		}

		return result;
	}
}
