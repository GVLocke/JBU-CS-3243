namespace AVLTree;

public class AVLTree<T> where T : IComparable<T>
{
    private Node<T>? root;
    public AVLTree(Node<T> node)
    {
        root = node;
    }

    public AVLTree()
    {
        root = null;
    }

    private static int Height(Node<T>? node)
    {
        return node?.Height ?? 0;
    }

    public int Height()
    {
        return root?.Height ?? 0;
    }

    private int BalanceFactor(Node<T>? node = null)
    {
        node = node ?? root;
        return Height(node.Left) - Height(node.Right);
    }

    public Node<T>? GetMinNode(Node<T>? node = null)
    {
        node = node ?? root;
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node;
    }
    
    public Node<T>? GetMaxNode(Node<T>? node = null)
    {
        node = node ?? root;
        while (node.Right != null)
        {
            node = node.Right;
        }
        return node;
    }
    
    public bool Contains(T key)
    {
        var current = root;
        while (current != null)
        {
            switch (key.CompareTo(current.Data))
            {
                case 0:
                    return true;
                case < 0:
                    current = current.Left;
                    break;
                default:
                    current = current.Right;
                    break;
            }
        }
        return false;
    }

    public Node<T>? TryGetValue(T key)
    {
        var current = root;
        while (current != null)
        {
            switch (key.CompareTo(current.Data))
            {
                case 0:
                    return current;
                case < 0:
                    current = current.Left;
                    break;
                default:
                    current = current.Right;
                    break;
            }
        }
        return null;
    }

    public Node<T>? LeftRotate(Node<T>? node)
    {
        var b = node.Right;
        var y = b.Left;
        b.Left = node;
        node.Right = y;
        
        node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        b.Height = 1 + Math.Max(Height(b.Left), Height(b.Right));
        if (node == root)
        {
            root = b;
        }
        return node;
    }
    
    public Node<T>? RightRotate(Node<T>? node)
    {
        var b = node.Left;
        var y = b.Right;
        b.Right = node;
        node.Left = y;
        
        node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        b.Height = 1 + Math.Max(Height(b.Left), Height(b.Right));
        if (node == root)
        {
            root = b;
        }
        return node;
    }
    
    public void Insert(T key)
    {
        root = Insert(root, key);
    }

    
    private Node<T>? Insert(Node<T>? node, T key)
    {
        if (node == null)
        {
            return new Node<T>(key);
        }
        switch (key.CompareTo(node.Data))
        {
            case < 0:
                node.Left = Insert(node.Left, key);
                break;
            case > 0:
                node.Right = Insert(node.Right, key);
                break;
            default:
                return node;
        }
        
        node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        var balance = BalanceFactor(node);
        
        switch (balance)
        {
            case > 1 when node.Left != null && key.CompareTo(node.Left.Data) < 0:
                return RightRotate(node);
            case < -1 when node.Right != null && key.CompareTo(node.Right.Data) > 0:
                return LeftRotate(node);
            case > 1 when node.Left != null && key.CompareTo(node.Left.Data) > 0:
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            case < -1 when node.Right != null && key.CompareTo(node.Right.Data) < 0:
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            default:
                return node;
        }
    }
    
    public void Delete(T key)
    {
        root = Delete(root, key);
    }
    
    private Node<T>? Delete(Node<T>? node, T key)
    {
        if (node == null)
        {
            return node;
        }
        switch (key.CompareTo(node.Data))
        {
            case < 0:
                node.Left = Delete(node.Left, key);
                break;
            case > 0:
                node.Right = Delete(node.Right, key);
                break;
            default:
                if (node.Left == null || node.Right == null)
                {
                    var temp = node.Left ?? node.Right;
                    node = temp ?? null;
                }
                else
                {
                    var temp = GetMinNode(node.Right);
                    node.Data = temp.Data;
                    node.Right = Delete(node.Right, temp.Data);
                }
                break;
        }
        if (node == null)
        {
            return node;
        }
        
        node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        var balance = BalanceFactor(node);
        
        switch (balance)
        {
            case > 1 when BalanceFactor(node.Left) >= 0:
                return RightRotate(node);
            case < -1 when BalanceFactor(node.Right) <= 0:
                return LeftRotate(node);
            case > 1 when BalanceFactor(node.Left) < 0:
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            case < -1 when BalanceFactor(node.Right) > 0:
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            default:
                return node;
        }
    }

    
    public void PrintTree()
    {
        if (root != null)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            var levelOrder = "";
            var levelOrderWithDetails = "";

            while (queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();
                levelOrder += $"{node.Data} ";
                levelOrderWithDetails += $"{node.Data}: ".PadRight(5) + $"h = {Height(node)}, bf = {BalanceFactor(node)}\n";

                // add children to queue
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            Console.WriteLine("\nLevel-order traversal:");
            Console.WriteLine(levelOrder);
            Console.WriteLine("\nLevel-order traversal with height and balance factor:");
            Console.WriteLine(levelOrderWithDetails);
        }
        else
        {
            Console.WriteLine("\nAVL tree is empty!");
        }
    }
}