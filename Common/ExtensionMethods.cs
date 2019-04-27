using System;
using System.Collections.Generic;

namespace DNP2.Helpers.Common
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Prints all elements of the enumerable on a new line
        /// </summary>
        /// <param name="collection">the enumerable</param>
        public static void PrintAll<T>(this IEnumerable<T> collection)
        {
            Console.WriteLine(string.Join(Environment.NewLine, collection));
            Console.WriteLine();
        }
    }
}
