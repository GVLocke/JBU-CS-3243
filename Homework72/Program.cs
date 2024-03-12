using System.Diagnostics;

namespace Homework72
{
    internal static class App
    {
        private const int ArraySize = 10000000;
        public static void Main()
        {
            Console.WriteLine("Heap size,Time (ms)");
            var arr = GenerateRandomArray(ArraySize);
            for (var i = 1; i < ArraySize; i *= 2)
            {
               var stopwatch = new Stopwatch();
               var elapsedTime = TestHeap(i, arr.Length, arr, stopwatch, new BinaryHeap(i));
               Console.WriteLine($"{i},{elapsedTime}");
            }
        }

        private static double TestHeap(int heapSize, int arraySize, IReadOnlyList<int> arr, Stopwatch stopwatch, BinaryHeap heap)
        {
            stopwatch.Restart();
            for (var i = 0; i < heapSize; i++)
            {
                heap.InsertElementInHeap(arr[i]);
            }
            for (var i = heapSize; i < arraySize; i++)
            {
                if (arr[i] <= heap.PeekOfHeap()) continue;
                heap.ExtractHeadOfHeap();
                heap.InsertElementInHeap(arr[i]);
            }
            stopwatch.Stop();
            return 1.0e3 * stopwatch.ElapsedTicks / Stopwatch.Frequency;
        }

        private static int[] GenerateRandomArray(int arraySize)
        {
            var random = new Random();
            var arr = new int[arraySize];
            for (var i = 0; i < arraySize; i++)
            {
                var value = random.Next(0, 100);
                arr[i] = value;
            }

            return arr;
        }
    }
}