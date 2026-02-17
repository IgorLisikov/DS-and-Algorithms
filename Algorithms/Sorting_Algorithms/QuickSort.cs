namespace SortingAlgorithms
{
    public static class QuickSort
    {
        public static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }
        private static void Sort(int[] arr, int start, int end)
        {
            // Best          Worst
            // O(n*log n)    O(n^2)
            // Unlike MergeSort - QuickSort doesn't use extra space

            // Partition: pick pivot and move all smaller values to the left and greater values to the right
            // Partition method returns index of pivot
            // Sort left
            // Sort right

            // arr = { 7, 6, 2, 8, 5, 9, 4, 3, 1 };
            if (start >= end)
                return;

            int pivotIndex = Partition(arr, start, end);
            Sort(arr, start, pivotIndex - 1);
            Sort(arr, pivotIndex + 1, end);

        }

        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int boundary = start - 1;  // boundary serves to separate smaller_then_pivot (left) VS bigger_then_pivot (right)
                                       // initially, boundary is outside of range

            for (int i = start; i <= end; i++)
            {
                if (arr[i] <= pivot)  // if arr[i] is smaller than pivot, need to extend boundary
                {
                    boundary++;  // now boundary is extended, but now it includes some random entry - need to swap it with arr[i]
                    Swap(arr, boundary, i);
                }  // the last item to be pushed inside the boundary is pivot
            }

            return boundary;  // here, boundary is the index of the pivot
        }

        private static void Swap(int[] arr, int left, int right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}
