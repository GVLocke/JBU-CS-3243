namespace Homework72;

public class BinaryHeap(int size)
{
        //We are adding size+1, because array index 0 will be blank.  
        private readonly int[] _arr = new int[size + 1]; // or, could use a List for auto resizing...
        private int _sizeOfTree;

        public int PeekOfHeap()
        {
            return _sizeOfTree == 0 ? 0 : _arr[1];
        }

        public int SizeOfHeap()
        {

            Console.WriteLine("The size of the heap is:" + _sizeOfTree);
            return _sizeOfTree;
        }

        public void InsertElementInHeap(int value)
        {
            if (_sizeOfTree < 0)
            {
                Console.WriteLine("Tree is empty");
            }
            else
            {
                //Insertion of value inside the array happens at the last index of the  array
                _arr[_sizeOfTree + 1] = value;
                _sizeOfTree++;
                HeapifyBottomToTop(_sizeOfTree);
                // Console.WriteLine("Inserted " + value + " successfully in Heap !");
                // LevelOrder();
            }//end of method  
        }

        private void HeapifyBottomToTop(int index)
        {
            var parent = index / 2;
            // We are at root of the tree. Hence no more Heapifying is required.  
            if (index <= 1)
            {
                return;
            }
            // If Current value is smaller than its parent, then we need to swap  
            if (_arr[index] < _arr[parent])
            {
                (_arr[index], _arr[parent]) = (_arr[parent], _arr[index]);
            }
            HeapifyBottomToTop(parent);
        }

        public void LevelOrder()
        {
            Console.WriteLine("Printing all the elements of this Heap...");// Printing from 1 because 0th cell is dummy  
            for (var i = 1; i <= _sizeOfTree; i++)
            {
                Console.WriteLine(_arr[i] + " ");
            }
            Console.WriteLine("\n");
        }


        public int ExtractHeadOfHeap()
        {
            if (_sizeOfTree == 0)
            {
                Console.WriteLine("Heap is empty !");
                return -1;
            }
            else
            {
                // Console.WriteLine("Head of the Heap is: " + arr[1]);
                // Console.WriteLine("Extracting it now...");
                var extractedValue = _arr[1];
                _arr[1] = _arr[_sizeOfTree]; //Replacing with last element of the array  
                _sizeOfTree--;
                HeapifyTopToBottom(1);
                // Console.WriteLine("Successfully extracted value from Heap.");
                // LevelOrder();
                return extractedValue;
            }
        }

        private void HeapifyTopToBottom(int index)
        {
            var left = index * 2;
            var right = (index * 2) + 1;
            int smallestChild;

            if (_sizeOfTree < left)
            { //If there is no child of this node, then nothing to do. Just return.  
                return;
            }
            else if (_sizeOfTree == left)
            { //If there is only left child of this node, then do a comparison and return.  
                if (_arr[index] > _arr[left])
                {
                    (_arr[index], _arr[left]) = (_arr[left], _arr[index]);
                }
                return;
            }
            else
            {
                //If both children are there  
                //Find out the smallest child  
                smallestChild = _arr[left] < _arr[right] ? left : right;
                if (_arr[index] > _arr[smallestChild])
                { //If Parent is greater than smallest child, then swap  
                    (_arr[index], _arr[smallestChild]) = (_arr[smallestChild], _arr[index]);
                }
            }
            HeapifyTopToBottom(smallestChild);
        }

    }