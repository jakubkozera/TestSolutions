using NUnit.Framework;

namespace NUnit.BasicTests.Unit.Arithmetic;

[TestFixture]
[Category("Unit")]
public class MultiplicationTests
{
    [Test]
    public void Multiply_TwoPositiveNumbers_ReturnsProduct()
    {
        var result = 5 * 3;
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void Multiply_TwoNegativeNumbers_ReturnsPositive()
    {
        var result = (-5) * (-3);
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void Multiply_PositiveAndNegative_ReturnsNegative()
    {
        var result = 5 * (-3);
        Assert.That(result, Is.EqualTo(-15));
    }

    [Test]
    public void Multiply_ByZero_ReturnsZero()
    {
        var result = 42 * 0;
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Multiply_ByOne_ReturnsOriginal()
    {
        var result = 42 * 1;
        Assert.That(result, Is.EqualTo(42));
    }

    [TestCase(2, 3, 6)]
    [TestCase(10, 10, 100)]
    [TestCase(-5, 4, -20)]
    [TestCase(7, 8, 55)]
    [TestCase(100, 0, 0)]
    public void Multiply_VariousInputs_ReturnsCorrectProduct(int a, int b, int expected)
    {
        var result = a * b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Multiply_Decimals_ReturnsProduct()
    {
        var result = 2.5 * 4.0;
        Assert.That(result, Is.EqualTo(10.0).Within(0.01));
    }

    [Test]
    public void Multiply_LargeNumbers_ReturnsProduct()
    {
        var result = 1000 * 1000;
        Assert.That(result, Is.EqualTo(1000000));
    }
}
