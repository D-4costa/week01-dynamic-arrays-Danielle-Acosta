public static class Sorting
{
    public static void Run()
    {
        int[] values = { 3, 2, 1, 6, 4, 9, 8 };

        BubbleSort(values);

        Console.WriteLine("Sorted array: { " + string.Join(", ", values) + " }");
    }

    // Simple Bubble Sort implementation
    private static void BubbleSort(int[] data)
    {
        for (int end = data.Length - 1; end >= 0; end--)
        {
            for (int i = 0; i < end; i++)
            {
                if (data[i] > data[i + 1])
                {
                    // swap
                    (data[i], data[i + 1]) = (data[i + 1], data[i]);
                }
            }
        }
    }
}
