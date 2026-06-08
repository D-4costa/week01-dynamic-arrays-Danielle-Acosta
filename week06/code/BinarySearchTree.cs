using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new value into the BST.
    /// </summary>
    public void Insert(int value)
    {
        Node newNode = new(value);

        if (_root is null)
        {
            _root = newNode;
        }
        else
        {
            _root.Insert(value);
        }
    }

    /// <summary>
    /// Determine whether the tree contains the specified value.
    /// </summary>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Traverse the tree from smallest to largest.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();

        TraverseForward(_root, numbers);

        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Traverse the tree from largest to smallest.
    /// </summary>
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();

        TraverseBackward(_root, numbers);

        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            // Visit the right subtree first so larger values appear first.
            TraverseBackward(node.Right, values);

            values.Add(node.Data);

            // Visit the left subtree last.
            TraverseBackward(node.Left, values);
        }
    }

    /// <summary>
    /// Return the height of the BST.
    /// </summary>
    public int GetHeight()
    {
        if (_root is null)
        {
            return 0;
        }

        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
