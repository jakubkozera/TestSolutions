using Shouldly;

namespace MSTest.MTP.LifecycleTests;

[TestClass]
public class ShouldlyTests
{
    private static string _classData = "";
    
    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        _classData = "Initialized";
    }
    
    [TestMethod]
    public void PassingTest_WithLifecycle_Shouldly()
    {
        _classData.ShouldBe("Initialized");
        _classData.ShouldNotBeEmpty();
    }
    
    [TestMethod]
    public void FailingTest_WithLifecycle_Shouldly()
    {
        _classData.ShouldBe("WrongValue", "This should fail");
    }
    
    [TestMethod]
    [Ignore("Skipped test")]
    public void SkippedTest_Shouldly()
    {
        _classData.ShouldBeNull();
    }
}
