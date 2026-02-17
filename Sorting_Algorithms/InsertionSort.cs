namespace SortingAlgorithms
{
    public static class InsertionSort
    {
        public static void Sort(int[] arr)
        {
            // Best    Worst
            // O(n)    O(n^2)

            // Pick right as current. Need to save it in "current" variable, because initial value of arr[right] will be lost
            // Search to the left while current is smaller - find place where to INSERT current
            // Shift all entries to the right during searching (that's why arr[right] gets lost)

            // arr = { 7, 6, 2, 8, 5, 9, 4, 3, 1 };
            for (int right = 1; right < arr.Length; right++)
            {
                int current = arr[right];
                int left = right - 1;
                while (left >= 0 && current < arr[left])
                {
                    arr[left + 1] = arr[left];
                    left--;
                }
                arr[left + 1] = current;
            }
        }
    }
}
