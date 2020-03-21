using System;
using System.Collections.Generic;
using System.Text;

namespace sorting_algorithms
{
    public class SortingAlgorithms
    {
        public static void BubbleSort(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < elements.Length - i - 1; j++)
                {
                    int temp;
                    if (elements[j] > elements[j + 1])
                    {
                        temp = elements[j];
                        elements[j] = elements[j + 1];
                        elements[j + 1] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(int[] elements)
        {
            for (int i = 1; i < elements.Length; i++)
            {
                int key = elements[i];
                int j = i - 1;

                while (j >= 0 && key < elements[j])
                {
                    elements[j + 1] = elements[j];
                    j--;
                }
                elements[j + 1] = key;
            }
        }

        public static void SelectionSort(int[] elements)
        {
            for (int i = 0; i < elements.Length - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[j] < elements[min_idx])
                    {
                        min_idx = j;
                    }
                }
                var temp = elements[i];
                elements[i] = elements[min_idx];
                elements[min_idx] = temp;
            }
        }

        public static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);
                Merge(arr, l, m, r);
            }
        }

        private static void Merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            var L = new int[n1];
            var R = new int[n2];
            for (int idx = 0; idx < n1; ++idx)
            {
                L[idx] = arr[l + idx];
            }

            for (int idx = 0; idx < n2; ++idx)
            {
                R[idx] = arr[m + idx + 1];
            }

            int i = 0, j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] < R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
    }
}
