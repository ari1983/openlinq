using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        #region Filtration
        /// <summary>
        /// Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="System.Collections.Generic.IEnumerable{T}"/> to filter.</param>
        /// <param name="predicate">A function to test each source element for a condition; the second parameter of the function represents the index of the source element.</param>
        /// <returns>An <see cref="System.Collections.Generic.IEnumerable{T}"/> that contains elements from the input sequence that satisfy the condition.</returns>
        /// <exception cref="System.ArgumentNullException">source or predicate is null.</exception>
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            return WhereImpl(source, predicate);
        }

        // Where implementation
        private static IEnumerable<T> WhereImpl<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    if (predicate(iterator.Current))
                    {
                        yield return iterator.Current;
                    }
                }
            }
        }

        #endregion
    }
}
