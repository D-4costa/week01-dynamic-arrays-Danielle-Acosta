using System;
using System.Collections.Generic;

public static class Divisors {
    public static void Run() {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}");
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}");
    }

    private static List<int> FindDivisors(int number) {
        // PLAN:
        // 1. Create an empty list.
        // 2. Loop from 1 to number - 1.
        // 3. If number % i == 0, add i to list.
        // 4. Return list.

        List<int> results = new();

        for (int i = 1; i < number; i++) {
            if (number % i == 0) {
                results.Add(i);
            }
        }

        return results;
    }
}