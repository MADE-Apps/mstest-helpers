namespace MADE.Testing.MSTest.UnitTests
{
    using System;

    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsFalse_ConditionIsNull_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    Asserter.IsFalse(null);
                });
        }

        [TestMethod]
        public void IsFalse_ConditionIsFalseBooleanProperty_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = false };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.BooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsFalse_ConditionIsTrueBooleanProperty_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = true };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.BooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsFalse_ConditionIsFalseBooleanMethodResult_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject();

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.BooleanMethodTest(false));
                });
        }

        [TestMethod]
        public void IsFalse_ConditionIsTrueBooleanMethodResult_ShouldThrowAssertFailedException()
        {
            var o = new TestObject();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.BooleanMethodTest(true));
                });
        }

        [TestMethod]
        public void IsFalse_ConditionIsSimpleAndBinaryExpressionThatReturnsFalse_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = true };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => !(o.BooleanPropertyTest && o.BooleanMethodTest(true)));
                });
        }

        [TestMethod]
        public void
            IsFalse_ConditionIsComplexAndOrBinaryExpressionThatReturnsTrueForLeftPartButFalseForRightPart_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = true };
            var p = new TestObject { BooleanPropertyTest = false };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    // (!(true && true) || false ) == false
                    Asserter.IsFalse(() => !(o.BooleanPropertyTest && o.BooleanMethodTest(true)) || p.BooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsFalse_ConditionIsSimpleAndBinaryExpressionThatReturnsTrue_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = false };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    // (!(false && true)) == true
                    Asserter.IsFalse(() => !(o.BooleanPropertyTest && o.BooleanMethodTest(true)));
                });
        }

        [TestMethod]
        public void
            IsFalse_ConditionIsComplexAndOrBinaryExpressionThatReturnsTrueForAllParts_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { BooleanPropertyTest = true };
            var p = new TestObject { BooleanPropertyTest = true };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    // (!(true && false) || true) == true
                    Asserter.IsFalse(() => !(o.BooleanPropertyTest && o.BooleanMethodTest(false)) || p.BooleanPropertyTest);
                });
        }
    }
}
