using FluentAssertions;

namespace MSTest.LifecycleTests;

[TestClass]
public class FluentAssertionsTests
{
    [TestMethod]
    public void PassingTest_WithFluentAssertions()
    {
        var result = 2 + 2;
        result.Should().Be(4);
        "MSTest".Should().Contain("Test");
    }
    
    [TestMethod]
    public void FailingTest_WithFluentAssertions()
    {
        var value = 10;
        value.Should().Be(999, "This should fail");
    }
    
    [TestMethod]
    [Ignore("Skipped for demonstration")]
    public void SkippedTest_WithFluentAssertions()
    {
        false.Should().BeTrue();
    }
}
