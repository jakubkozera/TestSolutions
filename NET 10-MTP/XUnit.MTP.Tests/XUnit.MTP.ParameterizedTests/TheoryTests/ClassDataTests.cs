using Xunit;

namespace XUnit.ParameterizedTests.TheoryTests;

[Trait("Category", "Unit")]
public class ClassDataTests
{
    [Theory]
    [ClassData(typeof(ComplexObjectTestData))]
    public void ProcessComplexObject_WithClassData(Person person, string expectedFullName)
    {
        var fullName = $"{person.FirstName} {person.LastName}";
        Assert.Equal(expectedFullName, fullName);
    }

    [Theory]
    [ClassData(typeof(CollectionTestData))]
    public void ProcessCollection_WithClassData(List<int> numbers, int expectedSum)
    {
        var sum = numbers.Sum();
        Assert.Equal(expectedSum, sum);
    }

    [Theory]
    [ClassData(typeof(DictionaryTestData))]
    public void ProcessDictionary_WithClassData(Dictionary<string, int> dict, int expectedTotal)
    {
        var total = dict.Values.Sum();
        Assert.Equal(expectedTotal, total);
    }

    [Theory]
    [ClassData(typeof(NestedObjectTestData))]
    public void ProcessNestedObject_WithClassData(Order order, decimal expectedTotal)
    {
        var total = order.Items.Sum(i => i.Price * i.Quantity);
        Assert.Equal(expectedTotal, total);
    }

    [Theory]
    [ClassData(typeof(ArrayTestData))]
    public void ProcessArray_WithClassData(int[] numbers, int expectedMax)
    {
        var max = numbers.Max();
        Assert.Equal(expectedMax, max);
    }

    [Theory]
    [ClassData(typeof(ComplexCalculationData))]
    public void ComplexCalculation_WithClassData(CalculationInput input, double expectedResult)
    {
        var result = input.Values.Average() * input.Multiplier + input.Offset;
        Assert.Equal(expectedResult, result, 2);
    }
}

// Test data classes
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public List<OrderItem> Items { get; set; } = new();
}

public class OrderItem
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class CalculationInput
{
    public List<double> Values { get; set; } = new();
    public double Multiplier { get; set; }
    public double Offset { get; set; }
}

// ClassData implementations
public class ComplexObjectTestData : TheoryData<Person, string>
{
    public ComplexObjectTestData()
    {
        Add(new Person { FirstName = "John", LastName = "Doe", Age = 30 }, "John Doe");
        Add(new Person { FirstName = "Jane", LastName = "Smith", Age = 25 }, "Jane Smith");
        Add(new Person { FirstName = "Bob", LastName = "Johnson", Age = 45 }, "Bob Johnson");
        Add(new Person { FirstName = "Alice", LastName = "Williams", Age = 35 }, "Alice Williams");
        Add(new Person { FirstName = "Charlie", LastName = "Brown", Age = 40 }, "Charlie Brown");
    }
}

public class CollectionTestData : TheoryData<List<int>, int>
{
    public CollectionTestData()
    {
        Add(new List<int> { 1, 2, 3, 4, 5 }, 15);
        Add(new List<int> { 10, 20, 30 }, 60);
        Add(new List<int> { 100, 200, 300, 400 }, 1000);
        Add(new List<int> { 5, 10, 15, 20, 25 }, 75);
        Add(new List<int> { 1, 1, 1, 1, 1 }, 5);
    }
}

public class DictionaryTestData : TheoryData<Dictionary<string, int>, int>
{
    public DictionaryTestData()
    {
        Add(new Dictionary<string, int> { ["a"] = 1, ["b"] = 2, ["c"] = 3 }, 6);
        Add(new Dictionary<string, int> { ["x"] = 10, ["y"] = 20 }, 30);
        Add(new Dictionary<string, int> { ["one"] = 1 }, 1);
        Add(new Dictionary<string, int> { ["p"] = 5, ["q"] = 10, ["r"] = 15 }, 30);
    }
}

public class NestedObjectTestData : TheoryData<Order, decimal>
{
    public NestedObjectTestData()
    {
        Add(new Order
        {
            OrderId = 1,
            Items = new List<OrderItem>
            {
                new() { ProductName = "Item1", Price = 10.0m, Quantity = 2 },
                new() { ProductName = "Item2", Price = 5.0m, Quantity = 3 }
            }
        }, 35.0m);

        Add(new Order
        {
            OrderId = 2,
            Items = new List<OrderItem>
            {
                new() { ProductName = "Product1", Price = 100.0m, Quantity = 1 },
                new() { ProductName = "Product2", Price = 50.0m, Quantity = 2 }
            }
        }, 200.0m);

        Add(new Order
        {
            OrderId = 3,
            Items = new List<OrderItem>
            {
                new() { ProductName = "Widget", Price = 25.0m, Quantity = 4 }
            }
        }, 100.0m);
    }
}

public class ArrayTestData : TheoryData<int[], int>
{
    public ArrayTestData()
    {
        Add(new[] { 1, 2, 3, 4, 5 }, 5);
        Add(new[] { 10, 5, 8, 3, 12 }, 12);
        Add(new[] { 100, 50, 75, 25 }, 100);
        Add(new[] { 7, 7, 7, 7 }, 7);
        Add(new[] { -5, -10, -3, -1 }, -1);
    }
}

public class ComplexCalculationData : TheoryData<CalculationInput, double>
{
    public ComplexCalculationData()
    {
        Add(new CalculationInput 
        { 
            Values = new List<double> { 10, 20, 30 }, 
            Multiplier = 2, 
            Offset = 10 
        }, 50); // (10+20+30)/3 * 2 + 10 = 50

        Add(new CalculationInput 
        { 
            Values = new List<double> { 5, 5, 5, 5 }, 
            Multiplier = 3, 
            Offset = 5 
        }, 20); // 5 * 3 + 5 = 20

        Add(new CalculationInput 
        { 
            Values = new List<double> { 100, 200 }, 
            Multiplier = 1, 
            Offset = 0 
        }, 150); // 150 * 1 + 0 = 150
    }
}
