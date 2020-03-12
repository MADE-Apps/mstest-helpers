# Asserter

As explained in the [Overview](Overview.md), the Asserter is a collection of additional and improved code assertion methods where the MSTest Assert equivalent doesn't provide useful messages when the assertion fails.

The Asserter provides the following code assertion extensions:

## IsTrue

This method tests whether the specified condition is true and throws an exception if the condition is false. 

The method comes as an improvement over the MSTest `Assert.IsTrue` for two reasons. Firstly, the failure message provides useful information showing what is false. More importantly, the condition parameter takes an Expression which allows you to build up an assertion through multiple parameters.

**Example**

```csharp
[TestMethod]
public void TestObject_WhenBooleanMethodCalledWithTrueParameter_ShouldReturnTrueAndSetBooleanPropertyTestToFalse()
{
    // Arrange

    var o = new TestObject { BooleanPropertyTest = true };

    // Act & Assert

    Asserter.IsTrue(() => !o.BooleanPropertyTest && o.BooleanMethodTest(true));
}
```

## IsFalse

This method tests whether the specified condition is false and throws an exception if the condition is true.

The method comes as an improvement over the MSTest `Assert.IsFalse` for two reasons. Firstly, the failure message provides useful information showing what is true. More importantly, the condition parameter takes an Expression which allows you to build up an assertion through multiple parameters.

**Example**

```csharp
[TestMethod]
public void TestObject_WhenBooleanMethodCalledWithFalseParameter_ShouldSetBooleanPropertyTestToFalse()
{
    // Arrange

    var o = new TestObject { BooleanPropertyTest = true };

    // Act

    o.BooleanMethodTest(false);

    // Assert

    Asserter.IsFalse(() => o.BooleanPropertyTest);
}
```

## IsNull

This method tests whether the specified condition is null and throws an exception if the condition is not null.

The method comes as an improvement over the MSTest `Assert.IsNull` for two reasons. Firstly, the failure message provides useful information showing what is not null. More importantly, the condition parameter takes an Expression which allows you to build up an assertion through multiple parameters.

**Example**

```csharp
[TestMethod]
public void TestObject_WhenNullableBooleanMethodCalledWithNullParameter_ShouldSetNullableBooleanPropertyTestToNull()
{
    // Arrange

    var o = new TestObject { NullableBooleanPropertyTest = true };

    // Act

    o.NullableBooleanMethodTest(null);

    // Assert

    Asserter.IsNull(() => o.NullableBooleanPropertyTest);
}
```

## IsNotNull

This method tests whether the specified condition is not null and throws an exception if the condition is null.

The method comes as an improvement over the MSTest `Assert.IsNotNull` for two reasons. Firstly, the failure message provides useful information showing what is null. More importantly, the condition parameter takes an Expression which allows you to build up an assertion through multiple parameters.

**Example**

```csharp
[TestMethod]
public void TestObject_WhenNullableBooleanMethodCalledWithTrueParameter_ShouldSetNullableBooleanPropertyTestToTrue()
{
    // Arrange

    var o = new TestObject { NullableBooleanPropertyTest = null };

    // Act

    o.NullableBooleanMethodTest(true);

    // Assert

    Asserter.IsNotNull(() => o.NullableBooleanPropertyTest);
}
```