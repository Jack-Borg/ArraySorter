using System;
using System.Linq;

namespace ArraySorter
{
    public class ArraySorter<T>
    {
        private T[] items;
        private int size;

        private Util<T> util = new Util<T>();

        public ArraySorter(T[] items, int size)
        {
            this.items = items;
            this.size = size;
        }

        public void enqueue(T item)
        {
            util.IncreaseArray(items, item, ++size);

            sortAscending();
        }

        public T Dequeue()
        {
            T res = items.First();
            items = items.Skip(1).ToArray();
            
            size--;
            
            sortAscending();
            
            return res;
        }

        public void sortAscending()
        {
        }

        public void sortDescending()
        {
        }

        public void sort(IComparable<T> comparator)
        {
        }
        

        private T[] Sort(T[] items)
        {
            ToHeap(items);

            for (int i = size - 1; i >= 0; i--)
            {
                items = util.Switch(items, 0, i);
                //Heapify(0, i);
            }

            return items;
        }

        private void ToHeap(T[] items)
        {
            for (int i = size / 2 - 1; i >= 0; i--) ;
            //Heapify(i, size);
        }

        private void Heapify(int i, int limiter)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < limiter && items[largest].CompareTo(items[left]))
                largest = left;
            if (right < limiter && items[largest].CompareTo(items[right]))
                largest = right;
            if (largest != i)
            {
                _arr = Switch(_arr, i, largest);
                Heapify(largest, limiter);
            }
        }
    }
}