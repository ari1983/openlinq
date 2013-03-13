using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to reverse.</param>
        /// <returns>A sequence whose elements correspond to those of the input sequence in reverse order.</returns>
        /// <exception cref="System.ArgumentNullException">source is null.</exception>
        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            return ReverseImpl(source);
        }

        // Reverse implementation
        private static IEnumerable<T> ReverseImpl<T>(IEnumerable<T> source)
        {
            var stack = new Stack<T>(source);

            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }
    }
}
