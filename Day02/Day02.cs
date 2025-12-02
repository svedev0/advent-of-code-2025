namespace AOC2025;

internal class Day02
{
	public static void SolvePart1()
	{
		string input = File.ReadAllText("Day02\\input.txt");
		string[] ranges = input.Split(',');

		List<long> invalidIds = [];

		foreach (string range in ranges)
		{
			string[] fromToStr = range.Split('-');
			long from = long.Parse(fromToStr[0]);
			long to = long.Parse(fromToStr[1]);

			for (long id = from; id <= to; id++)
			{
				string idStr = id.ToString();
				if (idStr.Length % 2 != 0)
				{
					continue;
				}

				string idLeftHalf = idStr[..(idStr.Length / 2)];
				string idRightHalf = idStr[(idStr.Length / 2)..];
				if (idLeftHalf == idRightHalf)
				{
					invalidIds.Add(id);
				}
			}
		}

		long answer = invalidIds.Sum();
		Console.WriteLine($"[Part 1] Answer: {answer}");
	}

	public static void SolvePart2()
	{
		string input = File.ReadAllText("Day02\\input.txt");
		string[] ranges = input.Split(',');

		List<long> invalidIds = [];

		foreach (string range in ranges)
		{
			string[] fromToStr = range.Split('-');
			long from = long.Parse(fromToStr[0]);
			long to = long.Parse(fromToStr[1]);

			for (long id = from; id <= to; id++)
			{
				string idStr = id.ToString();

				for (int size = idStr.Length / 2; size >= 1; size--)
				{
					string chunk = idStr[..size];
					if (idStr.Chunk(size).All(c => c.SequenceEqual(chunk)))
					{
						invalidIds.Add(id);
						break;
					}
				}
			}
		}

		long answer = invalidIds.Sum();
		Console.WriteLine($"[Part 2] Answer: {answer}");
	}
}
