using Xunit;

namespace XUnit.BasicTests.Unit.Arithmetic;

[Trait("Category", "Unit")]
[Trait("Component", "Arithmetic")]
public class AdditionTests
{
    [Fact]
    public void Add_PositiveNumbers_ReturnsSum()
    {
        var result = 5 + 3;
        Assert.Equal(8, result);
    }

    [Fact]
    public void Add_NegativeNumbers_ReturnsSum()
    {
        var result = -5 + (-3);
        Assert.Equal(-5, result);
    }

    [Fact]
    public void Add_MixedNumbers_ReturnsSum()
    {
        var result = -5 + 10;
        Assert.Equal(5, result);
    }

    [Fact]
    public void Add_ZeroToNumber_ReturnsSameNumber()
    {
        var result = 42 + 0;
        Assert.Equal(42, result);
    }

    [Fact]
    public void Add_ZeroToZero_ReturnsZero()
    {
        var result = 0 + 0;
        Assert.Equal(0, result);
    }

    [Fact]
    public void Add_LargeNumbers_ReturnsSum()
    {
        var result = 1000000 + 2000000;
        Assert.Equal(3000000, result);
    }

    [Fact]
    public void Add_SmallDecimals_ReturnsSum()
    {
        var result = 0.1 + 0.2;
        Assert.Equal(0.3, result, 10);
    }

    [Fact]
    public void Add_MaxIntValue_DoesNotOverflow()
    {
        long result = (long)int.MaxValue + 1;
        Assert.Equal(2147483648L, result);
    }

    [Fact]
    public void Add_CommutativeProperty_Works()
    {
        var result1 = 7 + 13;
        var result2 = 13 + 7;
        Assert.Equal(result1, result2);
    }

    [Fact]
    public void Add_AssociativeProperty_Works()
    {
        var result1 = (2 + 3) + 4;
        var result2 = 2 + (3 + 4);
        Assert.Equal(result1, result2);
    }
}
