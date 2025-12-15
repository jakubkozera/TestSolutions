using NUnit.Framework;

namespace NUnit.BasicTests.Unit;

[TestFixture]
[Category("Unit")]
public class ArithmeticTests
{
    [Test]
    public void Add_PositiveNumbers_ReturnsSum()
    {
        var result = 5 + 3;
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void Add_NegativeNumbers_ReturnsSum()
    {
        var result = -5 + (-3);
        Assert.That(result, Is.EqualTo(-8));
    }

    [Test]
    public void Subtract_Numbers_ReturnsDifference()
    {
        var result = 10 - 3;
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void Multiply_Numbers_ReturnsProduct()
    {
        var result = 5 * 3;
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void Divide_Numbers_ReturnsQuotient()
    {
        var result = 10 / 2;
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        int zero = 0;
        Assert.Throws<DivideByZeroException>(() => { var result = 10 / zero; });
    }

    [Test]
    public void Add_LargeNumbers_ReturnsSum()
    {
        var result = 1000000 + 2000000;
        Assert.That(result, Is.EqualTo(3000000));
    }

    [Test]
    public void Modulo_Operation_ReturnsRemainder()
    {
        var result = 10 % 3;
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Power_Operation_ReturnsCorrectValue()
    {
        var result = Math.Pow(2, 3);
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void SquareRoot_ReturnsCorrectValue()
    {
        var result = Math.Sqrt(16);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    [Category("Quick")]
    public void AbsoluteValue_NegativeNumber_ReturnsPositive()
    {
        var result = Math.Abs(-5);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    [Category("Quick")]
    public void Max_TwoNumbers_ReturnsLarger()
    {
        var result = Math.Max(5, 10);
        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    [Category("Quick")]
    public void Min_TwoNumbers_ReturnsSmaller()
    {
        var result = Math.Min(5, 10);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    [Category("Quick")]
    public void Ceiling_RoundsUp()
    {
        var result = Math.Ceiling(4.3);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    [Category("Quick")]
    public void Floor_RoundsDown()
    {
        var result = Math.Floor(4.7);
        Assert.That(result, Is.EqualTo(4));
    }
}
