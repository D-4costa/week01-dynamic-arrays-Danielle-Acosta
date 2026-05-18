public static class DisplaySums
{
    public static void Run()
    {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);

        Console.WriteLine("------------");

        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);

        Console.WriteLine("------------");

        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
    }

    /// <summary>
    /// Display pairs of numbers that sum to 10
    /// </summary>
    private static void DisplaySumPairs(int[] numbers)
    {
        HashSet<int> previousNumbers = new();

        foreach (int currentNumber in numbers)
        {
            int neededValue = 10 - currentNumber;

            if (previousNumbers.Contains(neededValue))
            {
                Console.WriteLine($"{currentNumber} {neededValue}");
            }

            previousNumbers.Add(currentNumber);
        }
    }
}
