# Overview

MADE Microsoft Test Framework Extension Library is separated into multiple extension and helper classes for code assertion:

- [Asserter](../src/MADE.Testing.MSTest/Asserter.cs)
    - Defines a code assertion helper for common scenarios, similar to the [MSTest Assert](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert).
- [CollectionAsserter](../src/MADE.Testing.MSTest/CollectionAsserter.cs)
    - Defines a code assertion helper for collection based scenarios, similar to the [MSTest CollectionAssert](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.collectionassert).
- [ExceptionAsserter](../src/MADE.Testing.MSTest/ExcpetionAsserter.cs)
    - Defines a code assertion helper for exception based scenarios.

## Asserter

The Asserter is a collection of additional and improved code assertion methods where the MSTest Assert equivalent doesn't provide useful messages when the assertion fails.

[Read more about Asserter](Asserter.md).

## CollectionAsserter

The CollectionAsserter is a collection of additional and improved code assertion methods for enumerable collections where the MSTest CollectionAssert equivalent doesn't provide alternatives, such as `AreEnumerablesEqual`.

[Read more about CollectionAsserter](CollectionAsserter.md).

## ExceptionAsserter

The ExceptionAsserter is a collection of additional and improved code assertion methods for exception checks where the MSTest Assert equivalent doesn't provide alternatives, such as `DoesNotThrowException`.

[Read more about ExceptionAsserter](ExceptionAsserter.md).
