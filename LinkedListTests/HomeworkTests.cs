namespace LinkedListTests;

// Using the starter code from the Deitel List (linked-list), implement a new Rotate() method of the List class
// which has semantics equal to InsertAtBack(RemoveFromFront()), yet without creating any new node. Write
// a simple main function that fills the list with a couple items and tests your new code, with the appropriate
// printouts to show that it is working correctly. (based on Goodrich 3.12)

public static class HomeworkTests
{
    public static void Main()
    {
        Console.WriteLine("Testing Rotate Method....");
        TestRotateMethod();
        Console.WriteLine("Testing Sum Method");
        LinkedListSum.ListSum();
    }

    private static void TestRotateMethod()
    {
        List list = new List();
        list.InsertAtFront(new Book("Mere Christianity", "CS Lewis"));
        list.InsertAtFront(new Book("Godel, Escher, Bach: An Eternal Golden Braid", "Douglas R. Hofstader"));
        list.InsertAtBack(new Book("The Holy Bible", "CSB"));
        list.InsertAtFront(new Book("Great Expectations", "Charles Dickens"));
        list.Display();
        list.Rotate();
        list.Display();
    }
}