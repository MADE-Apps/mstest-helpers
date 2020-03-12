namespace MADE.Testing.MSTest.UnitTests
{
    using System;
    using System.Linq.Expressions;

    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsNull_ExpressionIsNull_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    Asserter.IsNull(default(Expression<Func<object>>));
                });
        }

        [TestMethod]
        public void IsNull_ConditionIsNull_ShouldNotThrowAssertFailedException()
        {
            var o = default(TestObject);

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsNull(() => o);
                });
        }

        [TestMethod]
        public void IsNull_ConditionIsNotNull_ShouldThrowAssertFailedException()
        {
            var o = new TestObject();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsNull(() => o);
                });
        }
    }
}