public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);

        Console.WriteLine("------------");

        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);

        Console.WriteLine("------------");

        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time. We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    private static void DisplaySumPairs(int[] numbers) {

        var valuesSeen = new HashSet<int>();

        foreach (var n in numbers)
        {
            if (valuesSeen.Contains(10 - n))
            {
                Console.WriteLine($"{n} {10 - n}");
            }

            valuesSeen.Add(n);
        }
    }
}
