using System;
using System.Collections.Generic;

namespace OpenLinq
{
    public static partial class EnumerableExt
    {
        /// <summary>
        /// Generates a sequence that contains one repeated value.
        /// </summary>
        /// <typeparam name="TResult">The type of the value to be repeated in the result sequence.</typeparam>
        /// <param name="element">The value to be repeated.</param>
        /// <param name="count">The number of times to repeat the value in the generated sequence.</param>
        /// <returns>An <see cref="System.Collections.Generic.IEnumerable{T}"/> that contains a repeated value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">count is less than 0.</exception>
        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            return RepeatImpl(element, count);
        }

        // Repeat implementation
        private static IEnumerable<TResult> RepeatImpl<TResult>(TResult element, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return element;
            }
        }
    }
}
