namespace MADE.Testing.MSTest.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsInRangeDecimal_ConditionIsInRange_ShouldNotThrowAssertFailedException()
        {
            decimal condition = 10;
            decimal minimum = 5;
            decimal maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeDecimal_ConditionIsBelowMinimum_ShouldThrowAssertFailedException()
        {
            decimal condition = 2;
            decimal minimum = 5;
            decimal maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeDecimal_ConditionIsAboveMaximum_ShouldThrowAssertFailedException()
        {
            decimal condition = 20;
            decimal minimum = 5;
            decimal maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeDecimal_ConditionIsMinimum_ShouldNotThrowAssertFailedException()
        {
            decimal condition = 5;
            decimal minimum = condition;
            decimal maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeDecimal_ConditionIsMaximum_ShouldNotThrowAssertFailedException()
        {
            decimal condition = 15;
            decimal minimum = 5;
            decimal maximum = condition;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }
    }
}