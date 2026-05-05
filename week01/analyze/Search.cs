using System.Diagnostics;

public static class Search
{
    public static void Run()
    {
        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}",
            "Size", "Linear Count", "Binary Count", "Linear Time", "Binary Time");

        Console.WriteLine(new string('-', 75));

        for (int size = 0; size <= 25000; size += 1000)
        {
            var data = Enumerable.Range(0, size).ToArray();

            int linearCount = SearchLinear(data, size);
            int binaryCount = SearchBinary(data, size, 0, data.Length - 1);

            double linearTime = MeasureTime(() => SearchLinear(data, size), 100);
            double binaryTime = MeasureTime(() => SearchBinary(data, size, 0, data.Length - 1), 100);

            Console.WriteLine("{0,15}{1,15}{2,15}{3,15:0.00000}{4,15:0.00000}",
                size, linearCount, binaryCount, linearTime, binaryTime);
        }
    }

    private static double MeasureTime(Action algorithm, int repetitions)
    {
        var stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < repetitions; i++)
        {
            algorithm();
        }

        stopwatch.Stop();
        return stopwatch.Elapsed.TotalMilliseconds / repetitions;
    }

    // Linear Search (O(n))
    private static int SearchLinear(int[] data, int target)
    {
        int steps = 0;

        foreach (var value in data)
        {
            steps++;
            if (value == target)
                return steps;
        }

        return steps;
    }

    // Binary Search (O(log n))
    private static int SearchBinary(int[] data, int target, int left, int right)
    {
        if (right < left)
            return 1;

        int mid = (left + right) / 2;

        if (data[mid] == target)
            return 1;

        if (data[mid] < target)
            return 1 + SearchBinary(data, target, mid + 1, right);

        return 1 + SearchBinary(data, target, left, mid - 1);
    }
}
