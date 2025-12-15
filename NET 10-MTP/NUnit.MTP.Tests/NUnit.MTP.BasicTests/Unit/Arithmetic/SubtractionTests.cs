using NUnit.Framework;

namespace NUnit.BasicTests.Unit.Arithmetic;

[TestFixture]
[Category("Unit")]
public class SubtractionTests
{
    [Test]
    public void Subtract_TwoPositiveNumbers_ReturnsDifference()
    {
        var result = 10 - 3;
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void Subtract_TwoNegativeNumbers_ReturnsDifference()
    {
        var result = (-5) - (-3);
        Assert.That(result, Is.EqualTo(-2));
    }

    [Test]
    public void Subtract_FromZero_ReturnsNegative()
    {
        var result = 0 - 10;
        Assert.That(result, Is.EqualTo(-10));
    }

    [Test]
    public void Subtract_Zero_ReturnsOriginal()
    {
        var result = 42 - 0;
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public void Subtract_SameNumber_ReturnsZero()
    {
        var result = 25 - 25;
        Assert.That(result, Is.EqualTo(0));
    }

    [TestCase(10, 5, 5)]
    [TestCase(100, 50, 50)]
    [TestCase(0, 10, -10)]
    [TestCase(-10, -2, -5)]
    [TestCase(1000, 1, 999)]
    public void Subtract_VariousInputs_ReturnsCorrectDifference(int a, int b, int expected)
    {
        var result = a - b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Subtract_Decimals_ReturnsDifference()
    {
        var result = 5.5 - 2.2;
        Assert.That(result, Is.EqualTo(3.3).Within(0.01));
    }

    [Test]
    public void Subtract_LargeNumbers_ReturnsDifference()
    {
        var result = 1000000 - 500000;
        Assert.That(result, Is.EqualTo(500000));
    }
}
