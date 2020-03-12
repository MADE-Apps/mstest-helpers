namespace MADE.Testing.MSTest.UnitTests
{
    using System.Collections.Generic;

    using MADE.Testing.MSTest.Collections;
    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class CollectionAsserterTests
    {
        [TestMethod]
        public void AreEnumerablesEqualComparer_ComparerIsNull_ShouldThrowAssertFailedException()
        {
            var expected = new List<NoEqualityTestObject>();
            var actual = new List<NoEqualityTestObject>();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, actual, null);
                });
        }

        [TestMethod]
        public void AreEnumerablesEqualComparer_ExpectedAndActualAreNull_ShouldNotThrowAssertFailedException()
        {
            var comparer =
                new GenericComparer<NoEqualityTestObject, NoEqualityTestObject>(
                    (expected, actual) => expected.Equals(actual));

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(
                        default(IEnumerable<NoEqualityTestObject>),
                        default(IEnumerable<NoEqualityTestObject>),
                        comparer);
                });
        }

        [TestMethod]
        public void AreEnumerablesEqualComparer_ExpectedIsNullAndActualIsSet_ShouldThrowAssertFailedException()
        {
            var comparer =
                new GenericComparer<NoEqualityTestObject, NoEqualityTestObject>(
                    (expected, actual) => expected.Equals(actual));

            var actual = new List<NoEqualityTestObject>();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(
                        default(IEnumerable<NoEqualityTestObject>),
                        actual,
                        comparer);
                });
        }

        [TestMethod]
        public void AreEnumerablesEqualComparer_ExpectedIsSetAndActualIsNull_ShouldThrowAssertFailedException()
        {
            var comparer =
                new GenericComparer<NoEqualityTestObject, NoEqualityTestObject>(
                    (expected, actual) => expected.Equals(actual));

            var expected = new List<NoEqualityTestObject>();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(
                        expected,
                        default(IEnumerable<NoEqualityTestObject>),
                        comparer);
                });
        }

        [TestMethod]
        public void AreEnumerablesEqualComparer_ExpectedAndActualHaveVariedItemCount_ShouldThrowAssertFailedException()
        {
            var comparer =
                new GenericComparer<NoEqualityTestObject, NoEqualityTestObject>(
                    (expected, actual) => expected.Equals(actual));

            var expected = new List<NoEqualityTestObject>
                           {
                               new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true }
                           };
            var actual = new List<NoEqualityTestObject> { new NoEqualityTestObject() };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, actual, comparer);
                });
        }

        [TestMethod]
        public void AreEnumerablesEqualComparer_ExpectedAndActualAreSameReference_ShouldNotThrowAssertFailedException()
        {
            var comparer =
                new GenericComparer<NoEqualityTestObject, NoEqualityTestObject>(
                    (expected, actual) => expected.Equals(actual));

            var expected = new List<NoEqualityTestObject>
                           {
                               new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true }
                           };
            List<NoEqualityTestObject> actual = expected;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, actual, comparer);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEqualComparer_ExpectedAndActualHaveSameReferenceObjectsInSameOrder_ShouldNotThrowAssertFailedException()
        {
            var comparer =
                new GenericComparer<NoEqualityTestObject, NoEqualityTestObject>(
                    (expected, actual) => expected.Equals(actual));

            var o = new NoEqualityTestObject();
            var p = new NoEqualityTestObject { BooleanPropertyTest = true };

            var expected = new List<NoEqualityTestObject> { o, p };
            var actual = new List<NoEqualityTestObject> { o, p };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, actual, comparer);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEqualComparer_ExpectedAndActualHaveSameObjectsInSameOrder_ShouldThrowAssertFailedExceptionIfNoEqualsOverride()
        {
            var comparer =
                new GenericComparer<NoEqualityTestObject, NoEqualityTestObject>(
                    (expected, actual) => expected.Equals(actual));

            var expected = new List<NoEqualityTestObject>
                           {
                               new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true }
                           };
            var actual = new List<NoEqualityTestObject>
                         {
                             new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true }
                         };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, actual, comparer);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEqualComparer_ExpectedAndActualHaveSameObjectsInSameOrder_ShouldNotThrowAssertFailedExceptionIfEqualsOverride()
        {
            var comparer =
                new GenericComparer<EqualityTestObject, EqualityTestObject>(
                    (expected, actual) => expected.Equals(actual));

            var expected = new List<EqualityTestObject>
                           {
                               new EqualityTestObject(), new EqualityTestObject { BooleanPropertyTest = true }
                           };
            var actual = new List<EqualityTestObject>
                         {
                             new EqualityTestObject(), new EqualityTestObject { BooleanPropertyTest = true }
                         };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<EqualityTestObject>(expected, actual, comparer);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEqualComparer_ExpectedAndActualHaveSameReferenceObjectsInDifferentOrder_ShouldThrowAssertFailedException()
        {
            var comparer =
                new GenericComparer<NoEqualityTestObject, NoEqualityTestObject>(
                    (expected, actual) => expected.Equals(actual));

            var o = new NoEqualityTestObject();
            var p = new NoEqualityTestObject { BooleanPropertyTest = true };

            var expected = new List<NoEqualityTestObject> { o, p };
            var actual = new List<NoEqualityTestObject> { p, o };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, actual, comparer);
                });
        }
    }
}