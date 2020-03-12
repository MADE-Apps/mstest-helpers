namespace MADE.Testing.MSTest
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines a code assertion helper for exception based scenarios.
    /// </summary>
    public static class ExceptionAsserter
    {
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
            DoesNotThrowException(condition, string.Empty);
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
        public static void DoesNotThrowException<T>(Action condition)
            where T : Exception
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
        public static void DoesNotThrowException<T>(Action condition, string message)
            where T : Exception
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
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