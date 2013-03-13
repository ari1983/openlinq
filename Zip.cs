using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Merges two sequences by using the specified predicate function.
        /// </summary>
        /// <typeparam name="TFirst">The type of the elements of the first input sequence.</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the second input sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements of the result sequence.</typeparam>
        /// <param name="first">The first sequence to merge.</param>
        /// <param name="second">The second sequence to merge.</param>
        /// <param name="selector">A function that specifies how to merge the elements from the two sequences.</param>
        /// <returns>An <see cref="System.Collections.Generic.IEnumerable{T}"/> that contains merged elements of two input sequences.</returns>
        /// <exception cref="System.ArgumentNullException">first or second or selector is null.</exception>
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (selector == null) throw new ArgumentNullException("selector");

            return ZipImpl<TFirst, TSecond, TResult>(first, second, selector);
        }

        // Zip implementation
        private static IEnumerable<TResult> ZipImpl<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
        {
            IEnumerator<TFirst> firstIterator = first.GetEnumerator();
            IEnumerator<TSecond> secondIterator = second.GetEnumerator();

            while (firstIterator.MoveNext() && secondIterator.MoveNext())
            {
                yield return selector(firstIterator.Current, secondIterator.Current);
            }

            firstIterator.Dispose();
            secondIterator.Dispose();
        }
    }
}
