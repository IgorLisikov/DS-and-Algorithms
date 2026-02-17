using SearchingAlgorithms;



int[] arr = { 7, 6, 2, 8, 5, 9, 4, 3, 1 };
int[] arr1 = { 7, 6 };
int[] arr2 = { 7 };
int[] arr3 = { };


Console.WriteLine(LinearSearch.Search(arr, 5));  // 4

int[] sorted = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
Console.WriteLine(BinarySearch.Search(sorted, 4));           // 3
Console.WriteLine(BinarySearch.SearchRecursive(sorted, 4));  // 3
Console.WriteLine(TernarySearch.Search(sorted, 4));          // 3
Console.WriteLine(JumpSearch.Search(sorted, 4));             // 3
Console.WriteLine(ExponentialSearch.Search(sorted, 4));      // 3

Console.WriteLine();
