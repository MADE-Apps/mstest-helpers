namespace MADE.Testing.MSTest.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AsserterTests
    {
        [TestMethod]
        public void IsInRangeUShort_ConditionIsInRange_ShouldNotThrowAssertFailedException()
        {
            ushort condition = 10;
            ushort minimum = 5;
            ushort maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeUShort_ConditionIsBelowMinimum_ShouldThrowAssertFailedException()
        {
            ushort condition = 2;
            ushort minimum = 5;
            ushort maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeUShort_ConditionIsAboveMaximum_ShouldThrowAssertFailedException()
        {
            ushort condition = 20;
            ushort minimum = 5;
            ushort maximum = 15;

            Assert.ThrowsException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeUShort_ConditionIsMinimum_ShouldNotThrowAssertFailedException()
        {
            ushort condition = 5;
            ushort minimum = condition;
            ushort maximum = 15;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }

        [TestMethod]
        public void IsInRangeUShort_ConditionIsMaximum_ShouldNotThrowAssertFailedException()
        {
            ushort condition = 15;
            ushort minimum = 5;
            ushort maximum = condition;

            ExceptionAsserter.DoesNotThrowException<AssertFailedException>(
                () =>
                {
                    Asserter.IsInRange(condition, minimum, maximum);
                });
        }
    }
}