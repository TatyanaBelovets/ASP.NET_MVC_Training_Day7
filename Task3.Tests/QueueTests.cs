using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Library;

namespace Task3.Tests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void Ctor_GivenArrayWithNumbers_ReturnsQueueWithSameElements()
        {
            var queue = new CustomQueue<int>(new [] {1, 2, 3, 4, 5, 6});
            var result = new CustomQueue<int>();
            result.Enqueue(1);
            result.Enqueue(2);
            result.Enqueue(3);
            result.Enqueue(4);
            result.Enqueue(5);
            result.Enqueue(6);
            Assert.AreEqual(result, queue);
        }

        [TestMethod]
        public void Ctor_GivenEmptyArray_ReturnsEmptyQueue()
        {
            var queue = new CustomQueue<int>(new int[] {});
            var result = new CustomQueue<int>();
            Assert.AreEqual(result, queue);
        }

        [TestMethod]
        public void DequeueAndEnqueue_FilledWithEnqueueDequeueOneElement_ReturnsExpectedQueue()
        {
            var queue = new CustomQueue<int>(new[] { 1, 2, 3, 4, 5 });
            var result = new CustomQueue<int>();
            result.Enqueue(2);
            result.Enqueue(3);
            result.Enqueue(4);
            result.Enqueue(5);
            queue.Dequeue();
            Assert.AreEqual(result, queue);
        }

        [TestMethod]
        public void Iterator_GivenQueue_ListsAllElements()
        {
            var queue = new CustomQueue<int>(new[] { 1, 2, 3, 4, 5, 6 }); 
            var queueElements = new List<int> {};
            foreach (var element in queue)
            {
                queueElements.Add(element);
            }
            Assert.AreEqual(queueElements.Count, queue.ElementsCount);
        }

        [TestMethod]
        public void ElementCount_GivenQueueWithFiveElements_ElementCountStoresFive()
        {
            var queue = new CustomQueue<int>(new[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(5, queue.ElementsCount);
        }

        [TestMethod]
        public void Dequeue_GivenArray_ReturnsFirstElementOfGivenQueue()
        {
            var queue = new CustomQueue<int>(new[] { 1, 2, 3, 4, 5 });
            var firstElement = queue.Dequeue();
            Assert.AreEqual(1, firstElement);
        }

        [TestMethod]
        public void Peek_GivenArray_ReturnsFirstElementOfGivenQueue()
        {
            var queue = new CustomQueue<int>(new[] { 1, 2, 3, 4, 5 });
            var firstElement = queue.Peek();
            Assert.AreEqual(1, firstElement);
        }

        [TestMethod]
        public void Enqueue_GivenSix_ReturnsSixWhenDequeuePreviousElements()
        {
            var queue = new CustomQueue<int>(new[] { 1, 2, 3, 4, 5 });
            queue.Enqueue(6);
            for (int i = 0; i < 5; i++)
            {
                queue.Dequeue();
            }
            var lastElement = queue.Peek();
            Assert.AreEqual(6, lastElement);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void Peek_GivenEmptyQueue_ThrownInvalidOperationException()
        {
            var queue = new CustomQueue<int>(new int[] {});
            queue.Peek();
        }
    }
}
