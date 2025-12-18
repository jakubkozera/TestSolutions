using FluentAssertions;

namespace MSTest.MTP.DataDrivenTests;

[TestClass]
public class FluentAssertionsTests
{
    [DataTestMethod]
    [DataRow(2, 2, 4)]
    [DataRow(3, 3, 6)]
    [DataRow(5, 5, 10)]
    public void PassingTest_DataDriven_FluentAssertions(int a, int b, int expected)
    {
        var result = a + b;
        result.Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow(1, 1, 5)]
    public void FailingTest_DataDriven_FluentAssertions(int a, int b, int expected)
    {
        var result = a + b;
        result.Should().Be(expected, "This should fail");
    }
    
    [TestMethod]
    [Ignore("Skipped data-driven test")]
    public void SkippedTest_FluentAssertions()
    {
        100.Should().Be(0);
    }
}
