namespace LinkedListQueue;

public static class Program
{
    public static void Main()
    {
        Queue<int> queue = [];
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
    }
}

