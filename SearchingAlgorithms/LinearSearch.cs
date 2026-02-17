namespace SearchingAlgorithms
{
    public static class LinearSearch
    {
        public static int Search(int[] arr, int target)
        {
            // Best    Worst
            // O(1)    O(n)

            // arr = { 7, 6, 2, 8, 5, 9, 4, 3, 1 };
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                    return i;
            }
            return -1;
        }
    }
}
