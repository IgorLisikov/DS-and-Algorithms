namespace SortingAlgorithms
{
    public static class BucketSort
    {
        public static void Sort(int[] arr, int numberOfBuckets)
        {
            // Time complexity depends on number of buckets (k):
            // if k == arr.Length, each bucket will contain a single item -> no need to sort them inside a bucket. The time complexity will be same as for CountingSort (with the cost of extra space)
            // if k < arr.Length, the buckets will contain more than on item, so the time complexity will depend on chosen sorting algorithm to sort buckets

            // Best          Worst
            // O(n + k)      O(n^2)


            // arr = { 7, 6, 2, 8, 5, 9, 4, 3, 1 };
            var buckets = new List<List<int>>();
            for (int i = 0; i < numberOfBuckets; i++)
            {
                buckets.Add(new List<int>());
            }

            foreach (var num in arr)
            {
                int bucketNumber = num / numberOfBuckets;  // a way of selecting a bucket for an item should be more reasonable
                buckets[bucketNumber].Add(num);
            }

            int index = 0;
            foreach (var bucket in buckets)
            {
                bucket.Sort();  // here, sorting can be any algorithm
                foreach (var num in bucket)
                {
                    arr[index++] = num;
                }
            }
        }
    }
}
