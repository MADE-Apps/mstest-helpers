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
            var o = new TestObject { PropertyTest = false };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.PropertyTest);
                });
        }

        [TestMethod]
        public void IsFalse_ConditionIsTrueBooleanProperty_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { PropertyTest = true };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.PropertyTest);
                });
        }

        [TestMethod]
        public void IsFalse_ConditionIsFalseBooleanMethodResult_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject();

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.MethodTest(false));
                });
        }

        [TestMethod]
        public void IsFalse_ConditionIsTrueBooleanMethodResult_ShouldThrowAssertFailedException()
        {
            var o = new TestObject();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.MethodTest(true));
                });
        }
    }
}
