namespace LinkedListTests;

public class List
{
   private ListNode _firstNode;
   private ListNode _lastNode;
   private readonly string _name; // string like "list" to display

   // construct empty List with specified name
   public List(string listName)
   {
      _name = listName;
      _firstNode = _lastNode = null;
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
         _firstNode = _lastNode = new ListNode(insertItem);
      }
      else
      {
         _firstNode = new ListNode(insertItem, _firstNode);
      }
   }

   // Insert object at end of List. If List is empty, 
   // firstNode and lastNode will refer to same object.
   // Otherwise, lastNode's Next property refers to new node.
   public void InsertAtBack(object insertItem)
   {
      if (IsEmpty())
      {
         _firstNode = _lastNode = new ListNode(insertItem);
      }
      else
      {
         _lastNode = _lastNode.Next = new ListNode(insertItem);
      }
   }

   // remove first node from List
   public object RemoveFromFront()
   {
      if (IsEmpty())
      {
         throw new EmptyListException(_name);
      }

      object removeItem = _firstNode.Data; // retrieve data

      // reset firstNode and lastNode references
      if (_firstNode == _lastNode)
      {
         _firstNode = _lastNode = null;
      }
      else
      {
         _firstNode = _firstNode.Next;
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

      object removeItem = _lastNode.Data; // retrieve data

      // reset firstNode and lastNode references
      if (_firstNode == _lastNode)
      {
         _firstNode = _lastNode = null;
      }
      else
      {
         ListNode? current = _firstNode;

         // loop while current.Next is not lastNode
         while (current.Next != _lastNode)
         {
            current = current.Next; // move to next node
         }

         // current is new lastNode
         _lastNode = current;
         current.Next = null;
      }

      return removeItem; // return removed data
   }

   // return true if List is empty
   public bool IsEmpty()
   {
      return _firstNode == null;
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

         ListNode? current = _firstNode;

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

      if (_firstNode == _lastNode)
      {
         return;
      }
      ListNode? current = _firstNode;
      while (current.Next != _lastNode)
      {
         current = current.Next;
      }

      current.Next = null;
      _lastNode.Next = _firstNode;
      _firstNode = _lastNode;
      _lastNode = current;
   }
}