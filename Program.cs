var tree = new Node('A', 
    new('B',
        new('D',
            new('H')
        ),
        new('E')
    ),
    new('C',
        new('F',
            new('I')
        ),
        new('G',
            new('J'),
            new('K')
        )
    )
);

Console.WriteLine("Breadth First / Levels:\n");
TreeTraversal.BreadthFirst(tree, letter => Console.Write($"{letter}"));

Console.WriteLine("Preorder:");
TreeTraversal.Preorder(tree, letter => Console.Write($"{letter}"));

Console.WriteLine("\nInorder");
TreeTraversal.Inorder(tree, letter => Console.Write($"{letter}"));

Console.WriteLine("\nPostorder");
TreeTraversal.Postorder(tree, letter => Console.Write($"{letter}"));
Console.WriteLine("\n---");

class Node 
{
    public Node? Left { get; set; }
    public Node? Right { get; set; }
    public char Value { get; set; }

    public Node(char value, Node? left = null, Node? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}

static class TreeTraversal
{
    public static void BreadthFirst(Node? root, Action<char> action)
    {
        var queue = new Queue<Node?>();
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            var node = queue.Dequeue();
            if(node is null) continue;

            action(node.Value);

            queue.Enqueue(node.Left);
            queue.Enqueue(node.Right);
        }
    }

    public static void Preorder(Node? node, Action<char> action)
    {
        if(node is null) return;

        action(node.Value);

        Preorder(node.Left, action);
        Preorder(node.Right, action);
    }

    public static void Inorder(Node? node, Action<char> action)
    {
        if(node is null) return;

        Inorder(node.Left, action);
        action(node.Value);
        Inorder(node.Right, action);
    }

    public static void Postorder(Node? node, Action<char> action)
    {
        if(node is null) return;

        Postorder(node.Left, action);
        Postorder(node.Right, action);
        action(node.Value);
    }
}