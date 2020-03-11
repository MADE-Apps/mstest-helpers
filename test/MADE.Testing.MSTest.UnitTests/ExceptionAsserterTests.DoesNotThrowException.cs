namespace MADE.Testing.MSTest.UnitTests
{
    using System;

    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class ExceptionAsserterTests
    {
        [TestMethod]
        public void DoesNotThrowException_NullAction_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    ExceptionAsserter.DoesNotThrowException(null);
                });
        }
        
        [TestMethod]
        public void DoesNotThrowException_ActionThrowsException_ShouldThrowAssertFailedException()
        {
            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    ExceptionAsserter.DoesNotThrowException(() => throw new Exception());
                });
        }

        [TestMethod]
        public void DoesNotThrowException_ActionThrowsInheritedException_ShouldNotThrowAssertFailedException()
        {
            ExceptionAsserter.DoesNotThrowException(() => throw new TestException());
        }

        [TestMethod]
        public void DoesNotThrowGenericException_NullAction_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    ExceptionAsserter.DoesNotThrowException<TestException>(null);
                });
        }
        
        [TestMethod]
        public void DoesNotThrowGenericException_ActionThrowsExpectedException_ShouldThrowAssertFailedException()
        {
            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    ExceptionAsserter.DoesNotThrowException<TestException>(() => throw new TestException());
                });
        }

        [TestMethod]
        public void DoesNotThrowGenericException_ActionThrowsNotExpectedException_ShouldNotThrowAssertFailedException()
        {
            ExceptionAsserter.DoesNotThrowException<TestException>(() => throw new Exception());
        }
    }
}