using Heaps;


var heap = new Heap();
heap.Insert(15);
heap.Insert(10);
heap.Insert(3);
heap.Insert(8);
heap.Insert(12);
heap.Insert(9);
heap.Insert(4);
heap.Insert(1);
heap.Insert(24);
int removed = heap.Remove();
Console.WriteLine(removed);

var arr = new int[] { 5, 3, 8, 4, 1, 2 };
HeapStatic.Heapify(arr);
Console.WriteLine();

int res = HeapStatic.GetKthLargest(arr, 2);
Console.WriteLine();




public static class HeapStatic
{
    // Transform array into a heap in-place:
    public static void Heapify(int[] nums)
    {
        // pick each node and bubble it down (swap with largest child):
        int lastParent = (nums.Length / 2) - 1;  // don't need to iterate on leafs
        for (int i = lastParent; i >= 0; i--)    // iterate from bottom to top to reduce number of recursive calls
        {
            Heapify(nums, i);
        }
    }

    private static void Heapify(int[] arr, int index)
    {
        // index is the root node; suppose it is larger than both of it's children:
        int largerIndex = index;

        int leftIndex = index * 2 + 1;
        if (leftIndex < arr.Length && arr[leftIndex] > arr[largerIndex])
            largerIndex = leftIndex;

        int rightIndex = index * 2 + 2;
        if (rightIndex < arr.Length && arr[rightIndex] > arr[largerIndex])
            largerIndex = rightIndex;

        if (largerIndex == index)  // if index was the largest, do nothing
            return;

        // else, need to swap index with the largest child:
        int temp = arr[index];
        arr[index] = arr[largerIndex];
        arr[largerIndex] = temp;

        // after the swap, need to recursively go down the heap to further bubble down largerIndex
        Heapify(arr, largerIndex);
    }

    public static int GetKthLargest(int[] arr, int k)
    {
        // construct a heap and count remove iterations - removing an item from the heap always returns the currently largest value in the heap
        var heap = new Heap();
        foreach(int x in arr)
        {
            heap.Insert(x);
        }

        while (k > 1)
        {
            heap.Remove();
            k--;
        }

        return heap.Remove();
    }
}

