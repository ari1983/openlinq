using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Computes the sum of a sequence of System.Int32 values.
        /// </summary>
        /// <param name="source">A sequence of System.Int32 values to calculate the sum of.</param>
        /// <returns>The sum of the values in the sequence.</returns>
        /// <exception cref="System.ArgumentNullException">Source is null.</exception>
        /// <exception cref="System.OverflowException">The number of elements in source is larger than System.Int32.MaxValue.</exception>
        public static int Sum(this IEnumerable<int> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            checked
            {
                IEnumerator<Int32> iterator = source.GetEnumerator();

                int sum = 0;

                while (iterator.MoveNext())
                {
                    sum += iterator.Current;
                }

                iterator.Dispose();

                return sum;
            }
        }
    }
}
