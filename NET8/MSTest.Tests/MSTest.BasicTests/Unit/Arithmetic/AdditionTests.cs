using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.BasicTests.Unit.Arithmetic;

[TestClass]
[TestCategory("Unit")]
public class AdditionTests
{
    [TestMethod]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        var result = 5 + 3;
        Assert.AreEqual(8, result);
    }

    [TestMethod]
    public void Add_TwoNegativeNumbers_ReturnsSum()
    {
        var result = (-5) + (-3);
        Assert.AreEqual(-8, result);
    }

    [TestMethod]
    public void Add_PositiveAndNegative_ReturnsSum()
    {
        var result = 10 + (-5);
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void Add_ZeroAndNumber_ReturnsNumber()
    {
        var result = 0 + 42;
        Assert.AreEqual(42, result);
    }

    [TestMethod]
    public void Add_LargeNumbers_ReturnsSum()
    {
        var result = 1000000 + 2000000;
        Assert.AreEqual(3000000, result);
    }

    [DataTestMethod]
    [DataRow(1, 1, 2)]
    [DataRow(5, 10, 15)]
    [DataRow(-5, 5, 0)]
    [DataRow(100, 200, 300)]
    [DataRow(0, 0, 0)]
    [DataRow(999, 1, 1000)]
    [DataRow(-10, -20, -30)]
    [DataRow(50, 50, 100)]
    public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
    {
        var result = a + b;
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Add_Decimals_ReturnsSum()
    {
        var result = 1.5 + 2.5;
        Assert.AreEqual(4.0, result, 0.01);
    }

    [TestMethod]
    public void Add_FloatingPoint_HandlesRounding()
    {
        var result = 0.1 + 0.2;
        Assert.AreEqual(0.3, result, 0.0001);
    }

    [TestMethod]
    public void Add_MaxValues_HandlesOverflow()
    {
        long result = (long)int.MaxValue + 1;
        Assert.IsTrue(result > int.MaxValue);
    }

    [TestMethod]
    public void Add_MinValues_HandlesUnderflow()
    {
        long result = (long)int.MinValue - 1;
        Assert.IsTrue(result < int.MinValue);
    }
}
