using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Determines whether a sequence contains a specified element by using the default equality comparer
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence in which to locate a value.</param>
        /// <param name="value">The value to locate in the sequence.</param>
        /// <returns>true if the source sequence contains an element that has the specified value; otherwise, false.</returns>
        public static bool Contains<T>(this IEnumerable<T> source, T value)
        {
            if (source == null) throw new ArgumentNullException("source");

            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    if (iterator.Current.Equals(value))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
