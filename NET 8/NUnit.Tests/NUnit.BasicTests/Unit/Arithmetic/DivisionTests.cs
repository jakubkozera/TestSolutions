using NUnit.Framework;

namespace NUnit.BasicTests.Unit.Arithmetic;

[TestFixture]
[Category("Unit")]
public class DivisionTests
{
    [Test]
    public void Divide_TwoPositiveNumbers_ReturnsQuotient()
    {
        var result = 10 / 2;
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Divide_TwoNegativeNumbers_ReturnsPositive()
    {
        var result = (-10) / (-2);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Divide_PositiveByNegative_ReturnsNegative()
    {
        var result = 10 / (-2);
        Assert.That(result, Is.EqualTo(-5));
    }

    [Test]
    public void Divide_ByOne_ReturnsOriginal()
    {
        var result = 42 / 1;
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public void Divide_ZeroByNumber_ReturnsZero()
    {
        var result = 0 / 5;
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        int zero = 0;
        Assert.Throws<DivideByZeroException>(() => 
        {
            var result = 10 / zero;
        });
    }

    [TestCase(100, 10, 10)]
    [TestCase(50, 5, 10)]
    [TestCase(81, 9, 9)]
    [TestCase(-20, 4, -5)]
    [TestCase(7, 7, 1)]
    public void Divide_VariousInputs_ReturnsCorrectQuotient(int a, int b, int expected)
    {
        var result = a / b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Divide_Decimals_ReturnsQuotient()
    {
        var result = 10.0 / 4.0;
        Assert.That(result, Is.EqualTo(2.5).Within(0.01));
    }

    [Test]
    public void Divide_IntegerDivision_TruncatesResult()
    {
        var result = 10 / 3;
        Assert.That(result, Is.EqualTo(3));
    }
}
