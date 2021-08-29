using System;
using System.Collections.Generic;

namespace System.Linq
{
    public static class LinqExtension
    {
        public static void AddAll<T>(this IList<T> list, IEnumerable<T> elementsToAdd)
        {
            foreach (T t in elementsToAdd)
            {
                list.Add(t);
            }
        }

        public static void Swap<T>(this IList<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        public static int IndexOf<T>(
            this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            var index = 0;

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }
    }
}
