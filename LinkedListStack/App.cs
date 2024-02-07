namespace LinkedListStack;

public class App
{
    public static void Main()
    {
        Stack<int> stack = [];
        stack.Push(3);
        stack.Push(2);
        stack.Push(1);
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
    }
}