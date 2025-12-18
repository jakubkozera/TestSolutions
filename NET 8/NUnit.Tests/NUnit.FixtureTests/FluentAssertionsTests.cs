using FluentAssertions;
using NUnit.Framework;

namespace NUnit.FixtureTests;

[TestFixture]
public class FluentAssertionsTests
{
    [Test]
    public void PassingTest_WithFluentAssertions()
    {
        var result = 10 + 10;
        result.Should().Be(20);
        "NUnit".Should().StartWith("N");
    }
    
    [Test]
    public void FailingTest_WithFluentAssertions()
    {
        var value = 42;
        value.Should().Be(100, "This should fail");
    }
    
    [Test]
    [Ignore("Skipped for demonstration")]
    public void SkippedTest_WithFluentAssertions()
    {
        true.Should().BeFalse();
    }
}
