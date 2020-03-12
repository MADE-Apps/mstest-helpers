namespace MADE.Testing.MSTest.UnitTests
{
    using System;
    using System.Linq.Expressions;

    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsNotNull_ExpressionIsNull_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    Asserter.IsNotNull(default(Expression<Func<object>>));
                });
        }

        [TestMethod]
        public void IsNotNull_ConditionIsNotNull_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject();

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsNotNull(() => o);
                });
        }

        [TestMethod]
        public void IsNotNull_ConditionIsNull_ShouldThrowAssertFailedException()
        {
            var o = default(TestObject);

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsNotNull(() => o);
                });
        }
    }
}