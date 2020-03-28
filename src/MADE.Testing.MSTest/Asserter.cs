namespace MADE.Testing.MSTest
{
    using System;
    using System.Linq.Expressions;

    using MADE.Testing.MSTest.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines a code assertion helper for common scenarios.
    /// </summary>
    public static class Asserter
    {
        /// <summary>
        /// Tests whether the specified condition is true and throws an exception if the condition is false.
        /// </summary>
        /// <param name="condition"> The condition the test expects to be true.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if condition is <see langword="null"/>.</exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition" /> is false.</exception>
        public static void IsTrue(Expression<Func<bool>> condition)
        {
            IsTrue(condition, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is true and throws an exception if the condition is false.
        /// </summary>
        /// <param name="condition">The condition the test expects to be true.</param>
        /// <param name="message">The message to include in the exception when <paramref name="condition" /> is false. The message is shown in test results.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="condition"/> is <see langword="null"/>.</exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition" /> is false.</exception>
        public static void IsTrue(Expression<Func<bool>> condition, string message)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            string argumentName = condition.GetArgumentName();
            bool value = condition.Compile().Invoke();

            Assert.IsTrue(
                value,
                $"{nameof(Asserter.IsTrue)} failed. Expected:<True>. Actual:<{value}>. Failed on: {argumentName}. {message}");
        }

        /// <summary>
        /// Tests whether the specified condition is true and throws an exception if the condition is false or null.
        /// </summary>
        /// <param name="condition"> The condition the test expects to be true.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if condition is <see langword="null"/>.</exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition" /> is false or null.</exception>
        public static void IsTrue(Expression<Func<bool?>> condition)
        {
            IsTrue(condition, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is true and throws an exception if the condition is false or null.
        /// </summary>
        /// <param name="condition">The condition the test expects to be true.</param>
        /// <param name="message">The message to include in the exception when <paramref name="condition" /> is false or null. The message is shown in test results.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="condition"/> is <see langword="null"/>.</exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition" /> is false or null.</exception>
        public static void IsTrue(Expression<Func<bool?>> condition, string message)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            string argumentName = condition.GetArgumentName();
            bool? value = condition.Compile().Invoke();

            switch (value)
            {
                case null:
                    Assert.Fail(
                        $"{nameof(Asserter.IsTrue)} failed. Expected:<True>. Actual:<NULL>. Failed on: {argumentName}. {message}");
                    break;
                default:
                    Assert.IsTrue(
                        value.Value,
                        $"{nameof(Asserter.IsTrue)} failed. Expected:<True>. Actual:<{value.Value}>. Failed on: {argumentName}. {message}");
                    break;
            }
        }

        /// <summary>
        /// Tests whether the specified condition is false and throws an exception if the condition is true.
        /// </summary>
        /// <param name="condition">The condition the test expects to be false.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="condition"/> is <see langword="null"/>.</exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition" /> is true.</exception>
        public static void IsFalse(Expression<Func<bool>> condition)
        {
            IsFalse(condition, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is false and throws an exception if the condition is true.
        /// </summary>
        /// <param name="condition">The condition the test expects to be false.</param>
        /// <param name="message">The message to include in the exception when <paramref name="condition" /> is true. The message is shown in test results.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="condition"/> is <see langword="null"/>.</exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition" /> is true.</exception>
        public static void IsFalse(Expression<Func<bool>> condition, string message)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            string argumentName = condition.GetArgumentName();
            bool value = condition.Compile().Invoke();

            Assert.IsFalse(
                value,
                $"{nameof(Asserter.IsFalse)} failed. Expected:<False>. Actual:<{value}>. Failed on: {argumentName}. {message}");
        }

        /// <summary>
        /// Tests whether the specified condition is false and throws an exception if the condition is true or null.
        /// </summary>
        /// <param name="condition">The condition the test expects to be false.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="condition"/> is <see langword="null"/>.</exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition" /> is true or null.</exception>
        public static void IsFalse(Expression<Func<bool?>> condition)
        {
            IsFalse(condition, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is false and throws an exception if the condition is true or null.
        /// </summary>
        /// <param name="condition">The condition the test expects to be false.</param>
        /// <param name="message">The message to include in the exception when <paramref name="condition" /> is true or null. The message is shown in test results.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="condition"/> is <see langword="null"/>.</exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition" /> is true or null.</exception>
        public static void IsFalse(Expression<Func<bool?>> condition, string message)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            string argumentName = condition.GetArgumentName();
            bool? value = condition.Compile().Invoke();

            switch (value)
            {
                case null:
                    Assert.Fail(
                        $"{nameof(Asserter.IsFalse)} failed. Expected:<False>. Actual:<NULL>. Failed on: {argumentName}. {message}");
                    break;
                default:
                    Assert.IsFalse(
                        value.Value,
                        $"{nameof(Asserter.IsFalse)} failed. Expected:<False>. Actual:<{value.Value}>. Failed on: {argumentName}. {message}");
                    break;
            }
        }

        /// <summary>
        /// Tests whether the specified condition is null and throws an exception if the condition is not null.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to run a function on.
        /// </typeparam>
        /// <param name="condition">
        /// The condition the test expects to be null.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not null.
        /// </exception>
        public static void IsNull<T>(Expression<Func<T>> condition)
        {
            IsNull<T>(condition, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is null and throws an exception if the condition is not null.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to run a function on.
        /// </typeparam>
        /// <param name="condition">
        /// The condition the test expects to be null.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is not null. The message is shown in test results.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not null.
        /// </exception>
        public static void IsNull<T>(Expression<Func<T>> condition, string message)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            string argumentName = condition.GetArgumentName();
            T value = condition.Compile().Invoke();

            Assert.IsNull(
                value,
                $"{nameof(Asserter.IsNull)} failed. Expected:<NULL>. Actual:<{value}>. Failed on: {argumentName}.");
        }

        /// <summary>
        /// Tests whether the specified condition is not null and throws an exception if the condition is null.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to run a function on.
        /// </typeparam>
        /// <param name="condition">
        /// The condition the test expects to be not null.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static void IsNotNull<T>(Expression<Func<T>> condition)
        {
            IsNotNull<T>(condition, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is not null and throws an exception if the condition is null.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to run a function on.
        /// </typeparam>
        /// <param name="condition">
        /// The condition the test expects to be not null.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is null. The message is shown in test results.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if <paramref name="condition"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is null.
        /// </exception>
        public static void IsNotNull<T>(Expression<Func<T>> condition, string message)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            string argumentName = condition.GetArgumentName();
            T value = condition.Compile().Invoke();

            Assert.IsNotNull(
                value,
                $"{nameof(Asserter.IsNotNull)} failed. Expected:<{value}>. Actual:<NULL>. Failed on: {argumentName}.");
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(byte condition, byte minimum, byte maximum)
        {
            IsInRange(condition, minimum, maximum, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not met.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is not in the range. The message is shown in test results.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(byte condition, byte minimum, byte maximum, string message)
        {
            if (condition < minimum || condition > maximum)
            {
                Assert.Fail($"{nameof(Asserter.IsInRange)} failed. Expected between:{minimum}-{maximum}. Actual:{condition}. {message}");
            }
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(sbyte condition, sbyte minimum, sbyte maximum)
        {
            IsInRange(condition, minimum, maximum, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not met.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is not in the range. The message is shown in test results.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(sbyte condition, sbyte minimum, sbyte maximum, string message)
        {
            if (condition < minimum || condition > maximum)
            {
                Assert.Fail($"{nameof(Asserter.IsInRange)} failed. Expected between:{minimum}-{maximum}. Actual:{condition}. {message}");
            }
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(short condition, short minimum, short maximum)
        {
            IsInRange(condition, minimum, maximum, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not met.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is not in the range. The message is shown in test results.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(short condition, short minimum, short maximum, string message)
        {
            if (condition < minimum || condition > maximum)
            {
                Assert.Fail($"{nameof(Asserter.IsInRange)} failed. Expected between:{minimum}-{maximum}. Actual:{condition}. {message}");
            }
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(ushort condition, ushort minimum, ushort maximum)
        {
            IsInRange(condition, minimum, maximum, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not met.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is not in the range. The message is shown in test results.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(ushort condition, ushort minimum, ushort maximum, string message)
        {
            if (condition < minimum || condition > maximum)
            {
                Assert.Fail($"{nameof(Asserter.IsInRange)} failed. Expected between:{minimum}-{maximum}. Actual:{condition}. {message}");
            }
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(int condition, int minimum, int maximum)
        {
            IsInRange(condition, minimum, maximum, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not met.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is not in the range. The message is shown in test results.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(int condition, int minimum, int maximum, string message)
        {
            if (condition < minimum || condition > maximum)
            {
                Assert.Fail($"{nameof(Asserter.IsInRange)} failed. Expected between:{minimum}-{maximum}. Actual:{condition}. {message}");
            }
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(uint condition, uint minimum, uint maximum)
        {
            IsInRange(condition, minimum, maximum, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not met.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is not in the range. The message is shown in test results.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(uint condition, uint minimum, uint maximum, string message)
        {
            if (condition < minimum || condition > maximum)
            {
                Assert.Fail($"{nameof(Asserter.IsInRange)} failed. Expected between:{minimum}-{maximum}. Actual:{condition}. {message}");
            }
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(long condition, long minimum, long maximum)
        {
            IsInRange(condition, minimum, maximum, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not met.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is not in the range. The message is shown in test results.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(long condition, long minimum, long maximum, string message)
        {
            if (condition < minimum || condition > maximum)
            {
                Assert.Fail($"{nameof(Asserter.IsInRange)} failed. Expected between:{minimum}-{maximum}. Actual:{condition}. {message}");
            }
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(ulong condition, ulong minimum, ulong maximum)
        {
            IsInRange(condition, minimum, maximum, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not met.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is not in the range. The message is shown in test results.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(ulong condition, ulong minimum, ulong maximum, string message)
        {
            if (condition < minimum || condition > maximum)
            {
                Assert.Fail($"{nameof(Asserter.IsInRange)} failed. Expected between:{minimum}-{maximum}. Actual:{condition}. {message}");
            }
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(double condition, double minimum, double maximum)
        {
            IsInRange(condition, minimum, maximum, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not met.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is not in the range. The message is shown in test results.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(double condition, double minimum, double maximum, string message)
        {
            if (condition < minimum || condition > maximum)
            {
                Assert.Fail($"{nameof(Asserter.IsInRange)} failed. Expected between:{minimum}-{maximum}. Actual:{condition}. {message}");
            }
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(decimal condition, decimal minimum, decimal maximum)
        {
            IsInRange(condition, minimum, maximum, string.Empty);
        }

        /// <summary>
        /// Tests whether the specified condition is in the valid minimum and maximum range and throws an exception if the condition is not met.
        /// </summary>
        /// <param name="condition">
        /// The condition the test expects to be in the expected range.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> is not in the range. The message is shown in test results.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">
        /// Thrown if <paramref name="condition"/> is not in range.
        /// </exception>
        public static void IsInRange(decimal condition, decimal minimum, decimal maximum, string message)
        {
            if (condition < minimum || condition > maximum)
            {
                Assert.Fail($"{nameof(Asserter.IsInRange)} failed. Expected between:{minimum}-{maximum}. Actual:{condition}. {message}");
            }
        }
    }
}