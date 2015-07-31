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
        public static int BinarySearch<T>(T[] array, T key)
        {
            return BinarySearch(array, key, 0, array.Length, Comparer<T>.Default);
        }

        public static int BinarySearch<T>(T[] array, T key, int left, int right, IComparer<T> comparer)
        {
            if (comparer == null)
            {
                try
                {
                    comparer = Comparer<T>.Default;
                }
                catch
                {
                    throw new ArgumentException("Null comparer!", "comparer");
                }
            }
            return BinarySearch(array, key, 0, array.Length, comparer.Compare);
        }

        public static int BinarySearch<T>(T[] array, T key, Comparison<T> compare)
        {
            if (compare == null)
            {
                try
                {
                    compare = Comparer<T>.Default.Compare;
                }
                catch
                {
                    throw new ArgumentException("Null compare!", "compare");
                }
            }
            return BinarySearch(array, key, 0, array.Length, compare);
        }

        public static int BinarySearch<T>(T[] array, T key, int left, int right, Comparison<T> compare)
        {
            if (compare == null)
            {
                try
                {
                    compare = Comparer<T>.Default.Compare;
                }
                catch
                {
                    throw new ArgumentException("Null compare!", "compare");
                }
            }
            return _BinarySearch(array, key, left, right, compare);
        }

        private static int _BinarySearch<T>(T[] array, T key, int left, int right, Comparison<T> compare)
        {
            if (compare == null)
            {
                try
                {
                    compare = Comparer<T>.Default.Compare;
                }
                catch
                {
                    throw new ArgumentException("Null compare!", "compare");
                }
            }

            if (array.Length == 0 || array == null)
            {
                throw new ArgumentException("Empty array or null", "array");
            } 
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
