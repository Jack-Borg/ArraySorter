using System;
using System.Linq;

namespace ArraySorter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ia = {5, 4, 8, 6, 4, 7, 3, 1};
            ArraySorter<int> arr = new ArraySorter<int>(ia, 10);


            Console.WriteLine("Enqueue of item");
            arr.Enqueue(2);
            foreach (int i in arr.items)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Dequeued first item");
            Console.WriteLine(arr.Dequeue() + "\n");

            Console.WriteLine("Sorted Descending");
            foreach (int i in arr.SortDescending())
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Sorted with custom lambda");
            foreach (int i in arr.Sort((x, y) => x > y))
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");
        }
    }
}