using Xunit;

namespace XUnit.BasicTests.Unit.StringOperations;

[Trait("Category", "Unit")]
[Trait("Component", "String")]
public class ConcatenationTests
{
    [Fact]
    public void Concat_TwoStrings_ReturnsCombined()
    {
        var result = "Hello" + " " + "World";
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void Concat_EmptyStrings_ReturnsEmpty()
    {
        var result = string.Empty + string.Empty;
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Concat_WithNull_HandlesGracefully()
    {
        string? nullStr = null;
        var result = "Hello" + nullStr;
        Assert.Equal("Hello", result);
    }

    [Fact]
    public void Concat_MultipleStrings_WorksCorrectly()
    {
        var result = string.Concat("A", "B", "C", "D");
        Assert.Equal("ABCD", result);
    }

    [Fact]
    public void Concat_WithNumbers_ConvertsToString()
    {
        var result = "Value: " + 42;
        Assert.Equal("Value: 42", result);
    }

    [Fact]
    public void Concat_UsingStringFormat_Works()
    {
        var result = string.Format("{0} {1}", "Hello", "World");
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void Concat_UsingInterpolation_Works()
    {
        var name = "World";
        var result = $"Hello {name}";
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void Concat_UsingStringBuilder_Works()
    {
        var sb = new System.Text.StringBuilder();
        sb.Append("Hello");
        sb.Append(" ");
        sb.Append("World");
        Assert.Equal("Hello World", sb.ToString());
    }
}
