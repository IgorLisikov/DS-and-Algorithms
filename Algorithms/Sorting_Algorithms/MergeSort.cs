namespace SortingAlgorithms
{
    public static class MergeSort
    {
        public static void Sort(int[] arr)
        {
            // Best          Worst
            // O(n*log n)    O(n*log n)
            // Uses extra space for creating new arrays

            // Divide array into two halves - left and right
            // Sort each half
            // Merge back left and right
            // Since left and right are sorted, the merging is simple


            // arr = { 7, 6, 2, 8, 5, 9, 4, 3, 1 };
            if (arr.Length < 2)
                return;

            int middle = arr.Length / 2;
            var left = new int[middle];
            for (int i = 0; i < middle; i++)
            {
                left[i] = arr[i];
            }

            var right = new int[arr.Length - middle];
            for (int i = middle; i < arr.Length; i++)
            {
                right[i-middle] = arr[i];
            }

            Sort(left);
            Sort(right);

            Merge(left, right, arr);
        }

        private static void Merge(int[] left, int[] right, int[] arr)
        {
            int i = 0, j = 0, k = 0;
            while(i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    arr[k++] = left[i++];
                else
                    arr[k++] = right[j++];
            }

            while (i < left.Length)
                arr[k++] = left[i++];


            while (j < right.Length)
                arr[k++] = right[j++];
        }
    }
}
