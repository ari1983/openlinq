using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The sequence to return elements from.</param>
        /// <param name="count">The number of elements to return.</param>
        /// <returns>Returns a specified number of contiguous elements from the start of a sequence.</returns>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException: source or predicate is null.</exception>
        public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int count)
        {
            if (source == null) throw new ArgumentNullException("source");

            return TakeImpl(source, count);
        }

        // Take implementation
        private static IEnumerable<T> TakeImpl<T>(this IEnumerable<T> source, int count)
        {
            int counter = 0;

            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    counter++;

                    if (counter <= count)
                    {
                        yield return iterator.Current;
                    }
                }
            }
        }
    }
}
