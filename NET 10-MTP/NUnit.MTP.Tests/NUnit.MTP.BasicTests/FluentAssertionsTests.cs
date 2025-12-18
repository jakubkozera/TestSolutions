using FluentAssertions;
using NUnit.Framework;

namespace NUnit.MTP.BasicTests;

[TestFixture]
public class FluentAssertionsTests
{
    [Test]
    public void PassingTest_WithFluentAssertions()
    {
        var result = 10 + 5;
        result.Should().Be(15);
        "NUnit".Should().StartWith("N");
    }
    
    [Test]
    public void FailingTest_WithFluentAssertions()
    {
        var value = 42;
        value.Should().Be(100, "This test should fail");
    }
    
    [Test]
    [Ignore("Skipped test for demonstration")]
    public void SkippedTest_WithFluentAssertions()
    {
        true.Should().BeFalse();
    }
    
    [Test]
    public void PassingTest_WithCollections()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        list.Should().HaveCount(5);
        list.Should().Contain(3);
    }
}
