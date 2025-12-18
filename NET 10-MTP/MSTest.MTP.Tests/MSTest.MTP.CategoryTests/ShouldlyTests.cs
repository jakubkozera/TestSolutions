using Shouldly;

namespace MSTest.MTP.CategoryTests;

[TestClass]
public class ShouldlyTests
{
    [TestMethod]
    [TestCategory("Unit")]
    public void PassingTest_WithShouldly()
    {
        var value = 20;
        value.ShouldBe(20);
        value.ShouldBePositive();
    }
    
    [TestMethod]
    [TestCategory("Unit")]
    public void FailingTest_WithShouldly()
    {
        var list = new List<string> { "a", "b" };
        list.ShouldContain("z", "This should fail");
    }
    
    [TestMethod]
    [TestCategory("Integration")]
    [Ignore("Intentionally skipped")]
    public void SkippedTest_WithShouldly()
    {
        "test".ShouldBeEmpty();
    }
}
