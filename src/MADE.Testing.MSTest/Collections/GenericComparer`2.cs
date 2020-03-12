namespace MADE.Testing.MSTest.Collections
{
    using System;
    using System.Collections;

    /// <summary>
    /// Defines an comparer for comparing generic objects using a comparison function.
    /// </summary>
    /// <typeparam name="T1">The type of object to compare.</typeparam>
    /// <typeparam name="T2">The type of object to compare to.</typeparam>
    public class GenericComparer<T1, T2> : IComparer
        where T1 : class where T2 : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericComparer{T1, T2}"/> class.
        /// </summary>
        /// <param name="fun">The comparison expression.</param>
        public GenericComparer(Func<T1, T2, bool> fun)
        {
            this.Fun = fun;
        }

        /// <summary>
        /// Gets the function called to compare.
        /// </summary>
        private Func<T1, T2, bool> Fun { get; }

        /// <summary>Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.</summary>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero <paramref name="x" /> is less than <paramref name="y" />. Zero <paramref name="x" /> equals <paramref name="y" />. Greater than zero <paramref name="x" /> is greater than <paramref name="y" />. </returns>
        /// <param name="x">The first object to compare. </param>
        /// <param name="y">The second object to compare. </param>
        /// <filterpriority>2</filterpriority>
        public int Compare(object x, object y)
        {
            if (!(x is T1 original) || !(y is T2 compare))
            {
                return -1;
            }

            bool val = this.Fun(original, compare);
            return val ? 0 : -1;
        }
    }
}