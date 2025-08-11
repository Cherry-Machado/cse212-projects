public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        // If the value is greater, insert to the right.
        // If the value is equal, do nothing (no duplicates).
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Base case: If the current node's data matches the value, we've found it.
        if (value == Data)
            return true;

        // If the value is smaller, search the left subtree.
        if (value < Data)
            return Left is not null && Left.Contains(value);
        // If the value is larger, search the right subtree.
        return Right is not null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // The height of the tree rooted at this node is 1 (for this node)
        // plus the height of the taller of the two subtrees.
        return 1 + Math.Max(Left?.GetHeight() ?? 0, Right?.GetHeight() ?? 0);
    }
}