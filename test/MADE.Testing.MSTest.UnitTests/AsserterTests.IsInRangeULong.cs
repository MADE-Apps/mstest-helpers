namespace MADE.Testing.MSTest.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsInRangeULong_ConditionIsInRange_ShouldNotThrowAssertFailedException()
        {
            ulong condition = 10;
            ulong minimum = 5;
            ulong maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeULong_ConditionIsBelowMinimum_ShouldThrowAssertFailedException()
        {
            ulong condition = 2;
            ulong minimum = 5;
            ulong maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeULong_ConditionIsAboveMaximum_ShouldThrowAssertFailedException()
        {
            ulong condition = 20;
            ulong minimum = 5;
            ulong maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeULong_ConditionIsMinimum_ShouldNotThrowAssertFailedException()
        {
            ulong condition = 5;
            ulong minimum = condition;
            ulong maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeULong_ConditionIsMaximum_ShouldNotThrowAssertFailedException()
        {
            ulong condition = 15;
            ulong minimum = 5;
            ulong maximum = condition;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }
    }
}