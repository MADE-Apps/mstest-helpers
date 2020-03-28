namespace MADE.Testing.MSTest.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsInRangeSByte_ConditionIsInRange_ShouldNotThrowAssertFailedException()
        {
            sbyte condition = 10;
            sbyte minimum = 5;
            sbyte maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeSByte_ConditionIsBelowMinimum_ShouldThrowAssertFailedException()
        {
            sbyte condition = 2;
            sbyte minimum = 5;
            sbyte maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeSByte_ConditionIsAboveMaximum_ShouldThrowAssertFailedException()
        {
            sbyte condition = 20;
            sbyte minimum = 5;
            sbyte maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeSByte_ConditionIsMinimum_ShouldNotThrowAssertFailedException()
        {
            sbyte condition = 5;
            sbyte minimum = condition;
            sbyte maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeSByte_ConditionIsMaximum_ShouldNotThrowAssertFailedException()
        {
            sbyte condition = 15;
            sbyte minimum = 5;
            sbyte maximum = condition;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }
    }
}