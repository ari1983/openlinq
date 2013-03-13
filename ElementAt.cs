using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Returns the element at a specified index in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="System.Collections.Generic.IEnumerable{T}"/> to return an element from.</param>
        /// <param name="index">The zero-based index of the element to retrieve.</param>
        /// <returns>The element at the specified position in the source sequence.</returns>
        /// <exception cref="System.ArgumentNullException">source or predicate is null.</exception>
        /// <exception cref="System.IndexOutOfRangeException">index is less than 0 or greater than or equal to the number of elements in source.</exception>
        public static T ElementAt<T>(this IEnumerable<T> source, int index)
        {
            if (source == null) throw new ArgumentNullException("source");

            if (index < 0) throw new IndexOutOfRangeException("index is less than 0.");

            int counter = 0;

            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    if (counter == index) break; // element found !

                    if (counter > index)
                        throw new IndexOutOfRangeException("index is greater than or equal to the number of elements in source.");

                    counter++;
                }

                return iterator.Current;
            }
        }
    }
}
