namespace MADE.Testing.MSTest.Extensions
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Defines a collection of extensions for <see cref="Expression{TDelegate}"/> objects.
    /// </summary>
    internal static class ExpressionExtensions
    {
        /// <summary>
        /// Gets the argument name from an expression.
        /// </summary>
        /// <param name="argumentExpression">
        /// The expression to get the name from.
        /// </param>
        /// <typeparam name="T">
        /// The type of value.
        /// </typeparam>
        /// <returns>
        /// Returns the name of the argument.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the property expression is null.
        /// </exception>
        internal static string GetArgumentName<T>(this Expression<Func<T>> argumentExpression)
        {
            if (object.Equals(argumentExpression, null))
            {
                throw new ArgumentNullException(nameof(argumentExpression));
            }

            string argumentName = null;
            switch (argumentExpression.Body)
            {
                case MemberExpression memberExpression:
                    argumentName = memberExpression.Member?.Name;
                    break;
                case MethodCallExpression methodCallExpression:
                    argumentName = methodCallExpression.Method?.Name;
                    break;
            }

            if (string.IsNullOrWhiteSpace(argumentName))
            {
                argumentName = nameof(argumentExpression);
            }

            return argumentName;
        }
    }
}