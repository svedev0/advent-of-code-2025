namespace AOC2025;

internal class Day11
{
	private record PathState(string Node, string Path);

	public static void SolvePart1()
	{
		List<string> input = [.. File.ReadAllLines("Day11\\input.txt")];

		Dictionary<string, string[]> graph = ParseGraph(input);
		long answer = CountPaths(graph, NewCache(), "you", "out");

		Console.WriteLine($"[Part 1] Answer: {answer}");
	}

	public static void SolvePart2()
	{
		List<string> input = [.. File.ReadAllLines("Day11\\input.txt")];

		Dictionary<string, string[]> graph = ParseGraph(input);
		long dacFft =
			CountPaths(graph, NewCache(), "svr", "dac") *
			CountPaths(graph, NewCache(), "dac", "fft") *
			CountPaths(graph, NewCache(), "fft", "out");
		long fftDac =
			CountPaths(graph, NewCache(), "svr", "fft") *
			CountPaths(graph, NewCache(), "fft", "dac") *
			CountPaths(graph, NewCache(), "dac", "out");
		long answer = dacFft + fftDac;

		Console.WriteLine($"[Part 2] Answer: {answer}");
	}

	private static Dictionary<string, string[]> ParseGraph(List<string> lines)
	{
		Dictionary<string, string[]> connections = new(lines.Count);

		foreach (string line in lines)
		{
			string[] parts = line.Split(' ');
			string from = parts[0].Split(':')[0];
			connections[from] = parts[1..];
		}

		return connections;
	}

	private static Dictionary<string, long> NewCache() => [];

	private static long CountPaths(
		Dictionary<string, string[]> graph,
		Dictionary<string, long> cache,
		string node,
		string target)
	{
		if (cache.TryGetValue(node, out long value))
		{
			return value;
		}

		if (node == target)
		{
			cache[node] = 1;
			return cache[node];
		}

		long result = 0L;
		if (graph.TryGetValue(node, out string[]? neighbours))
		{
			foreach (string next in neighbours)
			{
				result += CountPaths(graph, cache, next, target);
			}
		}

		cache[node] = result;
		return cache[node];
	}
}
