using Xunit;

namespace XUnit.BasicTests.Unit;

[Trait("Category", "Failing")]
public class FailingTests
{
    [Fact]
    public void SimpleAssertion_ShouldFail()
    {
        Assert.Equal(5, 4);
    }

    [Fact]
    public void StringComparison_ShouldFail()
    {
        Assert.Equal("Expected", "Actual");
    }

    [Fact]
    public void BooleanAssertion_ShouldFail()
    {
        Assert.True(false, "This assertion should fail");
    }

    [Fact]
    public void NullAssertion_ShouldFail()
    {
        object obj = null;
        Assert.NotNull(obj);
    }

    [Fact]
    public void CollectionAssertion_ShouldFail()
    {
        var list = new List<int> { 1, 2, 3 };
        Assert.Contains(5, list);
    }

    [Fact]
    public void ExceptionNotThrown_ShouldFail()
    {
        Assert.Throws<InvalidOperationException>(() => 
        {
            // No exception thrown
            var x = 1 + 1;
        });
    }

    [Fact]
    public void MultipleAssertions_ShouldFail()
    {
        var result = 10;
        Assert.True(result > 5, "First assertion passes");
        Assert.Equal(20, result); // This fails
    }

    [Fact]
    public void DetailedErrorMessage_ShouldFail()
    {
        var expected = "This is the expected long string with many details about what should happen";
        var actual = "This is a different string that doesn't match";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NumericComparison_ShouldFail()
    {
        var calculated = 99.99;
        Assert.Equal(100.0, calculated, 2);
    }

    [Fact]
    public void TypeAssertion_ShouldFail()
    {
        object obj = "string value";
        Assert.IsType<int>(obj);
    }

    [Fact]
    public void RangeAssertion_ShouldFail()
    {
        var value = 150;
        Assert.InRange(value, 1, 100);
    }

    [Fact]
    public void EmptyCollection_ShouldFail()
    {
        var list = new List<int> { 1, 2, 3 };
        Assert.Empty(list);
    }

    [Fact]
    public void SingleElement_ShouldFail()
    {
        var list = new List<int> { 1, 2, 3 };
        Assert.Single(list);
    }

    [Fact]
    public void StartsWith_ShouldFail()
    {
        var text = "Hello World";
        Assert.StartsWith("Goodbye", text);
    }

    [Fact]
    public void EndsWith_ShouldFail()
    {
        var text = "Hello World";
        Assert.EndsWith("Universe", text);
    }

    [Fact]
    public void CustomException_ShouldFail()
    {
        try
        {
            throw new InvalidOperationException("Wrong exception type");
        }
        catch (ArgumentNullException)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void DateComparison_ShouldFail()
    {
        var date1 = new DateTime(2025, 1, 1);
        var date2 = new DateTime(2025, 12, 31);
        Assert.Equal(date1, date2);
    }

    [Fact]
    public void MultilineString_ShouldFail()
    {
        var expected = "Line 1\nLine 2\nLine 3";
        var actual = "Line 1\nLine X\nLine 3";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoubleEquality_ShouldFail()
    {
        var result = 0.1 + 0.2;
        Assert.Equal(0.3, result); // Floating point precision issue
    }

    [Fact]
    public void GreaterThan_ShouldFail()
    {
        var value = 5;
        Assert.True(value > 10, $"Expected {value} to be greater than 10");
    }
}
