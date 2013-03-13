using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Returns the number of elements in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence that contains elements to be counted.</param>
        /// <returns>The number of elements in the input sequence.</returns>
        /// <exception cref="System.ArgumentNullException">source or predicate is null.</exception>
        /// <exception cref="System.OverflowException">The number of elements in source is larger than System.Int32.MaxValue.</exception>
        public static int Count<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            checked
            {
                int count = 0;

                using (IEnumerator<T> iterator = source.GetEnumerator())
                {
                    while (iterator.MoveNext())
                    {
                        count += 1;
                    }

                    iterator.Dispose();

                    return count;
                }
            }
        }

        /// <summary>
        /// A number that represents how many elements in the sequence satisfy the condition in the predicate function.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence that contains elements to be tested and counted.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>The number of elements in the input sequence.</returns>
        /// <exception cref="System.ArgumentNullException">source or predicate is null.</exception>
        /// <exception cref="System.OverflowException">The number of elements in source is larger than System.Int32.MaxValue.</exception>
        public static int Count<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");

            checked
            {
                int sum = 0;

                using (IEnumerator<T> iterator = source.GetEnumerator())
                {
                    while (iterator.MoveNext())
                    {
                        if (predicate(iterator.Current))
                        {
                            sum += 1;
                        }
                    }

                    return sum;
                }
            }
        }
    }
}
