using System.Collections;

namespace LinkedListQueue;

public class Queue<T> : LinkedList<T>
{
    private LinkedList<T> _list;
    public LinkedListNode<T> First { get; private set; }

    public Queue()
    {
        _list = new LinkedList<T>();
    }

    public Queue(IEnumerable<T> collection)
    {
        _list = new LinkedList<T>(collection);
    }

    public void Enqueue(T thing)
    {
        _list.AddLast(thing);
    }

    public T Dequeue()
    {
        if (_list.First == null) throw new InvalidOperationException();
        var firstNodeValue = _list.First.Value;
        _list.RemoveFirst();
        return firstNodeValue;
    }

    public T Peek()
    {
        if (_list.First == null) throw new InvalidOperationException();
        return _list.First.Value;
    }

    public int Size()
    {
        return _list.Count;
    }
}