using Xunit;

namespace XUnit.BasicTests.Unit;

public class MoreFailingTests
{
    [Fact]
    public void Fact_SimpleFail_ShouldFail()
    {
        Assert.True(false, "Simple fact that should fail");
    }

    [Fact]
    public void Fact_NullCheck_ShouldFail()
    {
        string text = null;
        Assert.NotNull(text);
    }

    [Theory]
    [InlineData(5, 10)]
    [InlineData(3, 7)]
    [InlineData(100, 200)]
    public void Theory_InlineData_WrongExpectation(int a, int b)
    {
        var result = a + b;
        Assert.Equal(0, result); // Wrong expectation
    }

    [Theory]
    [InlineData("hello", "HELLO")]
    [InlineData("world", "WORLD")]
    [InlineData("test", "TEST")]
    public void Theory_StringComparison_WrongCase(string input, string expected)
    {
        Assert.Equal(expected, input); // Wrong - not converted to upper
    }

    [Theory]
    [InlineData(10, 5, 2)]
    [InlineData(100, 10, 5)]
    [InlineData(50, 25, 1)]
    public void Theory_DivisionWrong_InvalidResult(int a, int b, int expected)
    {
        var result = a / b;
        Assert.Equal(expected, result); // Wrong expected values
    }

    [Fact]
    public void Fact_CollectionEmpty_ShouldFail()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        Assert.Empty(list);
    }

    [Fact]
    public void Fact_RangeCheck_ShouldFail()
    {
        var value = 150;
        Assert.InRange(value, 1, 100);
    }

    [Theory]
    [InlineData(2, true)]
    [InlineData(4, true)]
    [InlineData(6, true)]
    [InlineData(8, true)]
    public void Theory_EvenNumbers_WrongLogic(int number, bool expected)
    {
        var isOdd = number % 2 != 0;
        Assert.Equal(expected, isOdd); // Checking odd but expecting even result
    }

    [Fact]
    public void Fact_TypeCheck_ShouldFail()
    {
        object obj = "string";
        Assert.IsType<int>(obj);
    }

    [Theory]
    [InlineData("test.txt", ".pdf")]
    [InlineData("document.docx", ".txt")]
    [InlineData("image.png", ".jpg")]
    public void Theory_FileExtension_WrongExtension(string filename, string expectedExt)
    {
        var ext = System.IO.Path.GetExtension(filename);
        Assert.Equal(expectedExt, ext);
    }
}
