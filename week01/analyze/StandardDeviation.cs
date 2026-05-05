/// <summary>
/// Calculates standard deviation using three different approaches.
/// Standard deviation = sqrt(variance)
/// Variance = average of squared differences from the mean.
/// </summary>
public static class StandardDeviation
{
    public static void Run()
    {
        int[] data = { 600, 470, 170, 430, 300 };

        Console.WriteLine(StandardDev_Method1(data));
        Console.WriteLine(StandardDev_Method2(data));
        Console.WriteLine(StandardDev_Method3(data));
    }

    // Efficient approach (two passes)
    private static double StandardDev_Method1(int[] numbers)
    {
        double sum = 0;
        foreach (var n in numbers)
            sum += n;

        double mean = sum / numbers.Length;

        double varianceSum = 0;
        foreach (var n in numbers)
            varianceSum += Math.Pow(n - mean, 2);

        double variance = varianceSum / numbers.Length;
        return Math.Sqrt(variance);
    }

    // Inefficient approach (recalculates mean every time)
    private static double StandardDev_Method2(int[] numbers)
    {
        double varianceSum = 0;

        foreach (var n in numbers)
        {
            double sum = 0;
            foreach (var x in numbers)
                sum += x;

            double mean = sum / numbers.Length;
            varianceSum += Math.Pow(n - mean, 2);
        }

        double variance = varianceSum / numbers.Length;
        return Math.Sqrt(variance);
    }

    // Using built-in helpers (cleanest)
    private static double StandardDev_Method3(int[] numbers)
    {
        double mean = numbers.Average();

        double varianceSum = 0;
        foreach (var n in numbers)
            varianceSum += Math.Pow(n - mean, 2);

        double variance = varianceSum / numbers.Length;
        return Math.Sqrt(variance);
    }
}
