namespace MADE.Testing.MSTest.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsInRangeUInt_ConditionIsInRange_ShouldNotThrowAssertFailedException()
        {
            uint condition = 10;
            uint minimum = 5;
            uint maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeUInt_ConditionIsBelowMinimum_ShouldThrowAssertFailedException()
        {
            uint condition = 2;
            uint minimum = 5;
            uint maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeUInt_ConditionIsAboveMaximum_ShouldThrowAssertFailedException()
        {
            uint condition = 20;
            uint minimum = 5;
            uint maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeUInt_ConditionIsMinimum_ShouldNotThrowAssertFailedException()
        {
            uint condition = 5;
            uint minimum = condition;
            uint maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeUInt_ConditionIsMaximum_ShouldNotThrowAssertFailedException()
        {
            uint condition = 15;
            uint minimum = 5;
            uint maximum = condition;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }
    }
}