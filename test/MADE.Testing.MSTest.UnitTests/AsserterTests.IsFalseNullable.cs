namespace MADE.Testing.MSTest.UnitTests
{
    using System;
    using System.Linq.Expressions;

    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsFalseNullable_ConditionIsNull_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    Asserter.IsFalse(default(Expression<Func<bool?>>));
                });
        }

        [TestMethod]
        public void IsFalseNullable_ConditionIsNullBooleanProperty_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { NullableBooleanPropertyTest = null };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.NullableBooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsFalseNullable_ConditionIsFalseBooleanProperty_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject { NullableBooleanPropertyTest = false };

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.NullableBooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsFalseNullable_ConditionIsTrueBooleanProperty_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { NullableBooleanPropertyTest = true };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.NullableBooleanPropertyTest);
                });
        }

        [TestMethod]
        public void IsFalseNullable_ConditionIsNullBooleanMethodResult_ShouldThrowAssertFailedException()
        {
            var o = new TestObject();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.NullableBooleanMethodTest(null));
                });
        }

        [TestMethod]
        public void IsFalseNullable_ConditionIsFalseBooleanMethodResult_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject();

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.NullableBooleanMethodTest(false));
                });
        }

        [TestMethod]
        public void IsFalseNullable_ConditionIsTrueBooleanMethodResult_ShouldThrowAssertFailedException()
        {
            var o = new TestObject();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsFalse(() => o.NullableBooleanMethodTest(true));
                });
        }
    }
}