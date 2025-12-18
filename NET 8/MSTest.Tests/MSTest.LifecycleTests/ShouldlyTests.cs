using Shouldly;

namespace MSTest.LifecycleTests;

[TestClass]
public class ShouldlyTests
{
    [TestMethod]
    public void PassingTest_WithShouldly()
    {
        var text = "Testing";
        text.ShouldContain("est");
        text.Length.ShouldBe(7);
    }
    
    [TestMethod]
    public void FailingTest_WithShouldly()
    {
        var list = new List<int> { 1, 2 };
        list.Count.ShouldBe(100, "This should fail");
    }
    
    [TestMethod]
    [Ignore("Intentionally skipped")]
    public void SkippedTest_WithShouldly()
    {
        "NotEmpty".ShouldBeEmpty();
    }
}
