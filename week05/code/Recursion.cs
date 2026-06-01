using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char letter in letters)
        {
            if (!word.Contains(letter))
            {
                PermutationsChoose(results, letters, size, word + letter);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb stairs using recursion and memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Generate all binary strings from a wildcard pattern.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int wildcard = pattern.IndexOf('*');

        if (wildcard == -1)
        {
            results.Add(pattern);
            return;
        }

        string left = pattern[..wildcard];
        string right = pattern[(wildcard + 1)..];

        WildcardBinary(left + "0" + right, results);
        WildcardBinary(left + "1" + right, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            return;
        }

        // Down
        if (maze.IsValidMove(currPath, x, y + 1))
        {
            var newPath = new List<(int, int)>(currPath);
            SolveMaze(results, maze, x, y + 1, newPath);
        }

        // Right
        if (maze.IsValidMove(currPath, x + 1, y))
        {
            var newPath = new List<(int, int)>(currPath);
            SolveMaze(results, maze, x + 1, y, newPath);
        }

        // Up
        if (maze.IsValidMove(currPath, x, y - 1))
        {
            var newPath = new List<(int, int)>(currPath);
            SolveMaze(results, maze, x, y - 1, newPath);
        }

        // Left
        if (maze.IsValidMove(currPath, x - 1, y))
        {
            var newPath = new List<(int, int)>(currPath);
            SolveMaze(results, maze, x - 1, y, newPath);
        }
    }
}
