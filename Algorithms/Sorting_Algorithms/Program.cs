using SortingAlgorithms;



int[] arr =  { 7, 6, 2, 8, 5, 9, 4, 3, 1 };
int[] arr1 = { 7, 6 };
int[] arr2 = { 7 };
int[] arr3 = { };

//SelectionSort.Sort(arr);
//BubbleSort.Sort(arr);
//InsertionSort.Sort(arr);
//MergeSort.Sort(arr);
//QuickSort.Sort(arr);
//CountingSort.Sort(arr);
BucketSort.Sort(arr, 4);
//HeapSort.Sort(arr);
Console.WriteLine();
