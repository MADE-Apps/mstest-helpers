# ExceptionAsserter

As explained in the [Overview](Overview.md), the ExceptionAsserter is a collection of additional and improved code assertion methods for exception checks where the MSTest Assert equivalent doesn't provide alternatives, such as `DoesNotThrowException`.

The ExceptionAsserter provides the following code assertion extensions:

## DoesNotThrowException

This method tests whether the code specified by delegate condition called does not throw an exception.

**Example**

```csharp
[TestMethod]
public void Setup_WhenCalledWithNullItems_ShouldNotThrowNullReferenceException()
{
    // Arrange

    IEnumerable<EqualityTestObject> items = default(IEnumerable<EqualityTestObject>);

    var model = new EqualityModel();

    // Act & Assert

    ExceptionAsserter.DoesNotThrowException(() => model.Setup(items));
}
```

There is also an asynchronous alternative `DoesNotThrowExceptionAsync` for testing asynchronous operations.