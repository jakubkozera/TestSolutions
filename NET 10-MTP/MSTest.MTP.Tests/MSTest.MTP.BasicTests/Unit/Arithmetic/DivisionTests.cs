using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.BasicTests.Unit.Arithmetic;

[TestClass]
[TestCategory("Unit")]
public class DivisionTests
{
    [TestMethod]
    public void Divide_TwoPositiveNumbers_ReturnsQuotient()
    {
        var result = 10 / 2;
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void Divide_TwoNegativeNumbers_ReturnsPositive()
    {
        var result = (-10) / (-2);
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void Divide_PositiveByNegative_ReturnsNegative()
    {
        var result = 10 / (-2);
        Assert.AreEqual(-5, result);
    }

    [TestMethod]
    public void Divide_ByOne_ReturnsOriginal()
    {
        var result = 42 / 1;
        Assert.AreEqual(42, result);
    }

    [TestMethod]
    public void Divide_ZeroByNumber_ReturnsZero()
    {
        var result = 0 / 5;
        Assert.AreEqual(0, result);
    }

    [DataTestMethod]
    [DataRow(100, 10, 10)]
    [DataRow(50, 5, 10)]
    [DataRow(81, 9, 9)]
    [DataRow(-20, 4, -5)]
    [DataRow(7, 7, 1)]
    [DataRow(1000, 10, 100)]
    public void Divide_VariousInputs_ReturnsCorrectQuotient(int a, int b, int expected)
    {
        var result = a / b;
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Divide_Decimals_ReturnsQuotient()
    {
        var result = 10.0 / 4.0;
        Assert.AreEqual(2.5, result, 0.01);
    }

    [TestMethod]
    public void Divide_IntegerDivision_TruncatesResult()
    {
        var result = 10 / 3;
        Assert.AreEqual(3, result);
    }
}
