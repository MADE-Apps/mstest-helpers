namespace MADE.Testing.MSTest.UnitTests
{
    using System.Collections.Generic;

    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class CollectionAsserterTests
    {
        [TestMethod]
        public void AreEnumerablesEqual_ExpectedAndActualAreNull_ShouldNotThrowAssertFailedException()
        {
            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(
                        default(IEnumerable<NoEqualityTestObject>),
                        default(IEnumerable<NoEqualityTestObject>));
                });
        }

        [TestMethod]
        public void AreEnumerablesEqual_ExpectedIsNullAndActualIsSet_ShouldThrowAssertFailedException()
        {
            var actual = new List<NoEqualityTestObject>();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(default(IEnumerable<NoEqualityTestObject>), actual);
                });
        }

        [TestMethod]
        public void AreEnumerablesEqual_ExpectedIsSetAndActualIsNull_ShouldThrowAssertFailedException()
        {
            var expected = new List<NoEqualityTestObject>();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, default(IEnumerable<NoEqualityTestObject>));
                });
        }

        [TestMethod]
        public void AreEnumerablesEqual_ExpectedAndActualHaveVariedItemCount_ShouldThrowAssertFailedException()
        {
            var expected = new List<NoEqualityTestObject> { new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true } };
            var actual = new List<NoEqualityTestObject> { new NoEqualityTestObject() };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, actual);
                });
        }

        [TestMethod]
        public void AreEnumerablesEqual_ExpectedAndActualAreSameReference_ShouldNotThrowAssertFailedException()
        {
            var expected = new List<NoEqualityTestObject> { new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true } };
            List<NoEqualityTestObject> actual = expected;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, actual);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEqual_ExpectedAndActualHaveSameReferenceObjectsInSameOrder_ShouldNotThrowAssertFailedException()
        {
            var o = new NoEqualityTestObject();
            var p = new NoEqualityTestObject { BooleanPropertyTest = true };

            var expected = new List<NoEqualityTestObject> { o, p };
            var actual = new List<NoEqualityTestObject> { o, p };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, actual);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEqual_ExpectedAndActualHaveSameObjectsInSameOrder_ShouldThrowAssertFailedExceptionIfNoEqualsOverride()
        {
            var expected = new List<NoEqualityTestObject> { new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true } };
            var actual = new List<NoEqualityTestObject> { new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true } };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, actual);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEqual_ExpectedAndActualHaveSameObjectsInSameOrder_ShouldNotThrowAssertFailedExceptionIfEqualsOverride()
        {
            var expected = new List<EqualityTestObject> { new EqualityTestObject(), new EqualityTestObject { BooleanPropertyTest = true } };
            var actual = new List<EqualityTestObject> { new EqualityTestObject(), new EqualityTestObject { BooleanPropertyTest = true } };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<EqualityTestObject>(expected, actual);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEqual_ExpectedAndActualHaveSameReferenceObjectsInDifferentOrder_ShouldThrowAssertFailedException()
        {
            var o = new NoEqualityTestObject();
            var p = new NoEqualityTestObject { BooleanPropertyTest = true };

            var expected = new List<NoEqualityTestObject> { o, p };
            var actual = new List<NoEqualityTestObject> { p, o };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEqual<NoEqualityTestObject>(expected, actual);
                });
        }
    }
}