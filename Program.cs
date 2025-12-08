using System.Diagnostics;

namespace AOC2025;

internal class Program
{
	public static void Main(string[] args)
	{
		int day = ValidateArgs(args);

		Console.WriteLine($"""
			===== Advent of Code 2025 =====

			Day {day:D2}:
			
			""");

		long startTime = Stopwatch.GetTimestamp();

		switch (day)
		{
			case 1:
				Day01.SolvePart1();
				Day01.SolvePart2();
				break;
			case 2:
				Day02.SolvePart1();
				Day02.SolvePart2();
				break;
			case 3:
				Day03.SolvePart1();
				Day03.SolvePart2();
				break;
			case 4:
				Day04.SolvePart1();
				Day04.SolvePart2();
				break;
			case 5:
				Day05.SolvePart1();
				Day05.SolvePart2();
				break;
			case 6:
				Day06.SolvePart1();
				Day06.SolvePart2();
				break;
			case 7:
				Day07.SolvePart1();
				Day07.SolvePart2();
				break;
			case 8:
				Day08.SolvePart1();
				Day08.SolvePart2();
				break;
			default:
				Console.WriteLine("Day not found");
				break;
		}

		TimeSpan elapsed = Stopwatch.GetElapsedTime(startTime);
		int elapsedMs = (int)Math.Floor(elapsed.TotalMilliseconds);
		Console.WriteLine($"The program finished in {elapsedMs} ms");
	}

	private static int ValidateArgs(string[] args)
	{
		if (args.Length != 1 || !args[0].StartsWith("-day="))
		{
			throw new Exception("Missing argument 'day'. Example: '-day=1'");
		}

		string dayStr = args[0][5..].Trim();
		if (!int.TryParse(dayStr, out int day) || day is < 1 or > 12)
		{
			throw new Exception("Invalid value for 'day'");
		}

		return day;
	}
}
