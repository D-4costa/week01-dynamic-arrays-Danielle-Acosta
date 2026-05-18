public static class UniqueLetters
{
    public static void Run()
    {
        var test1 = "abcdefghjiklmnopqrstuvwxyz";
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz";
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3));
    }

    /// <summary>
    /// Determine if there are duplicate letters
    /// </summary>
    private static bool AreUniqueLetters(string text)
    {
        HashSet<char> lettersFound = new();

        foreach (char currentLetter in text)
        {
            if (lettersFound.Contains(currentLetter))
            {
                return false;
            }

            lettersFound.Add(currentLetter);
        }

        return true;
    }
}
