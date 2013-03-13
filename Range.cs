using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Generates a sequence of integral numbers within a specified range.
        /// </summary>
        /// <param name="start">The value of the first integer in the sequence.</param>
        /// <param name="count">The number of sequential integers to generate.</param>
        /// <returns>The number of sequential integers to generate.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">count is less than 0.-or-start + count -1 is larger than System.Int32.MaxValue.</exception>
        public static IEnumerable<int> Range(int start, int count)
        {
            checked
            {
                if (count < 0 || (start + count - 1) < Int32.MaxValue)
                {
                    for (int i = 0; i < count; i++)
                    {
                        yield return start + i;
                    }
                }
            }
        }
    }
}
