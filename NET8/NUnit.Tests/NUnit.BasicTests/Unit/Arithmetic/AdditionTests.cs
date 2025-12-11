using NUnit.Framework;

namespace NUnit.BasicTests.Unit.Arithmetic;

[TestFixture]
[Category("Unit")]
public class AdditionTests
{
    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        var result = 5 + 3;
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void Add_TwoNegativeNumbers_ReturnsSum()
    {
        var result = (-5) + (-3);
        Assert.That(result, Is.EqualTo(-8));
    }

    [Test]
    public void Add_PositiveAndNegative_ReturnsSum()
    {
        var result = 10 + (-5);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Add_ZeroAndNumber_ReturnsNumber()
    {
        var result = 0 + 42;
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public void Add_LargeNumbers_ReturnsSum()
    {
        var result = 1000000 + 2000000;
        Assert.That(result, Is.EqualTo(3000000));
    }

    [TestCase(1, 1, 2)]
    [TestCase(5, 10, 15)]
    [TestCase(-5, 5, 0)]
    [TestCase(100, 200, 300)]
    [TestCase(0, 0, 0)]
    public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
    {
        var result = a + b;
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Add_Decimals_ReturnsSum()
    {
        var result = 1.5 + 2.5;
        Assert.That(result, Is.EqualTo(4.0).Within(0.01));
    }

    [Test]
    public void Add_FloatingPoint_HandlesRounding()
    {
        var result = 0.1 + 0.2;
        Assert.That(result, Is.EqualTo(0.3).Within(0.0001));
    }

    [Test]
    public void Add_MaxValues_HandlesOverflow()
    {
        long result = (long)int.MaxValue + 1;
        Assert.That(result, Is.GreaterThan(int.MaxValue));
    }

    [Test]
    public void Add_MinValues_HandlesUnderflow()
    {
        long result = (long)int.MinValue - 1;
        Assert.That(result, Is.LessThan(int.MinValue));
    }
}
