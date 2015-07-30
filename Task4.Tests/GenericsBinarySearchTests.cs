using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4.Library;

namespace Task4.Tests
{
    [TestClass]
    public class GenericsBinarySearchTests
    {
        [TestMethod]
        public void BinarySearch_GivenIntArrayAndSecondElement_ReturnsOne()
        {
            var array = new[] {0, 1, 3, 5, 12, 24};
            var expectedValue = 1;
            var result = GenericsBinarySearch.BinarySearch(array, 1, Comparer<Int32>.Default);
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void BinarySearch_GivenIntArrayAndFirstElement_ReturnsZero()
        {
            var array = new[] {0, 1, 3, 5, 12, 24};
            var expectedValue = 0;
            var result = GenericsBinarySearch.BinarySearch(array, 0, Comparer<Int32>.Default);
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void BinarySearch_GivenIntArrayAndLastElement_ReturnsArrayLengthMinusOne()
        {
            var array = new[] {0, 1, 3, 5, 12, 24, 38};
            var expectedValue = array.Length - 1;
            var result = GenericsBinarySearch.BinarySearch(array, 38, Comparer<Int32>.Default);
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void BinarySearch_GivenIntArrayAndValueNotFromArray_ReturnsMinusOne()
        {
            var array = new[] {0, 1, 3, 5, 12, 24, 38};
            var expectedValue = -1;
            var result = GenericsBinarySearch.BinarySearch(array, 17, Comparer<Int32>.Default);
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void BinarySearch_GivenIntArrayOfTwoElementsAndFirstElement_ReturnsZero() 
        {
            var array = new[] {1, 2};
            var expectedValue = 0;
            var result = GenericsBinarySearch.BinarySearch(array, 1, Comparer<Int32>.Default);
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void BinarySearch_GivenIntArrayOfOneElementAndFirstElement_ReturnsZero() 
        {
            var array = new[] {1};
            var expectedValue = 0;
            var result = GenericsBinarySearch.BinarySearch(array, 1, Comparer<Int32>.Default);
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void BinarySearch_GivenIntArrayOfTwoElementsAndLastElement_ReturnsOne()
        {
            var array = new[] {1, 2};
            var expectedValue = 1;
            var result = GenericsBinarySearch.BinarySearch(array, 2, Comparer<Int32>.Default);
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void BinarySearch_GivenIntArrayOfTwoElementsAndValueNoFromArray_ReturnsMinusOne() 
        {
            var array = new[] {1, 2};
            var expectedValue = -1;
            var result = GenericsBinarySearch.BinarySearch(array, 10, Comparer<Int32>.Default);
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod, ExpectedException(typeof (ArgumentException))]
        public void BinarySearch_GivenEmptyArrayAndValue_ThrowsArgumentException()
        {
            var array = new int[] {};
            GenericsBinarySearch.BinarySearch(array, 38, Comparer<Int32>.Default);
        }

        [TestMethod]
        public void BinarySearch_GivenStringArrayAndFirstElement_ReturnsZero()
        {
            var array = new[] { "", "a", "aa", "ab", "abb", "ad", "d" };
            var expectedValue = 0;
            var result = GenericsBinarySearch.BinarySearch(array, "", Comparer<String>.Default);
            Assert.AreEqual(expectedValue, result);
        }

    }
}