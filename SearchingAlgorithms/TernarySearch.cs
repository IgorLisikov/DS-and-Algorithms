namespace SearchingAlgorithms
{
    public static class TernarySearch
    {
        public static int Search(int[] arr, int target)
        {
            // Best    Worst
            // O(1)    O(log3 n)
            // TernarySearch is slower than BinarySearch, because it takes more comparisons

            return Search(arr, 0, arr.Length - 1, target);
        }

        private static int Search(int[] arr, int left, int right, int target)
        {
            // arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            if (left > right)
                return -1;

            int partitionSize = (right - left) / 3;
            int mid1 = left + partitionSize;
            int mid2 = right - partitionSize;

            if (arr[mid1] == target)
                return mid1;

            if (arr[mid2] == target)
                return mid2;
            
            if (target < arr[mid1])
                return Search(arr, left, mid1 - 1, target);

            if (target > arr[mid2])
                return Search(arr, mid2 + 1, right , target);

            return Search(arr, mid1 + 1, mid2 - 1, target);
        }
    }
}
