using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        #region Projection

        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
        /// <returns>An <see cref="System.Collections.Generic.IEnumerable{T}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="System.ArgumentNullException">source or selector is null.</exception>
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            return SelectImpl(source, selector);
        }

        // Select implementation
        private static IEnumerable<TResult> SelectImpl<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            using (IEnumerator<TSource> iterator = source.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    yield return selector(iterator.Current);
                }
            }
        }

        #endregion
    }
}
