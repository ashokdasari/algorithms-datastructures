using System;
using System.Collections.Generic;

namespace sorting_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the elements to be sorted seperated by space");
            string arraytobeSorted = Console.ReadLine();
            var origArr = Array.ConvertAll((arraytobeSorted.Split(" ", StringSplitOptions.RemoveEmptyEntries)), s => int.Parse(s));

            Console.WriteLine("Bubble Sorted");
            var bubbleSorted = (int[])origArr.Clone();
            SortingAlgorithms.BubbleSort(bubbleSorted);
            PrintArray(bubbleSorted);

            Console.WriteLine("\nInsertion Sorted");
            var insertionSorted = (int[])origArr.Clone();
            SortingAlgorithms.InsertionSort(insertionSorted);
            PrintArray(insertionSorted);

            Console.WriteLine("\nSelection Sorted");
            var selectionSorted = (int[])origArr.Clone();
            SortingAlgorithms.SelectionSort(selectionSorted);
            PrintArray(selectionSorted);

            Console.WriteLine("\nMergeSort Sorted");
            var mergeSorted = (int[])origArr.Clone();
            SortingAlgorithms.MergeSort(mergeSorted, 0, origArr.Length - 1);
            PrintArray(mergeSorted);

            Console.Read();
        }
        private static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
