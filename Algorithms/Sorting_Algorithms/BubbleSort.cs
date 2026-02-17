namespace SortingAlgorithms
{
    public static class BubbleSort
    {
        public static void Sort(int[] arr)
        {
            // Best    Worst
            // O(n)    O(n^2)

            // Compare pairs from left to right; if left is greater - swap it with the right one
            // On each step the biggest value takes it's final position at the right end (BUBBLES UP)

            // arr = { 7, 6, 2, 8, 5, 9, 4, 3, 1 };
            for (int step = 1; step < arr.Length; step++)
            {
                bool wholeStepWithoutSwaps = true;
                for (int left = 0; left < arr.Length - step; left++)
                {
                    if (arr[left] > arr[left + 1])
                    {
                        Swap(arr, left, left + 1);
                        wholeStepWithoutSwaps = false;
                    }
                }
                if (wholeStepWithoutSwaps)
                    break;
            }
        }

        private static void Swap(int[] arr, int left, int right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}
