using System;
using System.Linq;

namespace ArraySorter
{
    public class ArraySorter<T> where T : IComparable<T>
    {
        public T[] items { get; }
        private int size;
        private int maxSize;
        private bool sortedAscending;

        public ArraySorter(T[] items, int size, bool sortAscending = true)
        {
            this.items = new T[size];
            this.size = items.Length;
            maxSize = size;
            
            for (var i = 0; i < items.Length; i++) 
                this.items[i] = items[i];

            if (sortAscending)
                SortAscending();
            else
                SortDescending();
        }

        public void Enqueue(T item)
        {
            if(size == maxSize)
                throw new Exception("Queue is already full");
            
            items[size++] = item;
            
            if(sortedAscending)
                SortAscending();
            else
                SortDescending();
        }

        public T Dequeue()
        {
            if(size == 0)
                throw new Exception("Queue is empty");
            
            T res = items[0];
            items[0] = items[--size];
            items[size] = default;
            
            if(sortedAscending)
                SortAscending();
            else
                SortDescending();

            return res;
        }

        public T[] SortAscending()
        {
            return Sort((x, y) => x.CompareTo(y) > 0);
        }

        public T[] SortDescending()
        {
            return Sort((x, y) => x.CompareTo(y) < 0);
        }


        public T[] Sort(Func<T,T, bool> lambda)
        {
            ToHeap(lambda);

            for (int i = size - 1; i >= 0; i--)
            {
                Switch(0, i);
                Heapify(0, i, lambda);
            }
            
            sortedAscending = items[0].CompareTo(items[size - 1]) < 0;

            return items;
        }

        private void ToHeap(Func<T,T, bool> lambda)
        {
            for (int i = size / 2 - 1; i >= 0; i--)
                Heapify(i, size, lambda);
        }

        private void Heapify(int i, int limiter, Func<T,T, bool> lambda)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            
            if (left < limiter && lambda(items[left], items[largest]))
                largest = left;
            
            if (right < limiter && lambda(items[right], items[largest]))
                largest = right;
            
            if (largest != i)
            {
                Switch(i, largest);
                Heapify(largest, limiter, lambda);
            }
        }

        private void Switch(int i, int j)
        {
            T tmp = items[i];
            items[i] = items[j];
            items[j] = tmp;
        }
    }
}