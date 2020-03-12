namespace MADE.Testing.MSTest.UnitTests
{
    using System;
    using System.Reflection.Metadata.Ecma335;
    using System.Threading.Tasks;

    using MADE.Testing.MSTest.UnitTests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class ExceptionAsserterTests
    {
        [TestMethod]
        public async Task DoesNotThrowExceptionAsync_ActionIsNull_ShouldThrowArgumentNullException()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () =>
                {
                    await ExceptionAsserter.DoesNotThrowExceptionAsync(null);
                });
        }

        [TestMethod]
        public async Task DoesNotThrowExceptionAsync_ActionThrowsException_ShouldThrowAssertFailedException()
        {
            await Assert.ThrowsExceptionAsync<AssertFailedException>(
                async () =>
                {
                    await ExceptionAsserter.DoesNotThrowExceptionAsync(() => throw new Exception());
                });
        }

        [TestMethod]
        public async Task
            DoesNotThrowExceptionAsync_ActionThrowsInheritedException_ShouldNotThrowAssertFailedException()
        {
            await ExceptionAsserter.DoesNotThrowExceptionAsync(() => throw new TestException());
        }

        [TestMethod]
        public async Task DoesNotThrowGenericExceptionAsync_ActionIsNull_ShouldThrowArgumentNullException()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () =>
                {
                    await ExceptionAsserter.DoesNotThrowExceptionAsync<TestException>(null);
                });
        }

        [TestMethod]
        public async Task
            DoesNotThrowGenericExceptionAsync_ActionThrowsExpectedException_ShouldThrowAssertFailedException()
        {
            await Assert.ThrowsExceptionAsync<AssertFailedException>(
                async () =>
                {
                    await ExceptionAsserter.DoesNotThrowExceptionAsync<TestException>(() => throw new TestException());
                });
        }

        [TestMethod]
        public async Task
            DoesNotThrowGenericExceptionAsync_ActionThrowsNotExpectedException_ShouldNotThrowAssertFailedException()
        {
            await ExceptionAsserter.DoesNotThrowExceptionAsync<TestException>(() => throw new Exception());
        }
    }
}