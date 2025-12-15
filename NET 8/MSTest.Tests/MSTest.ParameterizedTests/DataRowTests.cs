using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.ParameterizedTests;

[TestClass]
[TestCategory("Unit")]
public class DataRowTests
{
    [DataTestMethod]
    [DataRow(1, 1, 2)]
    [DataRow(5, 10, 15)]
    [DataRow(-5, 5, 0)]
    [DataRow(100, 200, 300)]
    [DataRow(0, 0, 0)]
    [DataRow(999, 1, 1000)]
    [DataRow(-10, -20, -30)]
    [DataRow(50, 50, 100)]
    [DataRow(7, 8, 15)]
    [DataRow(25, 75, 100)]
    public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
    {
        var result = a + b;
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(10, 5, 5)]
    [DataRow(100, 50, 50)]
    [DataRow(0, 10, -10)]
    [DataRow(-10, -5, -5)]
    [DataRow(1000, 1, 999)]
    [DataRow(25, 25, 0)]
    [DataRow(50, 30, 20)]
    [DataRow(200, 150, 50)]
    public void Subtract_VariousInputs_ReturnsCorrectDifference(int a, int b, int expected)
    {
        var result = a - b;
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(2, 3, 6)]
    [DataRow(10, 10, 100)]
    [DataRow(-5, 4, -20)]
    [DataRow(7, 8, 56)]
    [DataRow(100, 0, 0)]
    [DataRow(1, 1000, 1000)]
    [DataRow(5, 5, 25)]
    [DataRow(12, 12, 144)]
    public void Multiply_VariousInputs_ReturnsCorrectProduct(int a, int b, int expected)
    {
        var result = a * b;
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(100, 10, 10)]
    [DataRow(50, 5, 10)]
    [DataRow(81, 9, 9)]
    [DataRow(-20, 4, -5)]
    [DataRow(7, 7, 1)]
    [DataRow(1000, 10, 100)]
    [DataRow(144, 12, 12)]
    [DataRow(64, 8, 8)]
    public void Divide_VariousInputs_ReturnsCorrectQuotient(int a, int b, int expected)
    {
        var result = a / b;
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("hello", "world", "helloworld")]
    [DataRow("test", "", "test")]
    [DataRow("", "test", "test")]
    [DataRow("foo", "bar", "foobar")]
    [DataRow("a", "b", "ab")]
    [DataRow("Hello", " World", "Hello World")]
    [DataRow("C#", " is great", "C# is great")]
    public void Concat_VariousStrings_ReturnsConcatenated(string a, string b, string expected)
    {
        var result = a + b;
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("HELLO", "hello")]
    [DataRow("World", "world")]
    [DataRow("TEST", "test")]
    [DataRow("ABC", "abc")]
    [DataRow("XYZ", "xyz")]
    [DataRow("CSharp", "csharp")]
    public void ToLower_VariousStrings_ReturnsLowercase(string input, string expected)
    {
        var result = input.ToLower();
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("hello", "HELLO")]
    [DataRow("world", "WORLD")]
    [DataRow("test", "TEST")]
    [DataRow("abc", "ABC")]
    [DataRow("xyz", "XYZ")]
    [DataRow("csharp", "CSHARP")]
    public void ToUpper_VariousStrings_ReturnsUppercase(string input, string expected)
    {
        var result = input.ToUpper();
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("Hello World", "Hello", true)]
    [DataRow("test string", "test", true)]
    [DataRow("example", "xyz", false)]
    [DataRow("CSharp", "Sharp", true)]
    [DataRow("", "test", false)]
    [DataRow("programming", "gram", true)]
    public void Contains_VariousStrings_ReturnsCorrectResult(string text, string substring, bool expected)
    {
        var result = text.Contains(substring);
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(1, true)]
    [DataRow(0, false)]
    [DataRow(100, true)]
    [DataRow(-1, true)]
    [DataRow(42, true)]
    public void IsNonZero_VariousNumbers_ReturnsCorrectResult(int number, bool expected)
    {
        var result = number != 0;
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(5, true)]
    [DataRow(-5, false)]
    [DataRow(0, false)]
    [DataRow(100, true)]
    [DataRow(-100, false)]
    [DataRow(1, true)]
    public void IsPositive_VariousNumbers_ReturnsCorrectResult(int number, bool expected)
    {
        var result = number > 0;
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(2, true)]
    [DataRow(3, false)]
    [DataRow(4, true)]
    [DataRow(7, false)]
    [DataRow(10, true)]
    [DataRow(11, false)]
    public void IsEven_VariousNumbers_ReturnsCorrectResult(int number, bool expected)
    {
        var result = number % 2 == 0;
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("test.txt", ".txt")]
    [DataRow("document.pdf", ".pdf")]
    [DataRow("image.jpg", ".jpg")]
    [DataRow("file.cs", ".cs")]
    [DataRow("readme.md", ".md")]
    [DataRow("script.ps1", ".ps1")]
    public void GetExtension_VariousFiles_ReturnsCorrectExtension(string filename, string expected)
    {
        var result = System.IO.Path.GetExtension(filename);
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(10, 100, true)]
    [DataRow(50, 100, true)]
    [DataRow(101, 100, false)]
    [DataRow(0, 100, true)]
    [DataRow(-1, 100, false)]
    [DataRow(100, 100, true)]
    public void IsWithinRange_VariousValues_ReturnsCorrectResult(int value, int max, bool expected)
    {
        var result = value >= 0 && value <= max;
        Assert.AreEqual(expected, result);
    }
}
