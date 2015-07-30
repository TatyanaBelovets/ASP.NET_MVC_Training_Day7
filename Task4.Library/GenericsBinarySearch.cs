using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Library
{
    public static class GenericsBinarySearch
    {
        public static int BinarySearch<T>(T[] array, T key, int left, int right, Comparison<T> compare  /*IComparer<T> comparer*/)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Empty array", "array");
            } // or return -1 better?
            if (compare(key, array[array.Length - 1]) > 0 || compare(key, array[0]) < 0)
            {
                return -1;
            }
            if (left == right)
            {
                if (compare(array[left], key) == 0)
                {
                    return left;
                }
                return -1;
            }
            int mid = left + (right - left)/2;
            if (compare(key, array[mid]) == 0)
            {
                return mid;
            }
            if (compare(key, array[mid]) > 0)
            {
                left = mid + 1;
                return BinarySearch(array, key, left, right, compare);
            }
            right = mid;
            return BinarySearch(array, key, left, right, compare);
        } 
    }
}
