using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
