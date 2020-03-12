# CollectionAsserter

As explained in the [Overview](Overview.md), the CollectionAsserter is a collection of additional and improved code assertion methods for enumerable collections where the MSTest CollectionAssert equivalent doesn't provide alternatives, such as `AreEnumerablesEqual`.

The CollectionAsserter provides the following code assertion extensions:

## AreEnumerablesEqual

This method tests whether the specified enumerables are equal and throws an exception if the two enumerables are not equal. Equality is defined as having the same elements, compared using Equals, in the same order and same quantity. 

**Example**

```csharp
[TestMethod]
public void Setup_WhenCalledWithPopulateItems_ShouldAddEachItemToItemsProperty()
{
    // Arrange

    var expected = new List<EqualityTestObject> { new EqualityTestObject(), new EqualityTestObject { BooleanPropertyTest = true } };

    var model = new EqualityModel();

    // Act

    model.Setup(expected);

    IEnumerable<EqualityTestObject> actual = model.Items;

    // Assert

    CollectionAsserter.AreEnumerablesEqual<EqualityTestObject>(expected, actual);
}
```

There is also an overload which contains an additional parameter to provide your own comparer for the items in the collections.

## AreEnumerablesEquivalent

This method tests whether two collections contain the same elements and throws an exception if either collection contains an element not in the other collection.

The benefit of this method over `AreEnumerablesEqual` is that the order of the items does not matter, as long as both enumerables contain all the items.

**Example**

```csharp
[TestMethod]
public void Setup_WhenCalledWithPopulateItems_ShouldAddEachItemToItemsProperty()
{
    // Arrange

    var expected = new List<EqualityTestObject> { new EqualityTestObject(), new EqualityTestObject { BooleanPropertyTest = true } };

    var model = new EqualityModel();

    // Act

    model.Setup(expected);

    IEnumerable<EqualityTestObject> actual = model.Items;

    // Assert

    CollectionAsserter.AreEnumerablesEquivalent<EqualityTestObject>(expected, actual);
}
```