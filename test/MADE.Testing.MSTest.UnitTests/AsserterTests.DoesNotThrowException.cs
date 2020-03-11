namespace MADE.Testing.MSTest.UnitTests
{
    using System;

    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void DoesNotThrowException_NullAction_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    Asserter.DoesNotThrowException(null);
                });
        }
        
        [TestMethod]
        public void DoesNotThrowException_ActionThrowsException_ShouldThrowAssertFailedException()
        {
            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.DoesNotThrowException(() => throw new Exception());
                });
        }

        [TestMethod]
        public void DoesNotThrowException_ActionThrowsInheritedException_ShouldNotThrowAssertFailedException()
        {
            Asserter.DoesNotThrowException(() => throw new TestException());
        }

        [TestMethod]
        public void DoesNotThrowGenericException_NullAction_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    Asserter.DoesNotThrowException<TestException>(null);
                });
        }
        
        [TestMethod]
        public void DoesNotThrowGenericException_ActionThrowsExpectedException_ShouldThrowAssertFailedException()
        {
            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.DoesNotThrowException<TestException>(() => throw new TestException());
                });
        }

        [TestMethod]
        public void DoesNotThrowGenericException_ActionThrowsNotExpectedException_ShouldNotThrowAssertFailedException()
        {
            Asserter.DoesNotThrowException<TestException>(() => throw new Exception());
        }
    }
}