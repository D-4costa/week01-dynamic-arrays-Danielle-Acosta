public static class Trees
{
    /// <summary>
    /// Creates a balanced BST from a sorted array.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();

        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);

        return bst;
    }

    /// <summary>
    /// Recursively inserts the middle element of the current range.
    /// This keeps the tree balanced and avoids creating an
    /// unbalanced linked-list-shaped tree.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Stop when the range is no longer valid.
        if (first > last)
        {
            return;
        }

        // Determine the middle position of the current range.
        int middle = (first + last) / 2;

        // Insert the middle value into the tree.
        bst.Insert(sortedNumbers[middle]);

        // Recursively process the left half.
        InsertMiddle(sortedNumbers, first, middle - 1, bst);

        // Recursively process the right half.
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}
