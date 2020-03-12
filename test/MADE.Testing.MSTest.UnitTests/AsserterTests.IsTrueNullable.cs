namespace MADE.Testing.MSTest.UnitTests
{
    using System;
    using System.Linq.Expressions;

    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsTrueNullable_ExpressionIsNull_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    Asserter.IsTrue(default(Expression<Func<bool?>>));
                });
        }

        [TestMethod]
        public void IsTrueNullable_ConditionIsNullBooleanProperty_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { NullableBooleanPropertyTest = null };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.NullableBooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsTrueNullable_ConditionIsTrueBooleanProperty_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject { NullableBooleanPropertyTest = true };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.NullableBooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsTrueNullable_ConditionIsFalseBooleanProperty_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { NullableBooleanPropertyTest = false };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.NullableBooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsTrueNullable_ConditionIsNullBooleanMethodResult_ShouldThrowAssertFailedException()
        {
            var o = new TestObject();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.NullableBooleanMethodTest(null));
                });
        }

        [TestMethod]
        public void IsTrueNullable_ConditionIsTrueBooleanMethodResult_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject();

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.NullableBooleanMethodTest(true));
                });
        }

        [TestMethod]
        public void IsTrueNullable_ConditionIsFalseBooleanMethodResult_ShouldThrowAssertFailedException()
        {
            var o = new TestObject();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.NullableBooleanMethodTest(false));
                });
        }
    }
}