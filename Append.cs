using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Concatenates a sequence with an element and put it at the end.
        /// </summary>
        /// <typeparam name="T">Type of a sequence and element to append</typeparam>
        /// <param name="source">A sequence</param>
        /// <param name="element">The value to be appended</param>
        /// <returns>n <see cref="System.Collections.Generic.IEnumerable{T}"/> that contains the concatenated sequence and element.</returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T element)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (element == null) throw new ArgumentNullException("element");

            return AppendImpl(source, element);
        }

        // Append implementation
        private static IEnumerable<T> AppendImpl<T>(IEnumerable<T> source, T element)
        {
            IEnumerator<T> iterator = source.GetEnumerator();

            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }

            yield return element;

            iterator.Dispose();
        }
    }
}
