using FluentAssertions;
using NUnit.Framework;

namespace NUnit.MTP.CategoryTests;

[TestFixture]
public class FluentAssertionsTests
{
    [Test]
    public void PassingTest_WithFluentAssertions()
    {
        var result = 15 + 10;
        result.Should().Be(25);
        "Test".Should().HaveLength(4);
    }
    
    [Test]
    public void FailingTest_WithFluentAssertions()
    {
        var value = 50;
        value.Should().Be(999, "This should fail");
    }
    
    [Test]
    [Ignore("Skipped for demonstration")]
    public void SkippedTest_WithFluentAssertions()
    {
        false.Should().BeTrue();
    }
}
