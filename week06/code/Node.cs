public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        Data = data;
    }

    public void Insert(int value)
    {
        // Ignore duplicate values since this BST acts like a sorted set.
        if (value == Data)
        {
            return;
        }

        // Values smaller than the current node belong on the left.
        if (value < Data)
        {
            if (Left is null)
            {
                Left = new Node(value);
            }
            else
            {
                Left.Insert(value);
            }
        }
        else
        {
            // Values larger than the current node belong on the right.
            if (Right is null)
            {
                Right = new Node(value);
            }
            else
            {
                Right.Insert(value);
            }
        }
    }

    public bool Contains(int value)
    {
        // Base case: the value was found.
        if (value == Data)
        {
            return true;
        }

        // Search the left subtree when the target is smaller.
        if (value < Data)
        {
            if (Left is null)
            {
                return false;
            }

            return Left.Contains(value);
        }

        // Search the right subtree when the target is larger.
        if (Right is null)
        {
            return false;
        }

        return Right.Contains(value);
    }

    public int GetHeight()
    {
        int leftHeight = 0;
        int rightHeight = 0;

        // Recursively determine the height of the left subtree.
        if (Left is not null)
        {
            leftHeight = Left.GetHeight();
        }

        // Recursively determine the height of the right subtree.
        if (Right is not null)
        {
            rightHeight = Right.GetHeight();
        }

        // Height of this node is one plus the tallest subtree.
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
