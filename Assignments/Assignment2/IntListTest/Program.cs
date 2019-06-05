using System;
using System.Collections.Generic;
using System.Linq;

namespace DNP2.Assignment2.IntListTest
{
    // Delegate types to describe predicates on ints and actions on ints.
    public delegate bool IntPredicate(int x);

    public delegate void IntAction(int x);

    // Integer lists with Act and Filter operations.
    // An IntList containing the element 7 9 13 may be constructed as
    // new IntList(7, 9, 13) due to the params modifier.
    internal class IntList : List<int>
    {
        public IntList(params int[] elements) : base(elements)
        {
        }

        public void Act(IntAction f)
        {
            foreach (int i in this)
            {
                f(i);
            }
        }

        public IntList Filter(IntPredicate p)
        {
            var res = new IntList();
            foreach (int i in this)
            {
                if (p(i))
                {
                    res.Add(i);
                }
            }
            return res;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            // Print all numbers 
            Console.WriteLine("Printing all numbers");
            var xs = new IntList(Enumerable.Range(1, 50).ToArray());
            xs.Act(Console.WriteLine);

            // Print all even numbers
            Console.WriteLine("\nPrinting all even numbers:");
            xs.Filter(delegate(int x) { return x % 2 == 0; }).Act(Console.WriteLine);
            // xs.Filter(x => x % 2 == 0).Act(Console.WriteLine);
            // xs.Filter(IsEven).Act(Console.WriteLine);

            // Print all numbers above 25
            Console.WriteLine("\nPrinting all numbers above 25");
            xs.Filter(delegate(int x) { return x > 25; }).Act(Console.WriteLine);
            // xs.Filter(x => x > 25).Act(Console.WriteLine);

            /* There are 3 IntList instances in total:
             * 1. xs
             * 2. Output IntList for xs.Filter(delegate(int x) { return x % 2 == 0; }).Act(Console.WriteLine);
             * 3. Output IntList for xs.Filter(delegate(int x) { return x > 25; }).Act(Console.WriteLine);
             */

            // Sum and print all numbers in the list
            int sum = 0;
            xs.Act(delegate(int x) { sum += x; });
            Console.WriteLine($"\nThe sum of all the numbers is {sum}");
        }

        /*
        private static bool IsEven(int x)
        {
            return x % 2 == 0;
        }
        */
    }
}