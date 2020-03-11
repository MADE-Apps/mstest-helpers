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
            var o = new TestObject { PropertyTest = true };

            Asserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.PropertyTest);
                });
        }

        [TestMethod]
        public void IsTrue_ConditionIsFalseBooleanProperty_ShouldThrowAssertFailedException()
        {
            var o = new TestObject { PropertyTest = false };

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.PropertyTest);
                });
        }

        [TestMethod]
        public void IsTrue_ConditionIsTrueBooleanMethodResult_ShouldNotThrowAssertFailedException()
        {
            var o = new TestObject();

            Asserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.MethodTest(true));
                });
        }

        [TestMethod]
        public void IsTrue_ConditionIsFalseBooleanMethodResult_ShouldThrowAssertFailedException()
        {
            var o = new TestObject();

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsTrue(() => o.MethodTest(false));
                });
        }
    }
}