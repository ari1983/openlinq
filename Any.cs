using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Determines whether a sequence contains any elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="System.Collections.Generic.IEnumerable{T}"/> to check for emptiness.</param>
        /// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
        /// <exception cref="System.ArgumentNullException">source or predicate is null.</exception>
        public static bool Any<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                return iterator.MoveNext();
            }
        }

        /// <summary>
        /// Determines whether any element of a sequence satisfies a condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="System.Collections.Generic.IEnumerable{T}"/> whose elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if any elements in the source sequence pass the test in the specified predicate; otherwise, false.</returns>
        /// <exception cref="System.ArgumentNullException">source or predicate is null.</exception>
        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    if (predicate(iterator.Current))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
