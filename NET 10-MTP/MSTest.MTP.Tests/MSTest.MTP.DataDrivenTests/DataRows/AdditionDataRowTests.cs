using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.DataDrivenTests.DataRows;

[TestClass]
[TestCategory("Unit")]
public class AdditionDataRowTests
{
    [DataRow(1, 2, 3)]
    [DataRow(-1, 1, 0)]
    [DataRow(100, 200, 300)]
    [DataRow(0, 0, 0)]
    [DataRow(-5, -10, -15)]
    [DataTestMethod]
    public void Add_DataRow(int a, int b, int expected)
    {
        var result = a + b;
        Assert.AreEqual(expected, result);
    }

    [DataRow("hello", "HELLO")]
    [DataRow("World", "WORLD")]
    [DataRow("TeSt", "TEST")]
    [DataRow("", "")]
    [DataTestMethod]
    public void ToUpper_DataRow(string input, string expected)
    {
        var result = input.ToUpper();
        Assert.AreEqual(expected, result);
    }

    [DataRow(0, true)]
    [DataRow(2, true)]
    [DataRow(4, true)]
    [DataRow(1, false)]
    [DataRow(3, false)]
    [DataTestMethod]
    public void IsEven_DataRow(int number, bool expected)
    {
        var result = number % 2 == 0;
        Assert.AreEqual(expected, result);
    }

    [DataRow(5, 5, 25)]
    [DataRow(10, 0, 0)]
    [DataRow(-2, 3, -6)]
    [DataRow(7, 7, 49)]
    [DataTestMethod]
    public void Multiply_DataRow(int a, int b, int expected)
    {
        var result = a * b;
        Assert.AreEqual(expected, result);
    }

    [DataRow("hello world", "world", true)]
    [DataRow("hello world", "test", false)]
    [DataRow("Test String", "String", true)]
    [DataTestMethod]
    public void StringContains_DataRow(string text, string search, bool expected)
    {
        var result = text.Contains(search);
        Assert.AreEqual(expected, result);
    }

    [DataRow(10, 2, 5)]
    [DataRow(20, 4, 5)]
    [DataRow(15, 3, 5)]
    [DataRow(100, 10, 10)]
    [DataTestMethod]
    public void Divide_DataRow(int a, int b, int expected)
    {
        var result = a / b;
        Assert.AreEqual(expected, result);
    }

    [DataRow("hello", 5)]
    [DataRow("", 0)]
    [DataRow("test", 4)]
    [DataRow("a", 1)]
    [DataTestMethod]
    public void StringLength_DataRow(string input, int expected)
    {
        Assert.AreEqual(expected, input.Length);
    }

    [DataRow(1, 1)]
    [DataRow(2, 2)]
    [DataRow(3, 6)]
    [DataRow(4, 24)]
    [DataRow(5, 120)]
    [DataTestMethod]
    public void Factorial_DataRow(int n, int expected)
    {
        int Factorial(int x) => x <= 1 ? 1 : x * Factorial(x - 1);
        var result = Factorial(n);
        Assert.AreEqual(expected, result);
    }

    [DataRow(1000)]
    [DataRow(2000)]
    [DataRow(3000)]
    [DataTestMethod]
    public async Task LongRunning_DataRow(int delayMs)
    {
        await Task.Delay(delayMs);
        Assert.IsTrue(true);
    }

    [DataRow(0, 0, 1)]
    [DataRow(5, 0, 1)]
    [DataRow(2, 3, 8)]
    [DataRow(10, 2, 100)]
    [DataTestMethod]
    public void Power_DataRow(double baseNum, double exponent, double expected)
    {
        var result = Math.Pow(baseNum, exponent);
        Assert.AreEqual(expected, result);
    }
}
