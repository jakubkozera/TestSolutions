using NUnit.Framework;

namespace NUnit.ParameterizedTests;

[TestFixture]
[Category("Unit")]
public class ParameterizedTests
{
    [TestCase(1, 1, 2)]
    [TestCase(5, 10, 15)]
    [TestCase(-5, 5, 0)]
    [TestCase(100, 200, 300)]
    [TestCase(0, 0, 0)]
    [TestCase(999, 1, 1000)]
    [TestCase(-10, -20, -30)]
    [TestCase(50, 50, 100)]
    public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
    {
        var result = a + b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(10, 5, 5)]
    [TestCase(100, 50, 50)]
    [TestCase(0, 10, -10)]
    [TestCase(-10, -5, -5)]
    [TestCase(1000, 1, 999)]
    [TestCase(25, 25, 0)]
    public void Subtract_VariousInputs_ReturnsCorrectDifference(int a, int b, int expected)
    {
        var result = a - b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(2, 3, 6)]
    [TestCase(10, 10, 100)]
    [TestCase(-5, 4, -20)]
    [TestCase(7, 8, 56)]
    [TestCase(100, 0, 0)]
    [TestCase(1, 1000, 1000)]
    public void Multiply_VariousInputs_ReturnsCorrectProduct(int a, int b, int expected)
    {
        var result = a * b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(100, 10, 10)]
    [TestCase(50, 5, 10)]
    [TestCase(81, 9, 9)]
    [TestCase(-20, 4, -5)]
    [TestCase(7, 7, 1)]
    [TestCase(1000, 10, 100)]
    public void Divide_VariousInputs_ReturnsCorrectQuotient(int a, int b, int expected)
    {
        var result = a / b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("hello", "world", "helloworld")]
    [TestCase("test", "", "test")]
    [TestCase("", "test", "test")]
    [TestCase("foo", "bar", "foobar")]
    [TestCase("a", "b", "ab")]
    public void Concat_VariousStrings_ReturnsConcatenated(string a, string b, string expected)
    {
        var result = a + b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("HELLO", "hello")]
    [TestCase("World", "world")]
    [TestCase("TEST", "test")]
    [TestCase("ABC", "abc")]
    [TestCase("XYZ", "xyz")]
    public void ToLower_VariousStrings_ReturnsLowercase(string input, string expected)
    {
        var result = input.ToLower();
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("hello", "HELLO")]
    [TestCase("world", "WORLD")]
    [TestCase("test", "TEST")]
    [TestCase("abc", "ABC")]
    [TestCase("xyz", "XYZ")]
    public void ToUpper_VariousStrings_ReturnsUppercase(string input, string expected)
    {
        var result = input.ToUpper();
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Hello World", "Hello", true)]
    [TestCase("test string", "test", true)]
    [TestCase("example", "xyz", false)]
    [TestCase("CSharp", "Sharp", true)]
    [TestCase("", "test", false)]
    public void Contains_VariousStrings_ReturnsCorrectResult(string text, string substring, bool expected)
    {
        var result = text.Contains(substring);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 15)]
    [TestCase(new int[] { 10, 20, 30 }, 60)]
    [TestCase(new int[] { 100, 200, 300, 400 }, 1000)]
    [TestCase(new int[] { 0, 0, 0 }, 0)]
    [TestCase(new int[] { -5, 5 }, 0)]
    public void Sum_VariousCollections_ReturnsCorrectSum(int[] numbers, int expected)
    {
        var result = numbers.Sum();
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
    [TestCase(new int[] { 10, 5, 8, 3, 12 }, 12)]
    [TestCase(new int[] { 100, 50, 75, 25 }, 100)]
    [TestCase(new int[] { 7, 7, 7, 7 }, 7)]
    [TestCase(new int[] { -5, -10, -3, -1 }, -1)]
    public void Max_VariousCollections_ReturnsMaxValue(int[] numbers, int expected)
    {
        var result = numbers.Max();
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1, true)]
    [TestCase(0, false)]
    [TestCase(100, true)]
    [TestCase(-1, true)]
    [TestCase(int.MaxValue, true)]
    public void IsNonZero_VariousNumbers_ReturnsCorrectResult(int number, bool expected)
    {
        var result = number != 0;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(5, true)]
    [TestCase(-5, false)]
    [TestCase(0, false)]
    [TestCase(100, true)]
    [TestCase(-100, false)]
    public void IsPositive_VariousNumbers_ReturnsCorrectResult(int number, bool expected)
    {
        var result = number > 0;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(2, true)]
    [TestCase(3, false)]
    [TestCase(4, true)]
    [TestCase(7, false)]
    [TestCase(10, true)]
    public void IsEven_VariousNumbers_ReturnsCorrectResult(int number, bool expected)
    {
        var result = number % 2 == 0;
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("test.txt", ".txt")]
    [TestCase("document.pdf", ".pdf")]
    [TestCase("image.jpg", ".jpg")]
    [TestCase("file.cs", ".cs")]
    [TestCase("readme.md", ".md")]
    public void GetExtension_VariousFiles_ReturnsCorrectExtension(string filename, string expected)
    {
        var result = System.IO.Path.GetExtension(filename);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(10, 100, true)]
    [TestCase(50, 100, true)]
    [TestCase(101, 100, false)]
    [TestCase(0, 100, true)]
    [TestCase(-1, 100, false)]
    public void IsWithinRange_VariousValues_ReturnsCorrectResult(int value, int max, bool expected)
    {
        var result = value >= 0 && value <= max;
        Assert.That(result, Is.EqualTo(expected));
    }
}
