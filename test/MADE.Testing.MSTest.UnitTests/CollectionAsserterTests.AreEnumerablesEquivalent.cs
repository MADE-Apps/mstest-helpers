namespace MADE.Testing.MSTest.UnitTests
{
    using System.Collections.Generic;

    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class CollectionAsserterTests
    {
        [TestMethod]
        public void AreEnumerablesEquivalent_ExpectedAndActualAreNull_ShouldNotThrowAssertFailedException()
        {
            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEquivalent<NoEqualityTestObject>(
                        default(IEnumerable<NoEqualityTestObject>),
                        default(IEnumerable<NoEqualityTestObject>));
                });
        }

        [TestMethod]
        public void AreEnumerablesEquivalent_ExpectedIsNullAndActualIsSet_ShouldThrowAssertFailedException()
        {
            var actual = new List<NoEqualityTestObject>();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEquivalent<NoEqualityTestObject>(default(IEnumerable<NoEqualityTestObject>), actual);
                });
        }

        [TestMethod]
        public void AreEnumerablesEquivalent_ExpectedIsSetAndActualIsNull_ShouldThrowAssertFailedException()
        {
            var expected = new List<NoEqualityTestObject>();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEquivalent<NoEqualityTestObject>(expected, default(IEnumerable<NoEqualityTestObject>));
                });
        }

        [TestMethod]
        public void AreEnumerablesEquivalent_ExpectedAndActualHaveVariedItemCount_ShouldThrowAssertFailedException()
        {
            var expected = new List<NoEqualityTestObject> { new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true } };
            var actual = new List<NoEqualityTestObject> { new NoEqualityTestObject() };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEquivalent<NoEqualityTestObject>(expected, actual);
                });
        }

        [TestMethod]
        public void AreEnumerablesEquivalent_ExpectedAndActualAreSameReference_ShouldNotThrowAssertFailedException()
        {
            var expected = new List<NoEqualityTestObject> { new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true } };
            List<NoEqualityTestObject> actual = expected;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEquivalent<NoEqualityTestObject>(expected, actual);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEquivalent_ExpectedAndActualHaveSameReferenceObjectsInSameOrder_ShouldNotThrowAssertFailedException()
        {
            var o = new NoEqualityTestObject();
            var p = new NoEqualityTestObject { BooleanPropertyTest = true };

            var expected = new List<NoEqualityTestObject> { o, p };
            var actual = new List<NoEqualityTestObject> { o, p };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEquivalent<NoEqualityTestObject>(expected, actual);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEquivalent_ExpectedAndActualHaveSameObjectsInSameOrder_ShouldThrowAssertFailedExceptionIfNoEqualsOverride()
        {
            var expected = new List<NoEqualityTestObject> { new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true } };
            var actual = new List<NoEqualityTestObject> { new NoEqualityTestObject(), new NoEqualityTestObject { BooleanPropertyTest = true } };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEquivalent<NoEqualityTestObject>(expected, actual);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEquivalent_ExpectedAndActualHaveSameObjectsInSameOrder_ShouldNotThrowAssertFailedExceptionIfEqualsOverride()
        {
            var expected = new List<EqualityTestObject> { new EqualityTestObject(), new EqualityTestObject { BooleanPropertyTest = true } };
            var actual = new List<EqualityTestObject> { new EqualityTestObject(), new EqualityTestObject { BooleanPropertyTest = true } };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEquivalent<EqualityTestObject>(expected, actual);
                });
        }

        [TestMethod]
        public void
            AreEnumerablesEquivalent_ExpectedAndActualHaveSameReferenceObjectsInDifferentOrder_ShouldNotThrowAssertFailedException()
        {
            var o = new NoEqualityTestObject();
            var p = new NoEqualityTestObject { BooleanPropertyTest = true };

            var expected = new List<NoEqualityTestObject> { o, p };
            var actual = new List<NoEqualityTestObject> { p, o };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    CollectionAsserter.AreEnumerablesEquivalent<NoEqualityTestObject>(expected, actual);
                });
        }
    }
}