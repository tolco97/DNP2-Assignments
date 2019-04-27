using System;
using System.Collections.Generic;

namespace DNP2.Assignment4.CustomerQueries
{
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Prints all elements of the enumerable on a new line
        /// </summary>
        /// <param name="allItems">the enumerable</param>
        internal static void PrintAllElements<T>(this IEnumerable<T> allItems)
        {
            Console.WriteLine(string.Join("\n", allItems));
            Console.WriteLine();
        }
    }
}
