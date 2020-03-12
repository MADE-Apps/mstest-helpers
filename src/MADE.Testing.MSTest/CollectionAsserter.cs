namespace MADE.Testing.MSTest
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines a code assertion helper for collection based scenarios.
    /// </summary>
    public class CollectionAsserter
    {
        /// <summary>
        /// Tests whether the specified enumerables are equal and throws an exception if the two enumerables are not equal. Equality is defined as having the same elements, compared using Equals, in the same order and same quantity. 
        /// </summary>
        /// <typeparam name="T">
        /// The type associated with items in the enumerable.
        /// </typeparam>
        /// <param name="expected">
        /// The first collection to compare. This is the collection the tests expects.
        /// </param>
        /// <param name="actual">
        /// The second collection to compare. This is the collection produced by the code under test.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="expected"/> is not equal to <paramref name="actual"/>.
        /// </exception>
        public static void AreEnumerablesEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            string reason = string.Empty;

            if (CollectionAsserter.CompareEnumerables(expected, actual, new ObjectComparer(), ref reason))
            {
                return;
            }

            Assert.Fail($"{nameof(CollectionAsserter.AreEnumerablesEqual)} failed. {reason}");
        }

        /// <summary>
        /// Tests whether the specified enumerables are equal and throws an exception if the two enumerables are not equal. Equality is defined as having the same elements, compared using the given <see cref="IComparer"/>, in the same order and same quantity. 
        /// </summary>
        /// <typeparam name="T">
        /// The type associated with items in the enumerable.
        /// </typeparam>
        /// <param name="expected">
        /// The first collection to compare. This is the collection the tests expects.
        /// </param>
        /// <param name="actual">
        /// The second collection to compare. This is the collection produced by the code under test.
        /// </param>
        /// <param name="comparer">
        /// The compare implementation to use when comparing elements of the collection.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="expected"/> is not equal to <paramref name="actual"/>.
        /// </exception>
        public static void AreEnumerablesEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual, IComparer comparer)
        {
            string reason = string.Empty;

            if (CollectionAsserter.CompareEnumerables(expected, actual, comparer, ref reason))
            {
                return;
            }

            Assert.Fail($"{nameof(CollectionAsserter.AreEnumerablesEqual)} failed. {reason}");
        }

        /// <summary>
        /// Tests whether two collections contain the same elements and throws an exception if either collection contains an element not in the other collection.
        /// </summary>
        /// <param name="expected">
        /// The first collection to compare. This contains the elements the test expects.
        /// </param>
        /// <param name="actual">
        /// The second collection to compare. This is the collection produced by the code under test.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if an element was found in one of the collections but not the other.
        /// </exception>
        public static void AreEnumerablesEquivalent<TItem>(IEnumerable<TItem> expected, IEnumerable<TItem> actual)
        {
            if ((expected == null) != (actual == null))
            {
                Assert.Fail(
                    $"{nameof(CollectionAsserter.AreEnumerablesEquivalent)} failed. Cannot compare enumerables for equivalency as {nameof(expected)} or {nameof(actual)} provided is null.");
            }

            if (CollectionAsserter.Equals(expected, actual))
            {
                return;
            }

            var expectedList = expected.ToList();
            var actualList = actual.ToList();
            if (expectedList.Count != actualList.Count)
            {
                Assert.Fail(
                    $"{nameof(CollectionAsserter.AreEnumerablesEquivalent)} failed. The number of elements are different.");
            }

            if (expectedList.Count == 0 || !FindMismatchedElement(
                    expectedList,
                    actualList,
                    out _,
                    out _,
                    out object mismatchedElement))
            {
                return;
            }

            Assert.Fail(
                $"{nameof(CollectionAsserter.AreEnumerablesEquivalent)} failed. The collections contain mismatched elements. {mismatchedElement ?? "Element was null."}");
        }

        private static bool CompareEnumerables<TType>(
            IEnumerable<TType> expected,
            IEnumerable<TType> actual,
            IComparer comparer,
            ref string reason)
        {
            if (comparer == null)
            {
                Assert.Fail($"Cannot compare enumerables as the {nameof(comparer)} provided is null.");
            }

            if (CollectionAsserter.Equals(expected, actual))
            {
                reason = "Both enumerables are the same reference.";
                return true;
            }

            if (expected == null || actual == null)
            {
                return false;
            }

            var expectedList = expected.ToList();
            var actualList = actual.ToList();
            if (expectedList.Count != actualList.Count)
            {
                reason = "The number of elements are different.";
                return false;
            }

            IEnumerator enumerator1 = expectedList.GetEnumerator();
            IEnumerator enumerator2 = actualList.GetEnumerator();
            int num = 0;
            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                if (comparer.Compare(enumerator1.Current, enumerator2.Current) != 0)
                {
                    return false;
                }

                ++num;
            }

            reason = "Both enumerables contain the same elements.";
            return true;
        }

        /// <summary>
        /// Finds a mismatched element between the two collections. A mismatched
        /// element is one that appears a different number of times in the
        /// expected collection than it does in the actual collection. The
        /// collections are assumed to be different non-null references with the
        /// same number of elements. The caller is responsible for this level of
        /// verification. If there is no mismatched element, the function returns
        /// false and the out parameters should not be used.
        /// </summary>
        /// <param name="expected">The first collection to compare.</param>
        /// <param name="actual">The second collection to compare.</param>
        /// <param name="expectedCount">
        /// The expected number of occurrences of
        /// <paramref name="mismatchedElement" /> or 0 if there is no mismatched
        /// element.
        /// </param>
        /// <param name="actualCount">
        /// The actual number of occurrences of
        /// <paramref name="mismatchedElement" /> or 0 if there is no mismatched
        /// element.
        /// </param>
        /// <param name="mismatchedElement">
        /// The mismatched element (may be null) or null if there is no
        /// mismatched element.
        /// </param>
        /// <returns>
        /// True if a mismatched element was found; false otherwise.
        /// </returns>
        private static bool FindMismatchedElement(
            ICollection expected,
            ICollection actual,
            out int expectedCount,
            out int actualCount,
            out object mismatchedElement)
        {
            Dictionary<object, int> elementCounts1 = GetElementCounts(expected, out int nullCount1);
            Dictionary<object, int> elementCounts2 = GetElementCounts(actual, out int nullCount2);

            if (nullCount2 != nullCount1)
            {
                expectedCount = nullCount1;
                actualCount = nullCount2;
                mismatchedElement = null;
                return true;
            }

            foreach (object key in elementCounts1.Keys)
            {
                elementCounts1.TryGetValue(key, out expectedCount);
                elementCounts2.TryGetValue(key, out actualCount);
                if (expectedCount == actualCount)
                {
                    continue;
                }

                mismatchedElement = key;
                return true;
            }

            expectedCount = 0;
            actualCount = 0;
            mismatchedElement = null;
            return false;
        }

        /// <summary>
        /// Constructs a dictionary containing the number of occurrences of each
        /// element in the specified collection.
        /// </summary>
        /// <param name="collection">The collection to process.</param>
        /// <param name="nullCount">
        /// The number of null elements in the collection.
        /// </param>
        /// <returns>
        /// A dictionary containing the number of occurrences of each element
        /// in the specified collection.
        /// </returns>
        private static Dictionary<object, int> GetElementCounts(IEnumerable collection, out int nullCount)
        {
            var dictionary = new Dictionary<object, int>();
            nullCount = 0;
            foreach (object key in collection)
            {
                if (key == null)
                {
                    ++nullCount;
                }
                else
                {
                    dictionary.TryGetValue(key, out int num);
                    ++num;
                    dictionary[key] = num;
                }
            }

            return dictionary;
        }

        /// <summary>
        /// Defines a simple object comparer.
        /// </summary>
        private class ObjectComparer : IComparer
        {
            /// <summary>Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.</summary>
            /// <returns>A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero <paramref name="x" /> is less than <paramref name="y" />. Zero <paramref name="x" /> equals <paramref name="y" />. Greater than zero <paramref name="x" /> is greater than <paramref name="y" />. </returns>
            /// <param name="x">The first object to compare. </param>
            /// <param name="y">The second object to compare. </param>
            /// <filterpriority>2</filterpriority>
            public int Compare(object x, object y)
            {
                bool val = object.Equals(x, y);
                return val ? 0 : -1;
            }
        }
    }
}