namespace SortingAlgorithms
{
    public static class SelectionSort
    {
        public static void Sort(int[] arr)
        {
            // Best     Worst
            // O(n^2)   O(n^2)

            // On each iteration pick "left" and SELECT the min value from remaining part of array
            // Swap min value with "left"
            // On each iteration the min value takes it's final position at the left end

            // arr = { 7, 6, 2, 8, 5, 9, 4, 3, 1 };
            for (int left = 0; left < arr.Length - 1; left++)
            {
                int minIndex = left;
                for (int right = left + 1; right < arr.Length; right++)
                {
                    if (arr[right] < arr[minIndex])
                        minIndex = right;
                }
                Swap(arr, left, minIndex);
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
