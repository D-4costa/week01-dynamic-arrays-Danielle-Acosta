public static class ComplexStack
{
    public static bool DoSomethingComplicated(string line)
    {
        var stack = new Stack<char>();

        foreach (var item in line)
        {
            // Save opening symbols
            if (item is '(' or '[' or '{')
            {
                stack.Push(item);
            }

            // Check closing parenthesis
            else if (item == ')')
            {
                if (stack.Count == 0 || stack.Pop() != '(')
                {
                    return false;
                }
            }

            // Check closing bracket
            else if (item == ']')
            {
                if (stack.Count == 0 || stack.Pop() != '[')
                {
                    return false;
                }
            }

            // Check closing brace
            else if (item == '}')
            {
                if (stack.Count == 0 || stack.Pop() != '{')
                {
                    return false;
                }
            }
        }

        // Stack should be empty if everything matched correctly
        return stack.Count == 0;
    }
}
