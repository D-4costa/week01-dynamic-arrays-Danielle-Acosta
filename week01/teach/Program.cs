using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n======================\nArrays\n======================");
        var multiples = Arrays.MultiplesOf(3, 5);
        Console.WriteLine("Result → " + string.Join(", ", multiples));

        var numbers = new List<int> { 1,2,3,4,5,6,7,8,9 };
        Arrays.RotateListRight(numbers, 3);
        Console.WriteLine("Rotated → " + string.Join(", ", numbers));

        Console.WriteLine("\n======================\nDivisors\n======================");
        Divisors.Run();

        Console.WriteLine("\n======================\nArray Selector\n======================");
        ArraySelector.Run();

    }
}