namespace MADE.Testing.MSTest.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsInRangeByte_ConditionIsInRange_ShouldNotThrowAssertFailedException()
        {
            byte condition = 10;
            byte minimum = 5;
            byte maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeByte_ConditionIsBelowMinimum_ShouldThrowAssertFailedException()
        {
            byte condition = 2;
            byte minimum = 5;
            byte maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeByte_ConditionIsAboveMaximum_ShouldThrowAssertFailedException()
        {
            byte condition = 20;
            byte minimum = 5;
            byte maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeByte_ConditionIsMinimum_ShouldNotThrowAssertFailedException()
        {
            byte condition = 5;
            byte minimum = condition;
            byte maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeByte_ConditionIsMaximum_ShouldNotThrowAssertFailedException()
        {
            byte condition = 15;
            byte minimum = 5;
            byte maximum = condition;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }
    }
}