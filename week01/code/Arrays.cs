using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create a new array of type double with size equal to "length".
        // 2. Use a loop from index 0 to length - 1.
        // 3. For each index i, calculate number * (i + 1).
        // 4. Store the result in the array.
        // 5. Return the array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the list to the right by the given amount.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Rotating right means moving the last "amount" elements to the front.
        // 2. Use modulo (%) to handle cases where amount == data.Count.
        // 3. Find split index: data.Count - amount.
        // 4. Copy the last "amount" elements using GetRange.
        // 5. Remove those elements from the original list using RemoveRange.
        // 6. Insert them at the beginning using InsertRange.

        int n = data.Count;

        amount = amount % n;

        int splitIndex = n - amount;

        List<int> tail = data.GetRange(splitIndex, amount);

        data.RemoveRange(splitIndex, amount);

        data.InsertRange(0, tail);
    }
}