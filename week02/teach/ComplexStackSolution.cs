public static class ComplexStackSolution
{
    public static void Main()
    {
        // True (all symbols are balanced)
        Console.WriteLine(CheckBraces("(a == 3 or (b == 5 and c == 6))"));

        // False (wrong closing bracket)
        Console.WriteLine(CheckBraces("(students]i].Grade > 80 and students[i].Grade < 90"));

        // False (missing closing parenthesis)
        Console.WriteLine(CheckBraces("(robot[id + 1].Execute(.Pass() || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))"));
    }

    public static bool CheckBraces(string line)
    {
        var stack = new Stack<char>();

        foreach (var item in line)
        {
            if (item is '(' or '[' or '{')
            {
                stack.Push(item);
            }
            else if (item == ')')
            {
                if (stack.Count == 0 || stack.Pop() != '(')
                {
                    return false;
                }
            }
            else if (item == ']')
            {
                if (stack.Count == 0 || stack.Pop() != '[')
                {
                    return false;
                }
            }
            else if (item == '}')
            {
                if (stack.Count == 0 || stack.Pop() != '{')
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}
