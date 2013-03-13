using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Determines whether all elements of a sequence satisfy a condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"> An <see cref="System.Collections.Generic.IEnumerable{T}"/> that contains the elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if every element of the source sequence passes the test in the specified predicate, or if the sequence is empty; otherwise, false.</returns>
        /// <exception cref="System.ArgumentNullException">source or predicate is null.</exception>
        public static bool All<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");

            if (predicate == null) throw new ArgumentNullException("predicate");

            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    if (!predicate(iterator.Current))
                        return false;
                }

                return true;
            }
        }
    }
}
