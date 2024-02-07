using System.Collections;

namespace LinkedListTests;

public static class LinkedListSum
{
    public static void ListSum()
    {
        List list1 = new List();
        List list2 = new List();
        for (int i = 20; i >= 0; i--)
        {
            list1.InsertAtFront(10 * i);
            list2.InsertAtFront(5 * i);
        }
        List sumList = new List();
        IEnumerator enumerator1 = list1.GetEnumerator();
        IEnumerator enumerator2 = list2.GetEnumerator();
        while (enumerator1.MoveNext() && enumerator2.MoveNext())
        {
            int value1 = (int)enumerator1.Current;
            int value2 = (int)enumerator2.Current;
            sumList.InsertAtBack(value1 + value2);
        }
        sumList.Display();
    }
}