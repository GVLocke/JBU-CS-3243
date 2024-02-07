using System.Collections;

namespace LinkedListTests;

public class List : IEnumerable
{
   public ListNode FirstNode { get; private set; }
   public ListNode LastNode { get; private set; }
   private readonly string _name; // string like "list" to display

   // construct empty List with specified name
   public List(string listName)
   {
      _name = listName;
      FirstNode = LastNode = null;
   }

   // construct empty List with "list" as its name 
   public List() : this("list") { }

   // Insert object at front of List. If List is empty, 
   // firstNode and lastNode will refer to same object.
   // Otherwise, firstNode refers to new node.
   public void InsertAtFront(object insertItem)
   {
      if (IsEmpty())
      {
         FirstNode = LastNode = new ListNode(insertItem);
      }
      else
      {
         FirstNode = new ListNode(insertItem, FirstNode);
      }
   }

   // Insert object at end of List. If List is empty, 
   // firstNode and lastNode will refer to same object.
   // Otherwise, lastNode's Next property refers to new node.
   public void InsertAtBack(object insertItem)
   {
      if (IsEmpty())
      {
         FirstNode = LastNode = new ListNode(insertItem);
      }
      else
      {
         LastNode = LastNode.Next = new ListNode(insertItem);
      }
   }

   // remove first node from List
   public object RemoveFromFront()
   {
      if (IsEmpty())
      {
         throw new EmptyListException(_name);
      }

      object removeItem = FirstNode.Data; // retrieve data

      // reset firstNode and lastNode references
      if (FirstNode == LastNode)
      {
         FirstNode = LastNode = null;
      }
      else
      {
         FirstNode = FirstNode.Next;
      }

      return removeItem; // return removed data
   }

   // remove last node from List
   public object RemoveFromBack()
   {
      if (IsEmpty())
      {
         throw new EmptyListException(_name);
      }

      object removeItem = LastNode.Data; // retrieve data

      // reset firstNode and lastNode references
      if (FirstNode == LastNode)
      {
         FirstNode = LastNode = null;
      }
      else
      {
         ListNode? current = FirstNode;

         // loop while current.Next is not lastNode
         while (current.Next != LastNode)
         {
            current = current.Next; // move to next node
         }

         // current is new lastNode
         LastNode = current;
         current.Next = null;
      }

      return removeItem; // return removed data
   }

   // return true if List is empty
   public bool IsEmpty()
   {
      return FirstNode == null;
   }

   // output List contents
   public void Display()
   {
      if (IsEmpty())
      {
         Console.WriteLine($"Empty {_name}");
      }
      else
      {
         Console.Write($"The {_name} is: \n");

         ListNode? current = FirstNode;

         // output current node data while not at end of list
         while (current != null)
         {
            Console.Write($"{current.Data}\n");
            current = current.Next;
         }

         Console.WriteLine("\n");
      }
   }

   public void Rotate()
   {
      if (IsEmpty())
      {
         throw new EmptyListException(_name);
      }

      if (FirstNode == LastNode)
      {
         return;
      }
      ListNode? current = FirstNode;
      while (current.Next != LastNode)
      {
         current = current.Next;
      }

      current.Next = null;
      LastNode.Next = FirstNode;
      FirstNode = LastNode;
      LastNode = current;
   }

   public int GetSize()
   {
      if (IsEmpty())
      {
         return 0;
      }
      int size = 0;
      ListNode? current = FirstNode;
      while (current != null)
      {
         size++;
         current = current.Next;
      }

      return size;
   }

   IEnumerator IEnumerable.GetEnumerator()
   {
      return (IEnumerator)GetEnumerator();
   }

   public ListEnum GetEnumerator()
   {
      return new ListEnum(this);
   }
}