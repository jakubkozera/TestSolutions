using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.BasicTests.Unit;

[TestClass]
[TestCategory("Unit")]
public class ArithmeticTests
{
    [TestMethod]
    public void Add_PositiveNumbers_ReturnsSum()
    {
        var result = 5 + 3;
        Assert.AreEqual(8, result);
    }

    [TestMethod]
    public void Add_NegativeNumbers_ReturnsSum()
    {
        var result = -5 + (-3);
        Assert.AreEqual(-8, result);
    }

    [TestMethod]
    public void Subtract_Numbers_ReturnsDifference()
    {
        var result = 10 - 3;
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void Multiply_Numbers_ReturnsProduct()
    {
        var result = 5 * 3;
        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void Divide_Numbers_ReturnsQuotient()
    {
        var result = 10 / 2;
        Assert.AreEqual(5, result);
    }

    // Note: Testing division by zero requires runtime evaluation
    [TestMethod]
    public void Divide_ByZero_ThrowsException()
    {
        try
        {
            int zero = 0;
            var result = 10 / zero;
            Assert.Fail("Expected DivideByZeroException");
        }
        catch (DivideByZeroException)
        {
            // Expected
            Assert.IsTrue(true);
        }
    }

    [TestMethod]
    public void Add_LargeNumbers_ReturnsSum()
    {
        var result = 1000000 + 2000000;
        Assert.AreEqual(3000000, result);
    }

    [TestMethod]
    public void Modulo_Operation_ReturnsRemainder()
    {
        var result = 10 % 3;
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    [TestCategory("Quick")]
    public void AbsoluteValue_NegativeNumber_ReturnsPositive()
    {
        var result = Math.Abs(-5);
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    [TestCategory("Quick")]
    public void Max_TwoNumbers_ReturnsLarger()
    {
        var result = Math.Max(5, 10);
        Assert.AreEqual(10, result);
    }

    [TestMethod]
    [TestCategory("Quick")]
    public void Min_TwoNumbers_ReturnsSmaller()
    {
        var result = Math.Min(5, 10);
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    [TestCategory("Quick")]
    public void Ceiling_RoundsUp()
    {
        var result = Math.Ceiling(4.3);
        Assert.AreEqual(5.0, result);
    }

    [TestMethod]
    [TestCategory("Quick")]
    public void Floor_RoundsDown()
    {
        var result = Math.Floor(4.7);
        Assert.AreEqual(4.0, result);
    }

    [TestMethod]
    public void Power_Operation_ReturnsCorrectValue()
    {
        var result = Math.Pow(2, 3);
        Assert.AreEqual(8.0, result);
    }

    [TestMethod]
    public void SquareRoot_ReturnsCorrectValue()
    {
        var result = Math.Sqrt(16);
        Assert.AreEqual(4.0, result);
    }
}
