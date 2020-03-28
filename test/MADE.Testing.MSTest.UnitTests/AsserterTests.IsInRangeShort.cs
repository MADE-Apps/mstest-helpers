namespace MADE.Testing.MSTest.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsInRangeShort_ConditionIsInRange_ShouldNotThrowAssertFailedException()
        {
            short condition = 10;
            short minimum = 5;
            short maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeShort_ConditionIsBelowMinimum_ShouldThrowAssertFailedException()
        {
            short condition = 2;
            short minimum = 5;
            short maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeShort_ConditionIsAboveMaximum_ShouldThrowAssertFailedException()
        {
            short condition = 20;
            short minimum = 5;
            short maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeShort_ConditionIsMinimum_ShouldNotThrowAssertFailedException()
        {
            short condition = 5;
            short minimum = condition;
            short maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeShort_ConditionIsMaximum_ShouldNotThrowAssertFailedException()
        {
            short condition = 15;
            short minimum = 5;
            short maximum = condition;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }
    }
}