namespace SortingAlgorithms
{
    public static class CountingSort
    {
        public static void Sort(int[] arr)
        {
            // Best          Worst
            // O(n+k)        O(n+k)   k - is the max value
            // The tradeoff is extra memory

            // Create "frequencies" array with the capacity of max value of initial array
            // Populate "frequencies" array with frequencies of values; so the indexes are values of initial array
            // Iterate over frequencies array and fill initial array in a sorted order naturally

            // arr = { 7, 6, 2, 8, 5, 9, 4, 3, 1 };
            if (arr.Length == 0)
                return;

            var freq = new int[arr.Max() + 1];
            foreach (var num in arr)
            {
                freq[num]++;
            }

            int index = 0;
            for (int i = 0; i < freq.Length; i++)
            {
                for (int j = 0; j < freq[i]; j++)
                {
                    arr[index] = i;
                    index++;
                }
            }
        }
    }
}
