# Test Model Helper

Test Model Helper is a C# library for generating test data for unit/functional/integration tests

## Installing

```
Install-Package TestModelHelper
```

Or install the TestModelHelper in Visual Studio Nuget Package Manager

## Using the Library

Examples shown using MSTest, but other test frameworks should work fine

```
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    [TestClass]
    public class ExampleTests
    {

        public TestModelHelper<Person> _testModelHelper;

        [TestInitialize]
        public void Setup()
        {
            _testModelHelper = new TestModelHelper<Person>(new Person
            {
                FirstName = "Charlie",
                LastName = "Awesomeguy"
            });
        }

        [TestMethod]
        public void Test1()
        {
            var validData = _testModelHelper.CreateOriginalTestData(); // Creates copy of original person
            var invalidData = _testModelHelper.CreateModifiedTestData(r => r.FirstName = "Someone"); // Created modified copy of original person

            Assert.AreEqual("Charlie", validData.FirstName); // Passes
            Assert.AreEqual("Charlie", invalidData.FirstName); // Fails
        }
    }
```

## Available Methods

### CreateOriginalTestData

Creates a copy of your original test model and returns it. Modifications to this test model will not effect the original

```
    var validTestData = _testModelHelper.CreateOriginalTestData();
```

### CreateModifiedTestData

Creates a copy of your original test model, then runs the linq expression on it. This is meant to make invalid or modified test data for specific edge cases in applications

```
    var testData = _testModelHelper.CreateModifiedTestData(r => r.FirstName = "Someone");
```