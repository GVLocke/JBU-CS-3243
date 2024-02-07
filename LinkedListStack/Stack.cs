namespace LinkedListStack;

public class Stack<T> : LinkedList<T>
{
    private LinkedList<T> _list;

    public Stack()
    {
        _list = new LinkedList<T>();
    }
    public Stack(IEnumerable<T> collection)
    {
        _list = new LinkedList<T>(collection);
    }
    
    public void Push(T thing)
    {
        _list.AddFirst(thing);
    }

    public T Pop()
    {
        if (_list.First == null) throw new InvalidOperationException("The stack is empty!");
        var firstNodeValue = _list.First.Value;
        _list.RemoveFirst();
        return firstNodeValue;
    }

    public T Peek()
    {
        if (_list.First == null) throw new InvalidOperationException("The stack is empty!");
        return _list.First.Value;
        
    }

    public int Size()
    {
        return _list.Count;
    }
}