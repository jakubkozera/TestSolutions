using FluentAssertions;

namespace MSTest.MTP.CategoryTests;

[TestClass]
public class FluentAssertionsTests
{
    [TestMethod]
    [TestCategory("Unit")]
    public void PassingTest_WithFluentAssertions()
    {
        var result = 15 - 5;
        result.Should().Be(10);
        "FluentAssertions".Should().Contain("Fluent");
    }
    
    [TestMethod]
    [TestCategory("Unit")]
    public void FailingTest_WithFluentAssertions()
    {
        var text = "Expected";
        text.Should().Be("Different", "This test should fail");
    }
    
    [TestMethod]
    [TestCategory("Integration")]
    [Ignore("Skipped test for demonstration")]
    public void SkippedTest_WithFluentAssertions()
    {
        false.Should().BeTrue();
    }
}
