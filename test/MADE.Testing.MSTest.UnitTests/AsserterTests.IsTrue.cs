namespace MADE.Testing.MSTest.UnitTests
{
    using System;

    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsTrue_ConditionIsNull_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    Asserter.IsTrue(null);
                });
        }

        [TestMethod]
        public void IsTrue_ConditionIsTrueBooleanProperty_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = true };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.BooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsTrue_ConditionIsFalseBooleanProperty_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = false };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.BooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsTrue_ConditionIsTrueBooleanMethodResult_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject();

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.BooleanMethodTest(true));
                });
        }

        [TestMethod]
        public void IsTrue_ConditionIsFalseBooleanMethodResult_ShouldThrowAssertFailedException()
        {
            var o = new TestObject();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.BooleanMethodTest(false));
                });
        }

        [TestMethod]
        public void IsTrue_ConditionIsSimpleAndBinaryExpressionThatReturnsTrue_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = true };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.BooleanPropertyTest && o.BooleanMethodTest(true));
                });
        }

        [TestMethod]
        public void
            IsTrue_ConditionIsComplexAndOrBinaryExpressionThatReturnsTrueForLeftPart_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = true };
            var p = new TestObject { BooleanPropertyTest = false };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => (o.BooleanPropertyTest && o.BooleanMethodTest(true)) || !p.BooleanPropertyTest);
                });
        }

        [TestMethod]
        public void
            IsTrue_ConditionIsComplexAndOrBinaryExpressionThatReturnsFalseForLeftPartButTrueForRightPart_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = true };
            var p = new TestObject { BooleanPropertyTest = false };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => (o.BooleanPropertyTest && o.BooleanMethodTest(false)) || !p.BooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsTrue_ConditionIsSimpleAndBinaryExpressionThatReturnsFalse_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = false };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.BooleanPropertyTest && o.BooleanMethodTest(true));
                });
        }

        [TestMethod]
        public void
            IsTrue_ConditionIsComplexAndOrBinaryExpressionThatReturnsFalseForAllParts_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = true };
            var p = new TestObject { BooleanPropertyTest = true };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => (o.BooleanPropertyTest && o.BooleanMethodTest(false)) || !p.BooleanPropertyTest);
                });
        }
    }
}