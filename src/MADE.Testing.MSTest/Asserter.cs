namespace MADE.Testing.MSTest
{
    using System;
    using System.Linq.Expressions;

    using MADE.Testing.MSTest.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines an extended assertion model.
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
        /// Tests whether the code specified by delegate <paramref name="condition" /> does not throw an exception.
        /// </summary>
        /// <param name="condition">
        /// Delegate to code to be tested and which is expected to not throw an exception.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition"/> throws exception of type <typeparamref name="T"/>. </exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="condition"/> is <see langword="null"/>.</exception>
        public static void DoesNotThrowException(Action condition)
        {
            DoesNotThrowException<Exception>(condition, string.Empty);
        }

        /// <summary>
        /// Tests whether the code specified by delegate <paramref name="condition" /> does not throw an exception.
        /// </summary>
        /// <param name="condition">
        /// Delegate to code to be tested and which is expected to not throw an exception.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition" /> throws an exception.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition"/> throws exception of type <typeparamref name="T"/>. </exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="condition"/> is <see langword="null"/>.</exception>
        public static void DoesNotThrowException(Action condition, string message)
        {
            DoesNotThrowException<Exception>(condition, message);
        }

        /// <summary>
        /// Tests whether the code specified by delegate <paramref name="condition" /> does not throw an exception.
        /// </summary>
        /// <typeparam name="T">Type of exception expected to be thrown.</typeparam>
        /// <param name="condition">
        /// Delegate to code to be tested and which is expected to not throw an exception.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition"/> throws exception of type <typeparamref name="T"/>. </exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="condition"/> is <see langword="null"/>.</exception>
        public static void DoesNotThrowException<T>(Action condition) where T : Exception
        {
            DoesNotThrowException<T>(condition, string.Empty);
        }

        /// <summary>
        /// Tests whether the code specified by delegate <paramref name="condition"/> does not throw an exception.
        /// </summary>
        /// <typeparam name="T">Type of exception expected to be thrown.</typeparam>
        /// <param name="condition">
        /// Delegate to code to be tested and which is expected to not throw an exception.
        /// </param>
        /// <param name="message">
        /// The message to include in the exception when <paramref name="condition"/> throws an exception.
        /// </param>
        /// <exception cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown if <paramref name="condition"/> throws exception of type <typeparamref name="T"/>. </exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="condition"/> or <paramref name="message"/> is <see langword="null"/>.</exception>
        public static void DoesNotThrowException<T>(Action condition, string message) where T : Exception
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            try
            {
                condition();
            }
            catch (Exception ex)
            {
                // If the exception thrown is the type not expected, assertion fails.
                if (typeof(T) == ex.GetType())
                {
                    throw new AssertFailedException(message, ex);
                }
            }

            Assert.IsTrue(true, message);
        }
    }
}