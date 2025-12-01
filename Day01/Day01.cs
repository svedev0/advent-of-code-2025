namespace AOC2025;

internal class Day01
{
	public static void SolvePart1()
	{
		List<string> input = [.. File.ReadAllLines("Day01\\input.txt")];

		int dial = 50;
		int zeros = 0;

		foreach (string line in input)
		{
			char dir = line[0];
			int dist = int.Parse(line[1..]);

			if (dir == 'R')
			{
				for (int i = 0; i < dist; i++)
				{
					dial++;
					if (dial > 99)
					{
						dial = 0;
					}
				}
				if (dial == 0)
				{
					zeros++;
				}
			}
			else if (dir == 'L')
			{
				for (int i = 0; i < dist; i++)
				{
					dial--;
					if (dial < 0)
					{
						dial = 99;
					}
				}
				if (dial == 0)
				{
					zeros++;
				}
			}
		}

		Console.WriteLine($"[Part 1] Answer: {zeros}");
	}

	public static void SolvePart2()
	{
		List<string> input = [.. File.ReadAllLines("Day01\\input.txt")];

		int dial = 50;
		int zeros = 0;

		foreach (string line in input)
		{
			char dir = line[0];
			int dist = int.Parse(line[1..]);

			if (dir == 'R')
			{
				for (int i = 0; i < dist; i++)
				{
					dial++;
					if (dial > 99)
					{
						dial = 0;
					}
					if (dial == 0)
					{
						zeros++;
					}
				}
			}
			else if (dir == 'L')
			{
				for (int i = 0; i < dist; i++)
				{
					dial--;
					if (dial < 0)
					{
						dial = 99;
					}
					if (dial == 0)
					{
						zeros++;
					}
				}
			}
		}

		Console.WriteLine($"[Part 2] Answer: {zeros}");
	}
}
