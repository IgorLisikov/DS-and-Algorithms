namespace SearchingAlgorithms
{
    public static class ExponentialSearch
    {
        public static int Search(int[] arr, int target)
        {
            // Best    Worst
            // O(1)    O(log i)
            // where "i" is the index of target (maximum value of "i" is "n")
            // if target does not exist in array, the "i" equals to index where target would be if it existed (still smaller than "n").

            // The bound grows exponentially
            // Compare target with last item inside the bound ("bound-1" is last item inside the bound)
            // If target is smaller, then it should be inside this bound - use binary search to find it:
            //          [....previousBound........currentBound................]
            //                          ↑          ↑
            //                           search here

            int bound = 1;
            // Extend boundary EXPONENTIALLY until target is smaller than last item inside the boundary:
            while (bound < arr.Length && arr[bound - 1] < target)
            {
                bound *= 2;
            }
            int left = bound / 2; // the bound from previous step
            int right = Math.Min(bound, arr.Length - 1);
            return BinarySearch.SearchRecursive(arr, left, right, target);
        }
    }
}
