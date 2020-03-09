using System;
using System.Linq;

namespace ArraySorter
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] str = {"e", "b", "a", "y", "f", "g", "u"};

            ArraySorter<String> test = new ArraySorter<string>(str, str.Length);
    
            //String[] arr = ArraySorter<String>.Sort(str);

            test.enqueue("bob");
            
            /*foreach (string s in arr)
            {
                Console.Write(s + " ");
            }*/

            Console.WriteLine();
        }

        //a b e f g u y
    }

    /*        private static bool Less(String s1, String s2)
        {
            char[] ca1 = s1.ToCharArray();
            char[] ca2 = s2.ToCharArray();
            int cycles = ca1.Length > ca2.Length ? ca2.Length : ca1.Length;
            for (int i = 0; i < cycles; i++)
            {
                if (ca1[i] != ca2[i])
                {
                    return ca1[i] - 97 < ca2[i] - 97;
                }
            }

            return s2.Length > s1.Length;
        }*/
}