using FluentAssertions;
using Xunit;

namespace XUnit.MTP.ParameterizedTests;

public class FluentAssertionsTests
{
    [Fact]
    public void PassingTest_WithFluentAssertions()
    {
        var result = 100 / 2;
        result.Should().Be(50);
        "XUnit".Should().StartWith("X");
    }
    
    [Fact]
    public void FailingTest_WithFluentAssertions()
    {
        var value = 42;
        value.Should().Be(999, "This should fail");
    }
    
    [Fact(Skip = "Skipped for demonstration")]
    public void SkippedTest_WithFluentAssertions()
    {
        true.Should().BeFalse();
    }
    
    [Fact]
    public void PassingTest_WithCollections()
    {
        var numbers = new[] { 1, 2, 3, 4, 5 };
        numbers.Should().HaveCount(5);
        numbers.Should().Contain(3);
    }
}
