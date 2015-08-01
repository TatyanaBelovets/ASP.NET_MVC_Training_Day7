using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Разработать (на основе одномерного массива) обобщенную класс-коллекцию CustomQueue, 
 * реализующую основные операции в виде методов Enqueue(), Dequeue(), Peek(), а также 
 * предоставляющую возможность итерирования по ней, реализовав ее итератор как внутренний класс. 
 * Протестировать методы разработанного класса.*/
namespace Task3.Library
{
    public class CustomQueue<T>
    {
        private T[] _queue;
        private int _start;
        private int _end;
        public int ElementsCount { get; private set; }

        CustomQueue()
        {
            _queue = new T[10];
            _start = 0;
            _end = 0;
            ElementsCount = 0;
        }
        CustomQueue(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Size of queue can't be negative number!", "length");
            }
            _queue = new T[length];
            _start = 0;
            _end = 0;
            ElementsCount = 0;
        }

        public void Enqueue(T elem) // добавить элемент в очередь
        {
            _queue[_end] = elem;
            _end += 1;
            ElementsCount += 1;
        }
        
        public T Dequeue()// удалить элемент из очереди
        {
            if (ElementsCount > 0)
            {
                _start += 1;
                ElementsCount -= 1;
                return _queue[_start - 1];
            }
            throw new InvalidOperationException("Empty queue!");
        }

        public T Peek()
        {
            if (ElementsCount > 0)
            {
                return _queue[_start];
            }
            throw new InvalidOperationException("Empty queue!");
        }

        public override string ToString()
        {
            return _queue.ToString();
        }
    }
}
