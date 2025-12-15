using NUnit.Framework;

namespace NUnit.ParameterizedTests.TestCases;

[TestFixture]
[Category("Unit")]
public class AdditionTestCases
{
    [TestCase(1, 2, 3)]
    [TestCase(-1, 1, 0)]
    [TestCase(100, 200, 300)]
    [TestCase(0, 0, 0)]
    [TestCase(-5, -10, -15)]
    public void Add_TestCase(int a, int b, int expected)
    {
        var result = a + b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("hello", "HELLO")]
    [TestCase("World", "WORLD")]
    [TestCase("TeSt", "TEST")]
    [TestCase("", "")]
    public void ToUpper_TestCase(string input, string expected)
    {
        var result = input.ToUpper();
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(0, true)]
    [TestCase(2, true)]
    [TestCase(4, true)]
    [TestCase(1, false)]
    [TestCase(3, false)]
    public void IsEven_TestCase(int number, bool expected)
    {
        var result = number % 2 == 0;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(5, 5, 25)]
    [TestCase(10, 0, 0)]
    [TestCase(-2, 3, -6)]
    [TestCase(7, 7, 49)]
    public void Multiply_TestCase(int a, int b, int expected)
    {
        var result = a * b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("hello world", "world", true)]
    [TestCase("hello world", "test", false)]
    [TestCase("Test String", "String", true)]
    public void StringContains_TestCase(string text, string search, bool expected)
    {
        var result = text.Contains(search);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(10, 2, 5)]
    [TestCase(20, 4, 5)]
    [TestCase(15, 3, 5)]
    [TestCase(100, 10, 10)]
    public void Divide_TestCase(int a, int b, int expected)
    {
        var result = a / b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("apple,banana,cherry", ',', 3)]
    [TestCase("one;two;three", ';', 3)]
    [TestCase("single", ',', 1)]
    public void Split_TestCase(string input, char separator, int expectedCount)
    {
        var result = input.Split(separator);
        Assert.That(result.Length, Is.EqualTo(expectedCount));
    }

    [TestCase("hello", 5)]
    [TestCase("", 0)]
    [TestCase("test", 4)]
    [TestCase("a", 1)]
    public void StringLength_TestCase(string input, int expected)
    {
        Assert.That(input.Length, Is.EqualTo(expected));
    }

    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 6)]
    [TestCase(4, 24)]
    [TestCase(5, 120)]
    public void Factorial_TestCase(int n, int expected)
    {
        int Factorial(int x) => x <= 1 ? 1 : x * Factorial(x - 1);
        var result = Factorial(n);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(0, 0, 1)]
    [TestCase(5, 0, 1)]
    [TestCase(2, 3, 8)]
    [TestCase(10, 2, 100)]
    public void Power_TestCase(double baseNum, double exponent, double expected)
    {
        var result = Math.Pow(baseNum, exponent);
        Assert.That(result, Is.EqualTo(expected));
    }
}
