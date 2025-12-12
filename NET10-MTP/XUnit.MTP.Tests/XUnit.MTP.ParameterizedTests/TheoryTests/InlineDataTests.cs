using Xunit;

namespace XUnit.ParameterizedTests.TheoryTests;

[Trait("Category", "Unit")]
public class InlineDataTests
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-1, 1, 0)]
    [InlineData(100, 200, 300)]
    [InlineData(int.MaxValue, 0, int.MaxValue)]
    [InlineData(-5, -10, -15)]
    public void Add_Theory_WithInlineData(int a, int b, int expected)
    {
        var result = a + b;
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", "HELLO")]
    [InlineData("World", "WORLD")]
    [InlineData("TeSt", "TEST")]
    [InlineData("123", "123")]
    [InlineData("", "")]
    public void ToUpper_Theory(string input, string expected)
    {
        var result = input.ToUpper();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(2, true)]
    [InlineData(4, true)]
    [InlineData(100, true)]
    [InlineData(1, false)]
    [InlineData(3, false)]
    [InlineData(99, false)]
    public void IsEven_Theory(int number, bool expected)
    {
        var result = number % 2 == 0;
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 120)]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(3, 6)]
    [InlineData(4, 24)]
    public void Factorial_Theory(int n, int expected)
    {
        int Factorial(int x) => x <= 1 ? 1 : x * Factorial(x - 1);
        var result = Factorial(n);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("test@example.com", true)]
    [InlineData("invalid.email", false)]
    [InlineData("user@domain.co.uk", true)]
    [InlineData("@example.com", false)]
    [InlineData("test@", false)]
    public void ValidateEmail_Theory(string email, bool expected)
    {
        var isValid = email.Contains('@') && email.Contains('.') && email.IndexOf('@') > 0;
        Assert.Equal(expected, isValid);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(2, 3, 6)]
    [InlineData(5, 5, 25)]
    [InlineData(10, 0, 0)]
    [InlineData(-2, 3, -6)]
    public void Multiply_Theory(int a, int b, int expected)
    {
        var result = a * b;
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", 5)]
    [InlineData("", 0)]
    [InlineData("test", 4)]
    [InlineData("a", 1)]
    [InlineData("Hello World", 11)]
    public void StringLength_Theory(string input, int expected)
    {
        Assert.Equal(expected, input.Length);
    }

    [Theory]
    [InlineData(10, 3, 3)]
    [InlineData(20, 4, 5)]
    [InlineData(15, 3, 5)]
    [InlineData(100, 10, 10)]
    [InlineData(7, 2, 3)]
    public void Divide_Theory(int a, int b, int expected)
    {
        var result = a / b;
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello world", "world", true)]
    [InlineData("hello world", "test", false)]
    [InlineData("Test String", "String", true)]
    [InlineData("", "", true)]
    [InlineData("abc", "xyz", false)]
    public void StringContains_Theory(string text, string search, bool expected)
    {
        var result = text.Contains(search);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 6)]
    [InlineData(4, 24)]
    [InlineData(5, 120)]
    [InlineData(6, 720)]
    [InlineData(7, 5040)]
    public void LongParameterList_Theory_Factorial(int input, int expected)
    {
        int Factorial(int n) => n <= 1 ? 1 : n * Factorial(n - 1);
        Assert.Equal(expected, Factorial(input));
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 55)]
    [InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
    [InlineData(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10)]
    [InlineData(10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 550)]
    public void SumTenNumbers_Theory(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int expected)
    {
        var result = a + b + c + d + e + f + g + h + i + j;
        Assert.Equal(expected, result);
    }
}
