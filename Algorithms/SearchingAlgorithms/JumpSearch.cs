namespace SearchingAlgorithms
{
    public static class JumpSearch
    {
        public static int Search(int[] arr, int target)
        {
            // Best    Worst
            // O(1)    O(√n)

            // Compare target with last item in each block ("next-1" is the last item of current block).
            // If target is smaller, then it should be somewhere inside the current block (if exists) - use linear search to find it.

            int blockSize = (int)Math.Sqrt(arr.Length);  // is optimal way to determine the size of a block
            int start = 0;
            int next = blockSize;

            // JUMP to next block until target is smaller than last item in block:
            while (start < arr.Length && arr[next-1] < target)
            {
                start = next;
                next += blockSize;
                if (next > arr.Length)  // trim next to avoid overflow the array range
                    next = arr.Length;
            }
            // Note: if target does not exist in the array, the algorithm will stop at block where target would be if it existed 

            // linear search inside the block where target should be:
            for (int i = start; i < next; i++)
            {
                if (arr[i] == target)
                    return i;
            }

            return -1;
        }
    }
}
