using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Concatenates a sequence with an element and put it at the beginning.
        /// </summary>
        /// <typeparam name="T">Type of a sequence and element to prepend.</typeparam>
        /// <param name="source">A sequence.</param>
        /// <param name="element">The value to be prepended.</param>
        /// <returns>An <see cref="System.Collections.Generic.IEnumerable{T}"/> that contains the concatenated sequence and element.</returns>
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T element)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (element == null) throw new ArgumentNullException("element");

            return PrependImpl(source, element);
        }

        // Prepend implementation
        private static IEnumerable<T> PrependImpl<T>(IEnumerable<T> source, T element)
        {
            yield return element;

            IEnumerator<T> iterator = source.GetEnumerator();

            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }

            iterator.Dispose();
        }
    }
}
