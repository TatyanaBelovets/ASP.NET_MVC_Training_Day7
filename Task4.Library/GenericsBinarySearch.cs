using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Library
{
    public static class GenericsBinarySearch
    {
        public static int BinarySearch<T>(T[] array, T key, IComparer<T> comparer)
        {
            return BinarySearch(array, key, 0, array.Length, comparer);
        }

        public static int BinarySearch<T>(T[] array, T key, int left, int right, IComparer<T> comparer)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Empty array", "array");
            } // or return -1 better?
            if (comparer.Compare(key, array[array.Length - 1]) > 0 || comparer.Compare(key, array[0]) < 0)
            {
                return -1;
            }
            if (left == right)
            {
                if (comparer.Compare(array[left], key) == 0)
                {
                    return left;
                }
                return -1;
            }
            int mid = left + (right - left)/2;
            if (comparer.Compare(key, array[mid]) == 0)
            {
                return mid;
            }
            if (comparer.Compare(key, array[mid]) > 0)
            {
                left = mid + 1;
                return BinarySearch(array, key, left, right, comparer);
            }
            right = mid;
            return BinarySearch(array, key, left, right, comparer);
        }
    }
}
