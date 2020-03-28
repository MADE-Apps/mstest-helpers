namespace MADE.Testing.MSTest.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsInRangeInt_ConditionIsInRange_ShouldNotThrowAssertFailedException()
        {
            int condition = 10;
            int minimum = 5;
            int maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeInt_ConditionIsBelowMinimum_ShouldThrowAssertFailedException()
        {
            int condition = 2;
            int minimum = 5;
            int maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeInt_ConditionIsAboveMaximum_ShouldThrowAssertFailedException()
        {
            int condition = 20;
            int minimum = 5;
            int maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeInt_ConditionIsMinimum_ShouldNotThrowAssertFailedException()
        {
            int condition = 5;
            int minimum = condition;
            int maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeInt_ConditionIsMaximum_ShouldNotThrowAssertFailedException()
        {
            int condition = 15;
            int minimum = 5;
            int maximum = condition;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }
    }
}