using System.Collections;

namespace LinkedListTests;

public class ListEnum : IEnumerator
{
    public List List;
    private ListNode? _position;

    public ListEnum(List list)
    {
        this.List = list;
        ListNode preNode = new ListNode(-1, list.FirstNode);
        _position = preNode;
    }

    public bool MoveNext()
    {
        _position = _position?.Next;
        return _position != null;
    }

    public void Reset()
    {
        _position = List.FirstNode;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public object Current
    {
        get
        {
            try
            {
                return _position.Data;
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}