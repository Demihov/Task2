using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Part2
{
    public class CustomArray<T> : IEnumerable<T>
    {
        private T[] array;
        private int start = 0;
        private int end = 0;

        public int ArrayLength()
        {
            if (array != null)
            {
                return array.Length;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public CustomArray() { }
        public CustomArray(int a, int b)
        {
            if (a >= b)
            {
                throw new Exception("Start of range more then end");
            }
            else if (a < 0 && b >= 0)
            {
                array = new T[Math.Abs(a) + Math.Abs(b) + 1];
            }
            else
            {
                array = new T[Math.Abs(Math.Abs(a) - Math.Abs(b)) + 1];
            }

            start = a;
            end = b;
        }

        public CustomArray(int a, int b, params T[] arr) : this(a, b)
        {
            if (arr.Length > array.Length)
            {
                throw  new Exception("Input array's length is more than this array's length");
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    array[i] = arr[i];
                }
            }
        }
        public T this[int i]
        {
            get
            {
                if ((i < 0 && i < start) || i > end)
                {
                    throw new IndexOutOfRangeException();
                }
                return array[Math.Abs(start) + i];
            }
            set
            {
                if ((i < 0 && i < start) || i > end)
                {
                    throw new IndexOutOfRangeException();
                }
                array[Math.Abs(start) + i] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
