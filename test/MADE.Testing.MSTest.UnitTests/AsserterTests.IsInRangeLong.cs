namespace MADE.Testing.MSTest.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsInRangeLong_ConditionIsInRange_ShouldNotThrowAssertFailedException()
        {
            long condition = 10;
            long minimum = 5;
            long maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeLong_ConditionIsBelowMinimum_ShouldThrowAssertFailedException()
        {
            long condition = 2;
            long minimum = 5;
            long maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeLong_ConditionIsAboveMaximum_ShouldThrowAssertFailedException()
        {
            long condition = 20;
            long minimum = 5;
            long maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeLong_ConditionIsMinimum_ShouldNotThrowAssertFailedException()
        {
            long condition = 5;
            long minimum = condition;
            long maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeLong_ConditionIsMaximum_ShouldNotThrowAssertFailedException()
        {
            long condition = 15;
            long minimum = 5;
            long maximum = condition;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }
    }
}