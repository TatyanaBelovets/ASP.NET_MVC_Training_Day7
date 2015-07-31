using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable FunctionNeverReturns

namespace Task2.Library
{
    public class FibonacciNumbers
    {
        public IEnumerable<int> GetFibonacciNumber()
        {
            int prev = 0;
            int curr = 1;
            while (true)
            {
                yield return curr;
                curr += prev;
                prev -= curr;
            }
        }

        public IEnumerable<int> GetNFibonacciNumbers(int n)
        {
            if (n > 0)
            {
                return GetFibonacciNumber().Take(n);
            }
            throw new ArgumentException("Argument can't be negative", "n");
        }
    }
}
