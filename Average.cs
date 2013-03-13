using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerabeExt
    {
        /// <summary>
        /// Computes the average of a sequence of <see cref="System.Int32"/> values.
        /// </summary>
        /// <param name="source"> A sequence of <see cref="System.Int32"/> values to calculate the average of.</param>
        /// <returns>The average of the sequence of values.</returns>
        /// <exception cref="System.OverflowException">The number of elements in source is larger than <see cref="System.Int32.MaxValue"/>.</exception>
        public static double Average(this IEnumerable<int> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            checked
            {
                IEnumerator<Int32> iterator = source.GetEnumerator();

                int sum = 0;
                int count = 0;

                while (iterator.MoveNext())
                {
                    sum += iterator.Current;
                    count++;
                }

                iterator.Dispose();

                return sum / count;
            }
        }
    }
}
