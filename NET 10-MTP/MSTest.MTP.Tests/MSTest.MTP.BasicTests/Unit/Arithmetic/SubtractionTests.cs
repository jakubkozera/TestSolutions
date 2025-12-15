using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.BasicTests.Unit.Arithmetic;

[TestClass]
[TestCategory("Unit")]
public class SubtractionTests
{
    [TestMethod]
    public void Subtract_TwoPositiveNumbers_ReturnsDifference()
    {
        var result = 10 - 3;
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void Subtract_TwoNegativeNumbers_ReturnsDifference()
    {
        var result = (-5) - (-3);
        Assert.AreEqual(-2, result);
    }

    [TestMethod]
    public void Subtract_FromZero_ReturnsNegative()
    {
        var result = 0 - 10;
        Assert.AreEqual(-10, result);
    }

    [TestMethod]
    public void Subtract_Zero_ReturnsOriginal()
    {
        var result = 42 - 0;
        Assert.AreEqual(42, result);
    }

    [TestMethod]
    public void Subtract_SameNumber_ReturnsZero()
    {
        var result = 25 - 25;
        Assert.AreEqual(0, result);
    }

    [DataTestMethod]
    [DataRow(10, 5, 5)]
    [DataRow(100, 50, 50)]
    [DataRow(0, 10, -10)]
    [DataRow(-10, -5, -5)]
    [DataRow(1000, 1, 999)]
    [DataRow(25, 25, 0)]
    public void Subtract_VariousInputs_ReturnsCorrectDifference(int a, int b, int expected)
    {
        var result = a - b;
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Subtract_Decimals_ReturnsDifference()
    {
        var result = 5.5 - 2.2;
        Assert.AreEqual(3.3, result, 0.01);
    }

    [TestMethod]
    public void Subtract_LargeNumbers_ReturnsDifference()
    {
        var result = 1000000 - 500000;
        Assert.AreEqual(500000, result);
    }
}
