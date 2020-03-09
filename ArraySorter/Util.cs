using System;

namespace ArraySorter
{
    public class Util<T>
    {
        public Util()
        {
        }

        public T[] Switch(T[] a, int i, int j)
        {
            T tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
            return a;
        }

        public T[] IncreaseArray(T[] items, T item, int size)
        {
            T[] tmp = items;
            items = new T[size];
            for (int i = 0; i < tmp.Length; i++)
            {
                items[i] = tmp[i];
            }

            items[items.Length - 1] = item;

            return items;
        }
    }
}