using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Concatenates two sequences.
        /// </summary>
        /// <param name="first">The first sequence to concatenate.</param>
        /// <param name="second">The sequence to concatenate to the first sequence.</param>
        /// <returns>An <see cref="System.Collections.Generic.IEnumerable{T}"/> that contains the concatenated elements of the two input sequences.</returns>
        /// <exception cref="System.ArgumentNullException">first or second is null.</exception>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            return ConcatImpl(first, second);
        }

        // Concat implementation
        private static IEnumerable<T> ConcatImpl<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            IEnumerator<T> iterator = first.GetEnumerator();

            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }

            first = null;

            iterator = second.GetEnumerator();

            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }

            iterator.Dispose();
        }
    }
}
