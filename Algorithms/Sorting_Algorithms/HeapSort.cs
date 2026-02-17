using Heaps;

namespace SortingAlgorithms
{
    public static class HeapSort
    {
        public static void Sort(int[] arr)
        {
            // Create heap from array:
            var heap = new Heap();
            foreach (var item in arr)
            {
                heap.Insert(item);
            }

            // Populate array - heap.Remove() always returns items in order:
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = heap.Remove();
            }

            // Or populate array from end - to achieve ascending order:
            //for (int i = arr.Length - 1; i >= 0; i--)
            //{
            //    arr[i] = heap.Remove();
            //}
        }
    }
}
