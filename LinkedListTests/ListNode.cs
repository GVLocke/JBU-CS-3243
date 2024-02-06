// Fig. 19.4: LinkedListLibrary.cs
// ListNode, List and EmptyListException class declarations.
using System;

namespace LinkedListTests;

// class to represent one node in a list
public class ListNode
{
   // automatic read-only property Data
   public object Data { get; private set; }

   // automatic property Next
   public ListNode? Next { get; set; }

   // constructor to create ListNode that refers to dataValue
   // and is last node in list
   public ListNode(object dataValue) : this(dataValue, null) { }

   // constructor to create ListNode that refers to dataValue
   // and refers to next ListNode in List
   public ListNode(object dataValue, ListNode? nextNode)
   {
      Data = dataValue;
      Next = nextNode;
   }
}


/**************************************************************************
 * (C) Copyright 1992-2017 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
