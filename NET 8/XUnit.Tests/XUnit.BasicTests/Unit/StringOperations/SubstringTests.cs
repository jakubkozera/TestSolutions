using System.Threading.Tasks;
using Xunit;

namespace XUnit.BasicTests.Unit.StringOperations;

[Trait("Category", "Unit")]
[Trait("Component", "String")]
public class SubstringTests
{
    [Fact]
    public async Task Substring_FromStart_ReturnsCorrectPart()
    {
        await Task.Delay(50); // Medium duration
        var result = "Hello World".Substring(0, 5);
        Assert.Equal("Hello", result);
    }

    [Fact]
    public async Task Substring_FromMiddle_ReturnsCorrectPart()
    {
        await Task.Delay(50);
        var result = "Hello World".Substring(6, 5);
        Assert.Equal("World", result);
    }

    [Fact]
    public async Task Substring_ToEnd_ReturnsRemainder()
    {
        await Task.Delay(50);
        var result = "Hello World".Substring(6);
        Assert.Equal("World", result);
    }

    [Fact]
    public async Task Substring_EmptyResult_ReturnsEmpty()
    {
        await Task.Delay(50);
        var result = "Hello".Substring(5, 0);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task Substring_OutOfRange_ThrowsException()
    {
        await Task.Delay(50);
        Assert.Throws<ArgumentOutOfRangeException>(() => "Hello".Substring(10));
    }

    [Fact]
    public async Task Substring_NegativeIndex_ThrowsException()
    {
        await Task.Delay(50);
        Assert.Throws<ArgumentOutOfRangeException>(() => "Hello".Substring(-1));
    }

    [Fact]
    public async Task Substring_WholeString_ReturnsCopy()
    {
        await Task.Delay(50);
        var original = "Hello";
        var result = original.Substring(0);
        Assert.Equal(original, result);
    }

    [Fact]
    public async Task Substring_SingleCharacter_Works()
    {
        await Task.Delay(50);
        var result = "Hello".Substring(1, 1);
        Assert.Equal("e", result);
    }

    [Fact]
    public async Task Substring_WithSpaces_PreservesSpaces()
    {
        await Task.Delay(50);
        var result = "  Hello  ".Substring(2, 5);
        Assert.Equal("Hello", result);
    }

    [Fact]
    public async Task Substring_Unicode_WorksCorrectly()
    {
        await Task.Delay(50);
        var result = "Héllo Wörld".Substring(0, 5);
        Assert.Equal("Héllo", result);
    }

    [Fact]
    public async Task Substring_LargeString_PerformsWell()
    {
        await Task.Delay(100);
        var largeString = new string('A', 10000);
        var result = largeString.Substring(0, 10);
        Assert.Equal(new string('A', 10), result);
    }

    [Fact]
    public async Task Substring_ChainedOperations_Works()
    {
        await Task.Delay(50);
        var result = "Hello World Test".Substring(6).Substring(0, 5);
        Assert.Equal("World", result);
    }
}
