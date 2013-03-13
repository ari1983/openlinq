using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Bypasses a specified number of elements in a sequence and then returns the remaining elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="System.Collections.Generic.IEnumerable{T}"/> to return elements from.</param>
        /// <param name="count">The number of elements to skip before returning the remaining elements.</param>
        /// <returns>An <see cref="System.Collections.Generic.IEnumerable{T}"/> that contains the elements that occur after the specified index in the input sequence.</returns>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException: source or predicate is null.</exception>
        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
        {
            if (source == null) throw new ArgumentNullException("source");

            return SkipImpl(source, count);
        }

        // Skip implementation
        private static IEnumerable<T> SkipImpl<T>(IEnumerable<T> source, int count)
        {
            int counter = 0;

            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    counter++;

                    if (counter > count)
                    {
                        yield return iterator.Current;
                    }
                }
            }
        }
    }
}
