using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable 693


namespace Task3.Library
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private const int StartLength = 10;
        private T[] _queue;
        private int _start;
        private int _end;
        public int ElementsCount{ get { return _end - _start; } }

        public CustomQueue()
        {
            _queue = new T[StartLength];
            _start = 0;
            _end = 0;
        }

        public CustomQueue(T[] array) : this()
        {
            if (array.Length > 0)
            {
                _queue = array;
                _end = array.Length;
            }
        }

        public CustomQueue(IEnumerable<T> collection) : this(collection.ToArray())
        {
        }

        public void Enqueue(T elem) // добавить элемент в очередь
        {
            if (_end >= _queue.Length)
            {
                if (_start != 0)
                {
                    MoveToZero();
                }
                else
                {
                    var temp = _queue;
                    _queue = new T[ElementsCount*2];
                    Array.Copy(temp, _start, _queue, 0, ElementsCount);
                }
            }
            _queue[_end] = elem;
            _end += 1;
            
        }
        
        public T Dequeue()// удалить элемент из очереди
        {
            if (ElementsCount > 0)
            {     
                if (_start > _queue.Length/4)
                {
                    MoveToZero();
                }
                ++_start;
                var elem = _queue[_start - 1];
                _queue[_start - 1] = default(T);
                return elem;
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

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomIterator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CustomIterator<T>(this);
        } 

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this == obj) return true;
            var p = obj as CustomQueue<T>;
            if (p == null)
            {
                return false;
            }
            if (ElementsCount != p.ElementsCount) return false;
            for (int i = _start, j = p._start; i < _end; i++, j++)
            {
                if (!Equals(_queue[i], p._queue[j]))
                {
                    return false;
                }

            }
            return true;
        }

        public override int GetHashCode() //simple implementation for Equals
        {
            return _queue.GetHashCode();
        }

        private void MoveToZero()
        {
            Array.Copy(_queue, _start, _queue, 0, ElementsCount);
            for (int i = _end - _start; i < _end; i++)
            {
                _queue[i] = default(T);
            }
            _end = _end - _start;
            _start = 0;
        }

        private class CustomIterator<T> : IEnumerator<T>
        {
            private readonly CustomQueue<T> _currentQueue; 
            private int _currentIndex;

            public CustomIterator(CustomQueue<T> queue)
            {
                _currentQueue = queue;
                _currentIndex = queue._start - 1;
            } 
            public void Dispose(){}

            public bool MoveNext()
            {
                _currentIndex++;
                return _currentIndex < _currentQueue._end;
            }

            public void Reset()
            {
                _currentIndex = _currentQueue._start - 1;
            }

            public T Current
            {
                get
                {
                    if (_currentIndex == -1 || _currentIndex == _currentQueue._end)
                    {
                        throw new InvalidOperationException();
                    }
                    return _currentQueue._queue[_currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}
