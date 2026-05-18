public static string[] FindPairs(string[] words)
{
    HashSet<string> checkedWords = new();
    List<string> matches = new();

    foreach (string currentWord in words)
    {
        if (currentWord[0] == currentWord[1])
            continue;

        string backwards = "" + currentWord[1] + currentWord[0];

        if (checkedWords.Contains(backwards))
        {
            matches.Add($"{currentWord} & {backwards}");
        }

        checkedWords.Add(currentWord);
    }

    return matches.ToArray();
}
