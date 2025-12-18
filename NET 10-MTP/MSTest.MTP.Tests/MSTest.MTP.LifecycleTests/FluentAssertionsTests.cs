using FluentAssertions;

namespace MSTest.MTP.LifecycleTests;

[TestClass]
public class FluentAssertionsTests
{
    private static int _classInitCount = 0;
    private int _testInitCount = 0;
    
    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        _classInitCount++;
    }
    
    [TestInitialize]
    public void TestInit()
    {
        _testInitCount++;
    }
    
    [TestMethod]
    public void PassingTest_WithLifecycle_FluentAssertions()
    {
        _classInitCount.Should().BeGreaterThan(0);
        _testInitCount.Should().BeGreaterThan(0);
    }
    
    [TestMethod]
    public void FailingTest_WithLifecycle_FluentAssertions()
    {
        _testInitCount.Should().Be(999, "This should fail");
    }
    
    [TestMethod]
    [Ignore("Skipped lifecycle test")]
    public void SkippedTest_FluentAssertions()
    {
        false.Should().BeTrue();
    }
}
