namespace MADE.Testing.MSTest.UnitTests.Helpers
{
    /// <summary>
    /// Provides an object that can be tested.
    /// </summary>
    internal class TestObject
    {
        /// <summary>
        /// Gets or sets a boolean property for testing.
        /// </summary>
        public bool BooleanPropertyTest { get; set; }

        /// <summary>
        /// Gets or sets a nullable boolean property for testing.
        /// </summary>
        public bool? NullableBooleanPropertyTest { get; set; }

        /// <summary>
        /// Provides a method with a boolean return type for testing.
        /// </summary>
        /// <param name="value">
        /// The value to be return.
        /// </param>
        /// <returns>
        /// True if the <paramref name="value"/> is true; otherwise, false.
        /// </returns>
        public bool BooleanMethodTest(bool value)
        {
            return value;
        }

        /// <summary>
        /// Provides a method with a boolean return type for testing.
        /// </summary>
        /// <param name="value">
        /// The value to be return.
        /// </param>
        /// <returns>
        /// Null if the <paramref name="value"/> is null; True if the <paramref name="value"/> is true; otherwise, false.
        /// </returns>
        public bool? NullableBooleanMethodTest(bool? value)
        {
            return value;
        }
    }
}