namespace SearchingAlgorithms
{
    public static class BinarySearch
    {
        public static int Search(int[] arr, int target)
        {
            // Best    Worst
            // O(1)    O(log n)

            // arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == target)
                    return mid;
                if (target < arr[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }

        public static int SearchRecursive(int[] arr, int target)
        {
            return SearchRecursive(arr, 0, arr.Length - 1, target);
        }

        public static int SearchRecursive(int[] arr, int left, int right, int target)
        {
            // arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            if (left > right)
                return -1;

            int mid = (left + right) / 2;
            if (arr[mid] == target)
                return mid;

            if (target < arr[mid])
                return SearchRecursive(arr, left, mid - 1, target);
            else
                return SearchRecursive(arr, mid + 1, right, target);
        }
    }
}
