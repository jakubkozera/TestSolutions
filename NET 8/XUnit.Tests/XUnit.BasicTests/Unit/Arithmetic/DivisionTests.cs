using Xunit;

namespace XUnit.BasicTests.Unit.Arithmetic;

[Trait("Category", "Unit")]
[Trait("Component", "Arithmetic")]
public class DivisionTests
{
    [Fact]
    public void Divide_PositiveNumbers_ReturnsQuotient()
    {
        var result = 10 / 2;
        Assert.Equal(5, result);
    }

    [Fact]
    public void Divide_NegativeNumbers_ReturnsPositive()
    {
        var result = -10 / (-2);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Divide_PositiveByNegative_ReturnsNegative()
    {
        var result = 10 / (-2);
        Assert.Equal(-5, result);
    }

    [Fact]
    public void Divide_ByOne_ReturnsSameNumber()
    {
        var result = 42 / 1;
        Assert.Equal(42, result);
    }

    [Fact]
    public void Divide_ByMinusOne_ReturnsNegative()
    {
        var result = 42 / (-1);
        Assert.Equal(-42, result);
    }

    [Fact]
    public void Divide_ZeroByNumber_ReturnsZero()
    {
        var result = 0 / 5;
        Assert.Equal(0, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        int zero = 0;
        Assert.Throws<DivideByZeroException>(() => { var result = 10 / zero; });
    }

    [Fact]
    public void Divide_WithRemainder_ReturnsIntegerPart()
    {
        var result = 10 / 3;
        Assert.Equal(3, result);
    }

    [Fact]
    public void Divide_Decimals_ReturnsQuotient()
    {
        var result = 10.0 / 4.0;
        Assert.Equal(2.5, result, 10);
    }

    [Fact]
    public void Divide_LargeNumbers_ReturnsQuotient()
    {
        var result = 1000000 / 1000;
        Assert.Equal(1000, result);
    }

    [Fact]
    public void Divide_ResultingInFraction_Works()
    {
        var result = 5.0 / 2.0;
        Assert.Equal(2.5, result, 10);
    }

    [Fact]
    public void Divide_SameNumbers_ReturnsOne()
    {
        var result = 42 / 42;
        Assert.Equal(1, result);
    }

    [Fact]
    public void Divide_DecimalByZero_ThrowsException()
    {
        double zero = 0.0;
        Assert.Throws<DivideByZeroException>(() => { var result = 10.0 / 0; });
    }

    [Fact]
    public void Modulo_Operation_ReturnsRemainder()
    {
        var result = 10 % 3;
        Assert.Equal(1, result);
    }

    [Fact]
    public void Modulo_ExactDivision_ReturnsZero()
    {
        var result = 10 % 2;
        Assert.Equal(0, result);
    }
}
