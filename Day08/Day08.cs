namespace AOC2025;

internal class Day08
{
	private record Junction(decimal X, decimal Y, decimal Z);

	public static void SolvePart1()
	{
		List<string> input = [.. File.ReadAllLines("Day08\\input.txt")];

		Junction[] junctions = ParseJunctions(input);

		Dictionary<Junction, HashSet<Junction>> juncToCirc = junctions
			.ToDictionary(
				p => p,
				p => new HashSet<Junction>([p]));
		List<(Junction a, Junction b)> pairs = GetOrderedPairs(junctions);

		foreach ((Junction a, Junction b) in pairs.Take(1000))
		{
			if (juncToCirc[a] != juncToCirc[b])
			{
				Connect(a, b, juncToCirc);
			}
		}

		HashSet<Junction>[] largest3Circuits = [.. juncToCirc.Values
			.Distinct()
			.OrderByDescending(set => set.Count)
			.Take(3)];

		decimal answer = largest3Circuits.Aggregate(1, (a, b) => a * b.Count);

		if (answer != 133574m)
		{
			throw new Exception("Incorrect answer for Part 1");
		}

		Console.WriteLine($"[Part 1] Answer: {answer}");
	}

	public static void SolvePart2()
	{
		List<string> input = [.. File.ReadAllLines("Day08\\input.txt")];

		Junction[] junctions = ParseJunctions(input);
		Dictionary<Junction, HashSet<Junction>> juncToCirc = junctions
			.ToDictionary(
				p => p,
				p => new HashSet<Junction>([p]));
		List<(Junction a, Junction b)> pairs = GetOrderedPairs(junctions);

		int numJunctions = junctions.Length;
		decimal answer = 0m;

		foreach ((Junction a, Junction b) in pairs.TakeWhile(_ => numJunctions > 1))
		{
			if (juncToCirc[a] != juncToCirc[b])
			{
				Connect(a, b, juncToCirc);
				answer = a.X * b.X;
				numJunctions--;
			}
		}

		if (answer != 2435100380m)
		{
			throw new Exception("Incorrect answer for Part 1");
		}

		Console.WriteLine($"[Part 2] Answer: {answer}");
	}

	private static Junction[] ParseJunctions(List<string> lines)
	{
		return [.. lines
			.Select(line => line.Split(','))
			.Select(parts => new Junction(
				decimal.Parse(parts[0]),
				decimal.Parse(parts[1]),
				decimal.Parse(parts[2]))
		)];
	}

	private static List<(Junction a, Junction b)> GetOrderedPairs(Junction[] junctions)
	{
		return [.. junctions
			.SelectMany(a => junctions, (a, b) => (a, b))
			.Where(t => (t.a.X, t.a.Y, t.a.Z).CompareTo((t.b.X, t.b.Y, t.b.Z)) < 0)
			.OrderBy(t => Metric(t.a, t.b))];
	}

	private static decimal Metric(Junction a, Junction b)
	{
		return
			(a.X - b.X) * (a.X - b.X) +
			(a.Y - b.Y) * (a.Y - b.Y) +
			(a.Z - b.Z) * (a.Z - b.Z);
	}

	private static void Connect(
		Junction a, Junction b, Dictionary<Junction, HashSet<Junction>> juncToCirc)
	{
		juncToCirc[a].UnionWith(juncToCirc[b]);
		foreach (Junction j in juncToCirc[b])
		{
			juncToCirc[j] = juncToCirc[a];
		}
	}
}
