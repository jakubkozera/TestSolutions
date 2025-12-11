using Xunit;

namespace XUnit.BasicTests.Unit.Arithmetic;

[Trait("Category", "Unit")]
[Trait("Component", "Arithmetic")]
public class MultiplicationTests
{
    [Fact]
    public void Multiply_PositiveNumbers_ReturnsProduct()
    {
        var result = 5 * 3;
        Assert.Equal(15, result);
    }

    [Fact]
    public void Multiply_NegativeNumbers_ReturnsPositive()
    {
        var result = -5 * (-3);
        Assert.Equal(15, result);
    }

    [Fact]
    public void Multiply_PositiveByNegative_ReturnsNegative()
    {
        var result = 5 * (-3);
        Assert.Equal(-15, result);
    }

    [Fact]
    public void Multiply_ByZero_ReturnsZero()
    {
        var result = 42 * 0;
        Assert.Equal(0, result);
    }

    [Fact]
    public void Multiply_ByOne_ReturnsSameNumber()
    {
        var result = 42 * 1;
        Assert.Equal(42, result);
    }

    [Fact]
    public void Multiply_ByMinusOne_ReturnsNegative()
    {
        var result = 42 * (-1);
        Assert.Equal(-42, result);
    }

    [Fact]
    public void Multiply_CommutativeProperty_Works()
    {
        var result1 = 7 * 13;
        var result2 = 13 * 7;
        Assert.Equal(result1, result2);
    }

    [Fact]
    public void Multiply_AssociativeProperty_Works()
    {
        var result1 = (2 * 3) * 4;
        var result2 = 2 * (3 * 4);
        Assert.Equal(result1, result2);
    }

    [Fact]
    public void Multiply_DistributiveProperty_Works()
    {
        var result1 = 2 * (3 + 4);
        var result2 = (2 * 3) + (2 * 4);
        Assert.Equal(result1, result2);
    }

    [Fact]
    public void Multiply_Decimals_ReturnsProduct()
    {
        var result = 2.5 * 4.0;
        Assert.Equal(10.0, result, 10);
    }
}
