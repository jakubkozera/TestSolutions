using Xunit;

namespace XUnit.BasicTests.Unit.Arithmetic;

[Trait("Category", "Unit")]
[Trait("Component", "Arithmetic")]
public class SubtractionTests
{
    [Fact]
    public void Subtract_PositiveNumbers_ReturnsDifference()
    {
        var result = 10 - 3;
        Assert.Equal(7, result);
    }

    [Fact]
    public void Subtract_NegativeNumbers_ReturnsDifference()
    {
        var result = -5 - (-3);
        Assert.Equal(-2, result);
    }

    [Fact]
    public void Subtract_NegativeFromPositive_ReturnsSum()
    {
        var result = 10 - (-5);
        Assert.Equal(15, result);
    }

    [Fact]
    public void Subtract_SameNumbers_ReturnsZero()
    {
        var result = 42 - 42;
        Assert.Equal(0, result);
    }

    [Fact]
    public void Subtract_FromZero_ReturnsNegative()
    {
        var result = 0 - 7;
        Assert.Equal(-7, result);
    }

    [Fact]
    public void Subtract_Zero_ReturnsSameNumber()
    {
        var result = 42 - 0;
        Assert.Equal(42, result);
    }

    [Fact]
    public void Subtract_LargeNumbers_ReturnsDifference()
    {
        var result = 5000000 - 2000000;
        Assert.Equal(3000000, result);
    }

    [Fact]
    public void Subtract_Decimals_ReturnsDifference()
    {
        var result = 1.5 - 0.3;
        Assert.Equal(1.2, result, 10);
    }

    [Fact]
    public void Subtract_ResultingInNegative_Works()
    {
        var result = 5 - 10;
        Assert.Equal(-5, result);
    }

    [Fact]
    public void Subtract_MinValue_Works()
    {
        long result = (long)int.MinValue - 1;
        Assert.Equal(-2147483649L, result);
    }
}
