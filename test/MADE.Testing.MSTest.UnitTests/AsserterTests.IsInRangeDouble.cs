namespace MADE.Testing.MSTest.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsInRangeDouble_ConditionIsInRange_ShouldNotThrowAssertFailedException()
        {
            double condition = 10;
            double minimum = 5;
            double maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeDouble_ConditionIsBelowMinimum_ShouldThrowAssertFailedException()
        {
            double condition = 2;
            double minimum = 5;
            double maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeDouble_ConditionIsAboveMaximum_ShouldThrowAssertFailedException()
        {
            double condition = 20;
            double minimum = 5;
            double maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeDouble_ConditionIsMinimum_ShouldNotThrowAssertFailedException()
        {
            double condition = 5;
            double minimum = condition;
            double maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeDouble_ConditionIsMaximum_ShouldNotThrowAssertFailedException()
        {
            double condition = 15;
            double minimum = 5;
            double maximum = condition;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }
    }
}