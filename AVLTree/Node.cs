namespace AVLTree;

public class Node<T>(T data)
{
    public T Data { get; set; } = data;
    public Node<T>? Left { get; set; } = null;
    public Node<T>? Right { get; set; } = null;
    public int Height { get; set; } = 1;
}