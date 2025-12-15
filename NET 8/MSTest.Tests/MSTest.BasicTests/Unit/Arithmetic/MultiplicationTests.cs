using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.BasicTests.Unit.Arithmetic;

[TestClass]
[TestCategory("Unit")]
public class MultiplicationTests
{
    [TestMethod]
    public void Multiply_TwoPositiveNumbers_ReturnsProduct()
    {
        var result = 5 * 3;
        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void Multiply_TwoNegativeNumbers_ReturnsPositive()
    {
        var result = (-5) * (-3);
        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void Multiply_PositiveAndNegative_ReturnsNegative()
    {
        var result = 5 * (-3);
        Assert.AreEqual(-15, result);
    }

    [TestMethod]
    public void Multiply_ByZero_ReturnsZero()
    {
        var result = 42 * 0;
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Multiply_ByOne_ReturnsOriginal()
    {
        var result = 42 * 1;
        Assert.AreEqual(42, result);
    }

    [DataTestMethod]
    [DataRow(2, 3, 6)]
    [DataRow(10, 10, 100)]
    [DataRow(-5, 4, -20)]
    [DataRow(7, 8, 56)]
    [DataRow(100, 0, 0)]
    [DataRow(1, 1000, 1000)]
    public void Multiply_VariousInputs_ReturnsCorrectProduct(int a, int b, int expected)
    {
        var result = a * b;
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Multiply_Decimals_ReturnsProduct()
    {
        var result = 2.5 * 4.0;
        Assert.AreEqual(10.0, result, 0.01);
    }

    [TestMethod]
    public void Multiply_LargeNumbers_ReturnsProduct()
    {
        var result = 1000 * 1000;
        Assert.AreEqual(1000000, result);
    }
}
