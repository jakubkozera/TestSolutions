using NFluent;

namespace MSTest.DataDrivenTests;

[TestClass]
public class NFluentTests
{
    [TestMethod]
    public void PassingTest_WithNFluent()
    {
        var number = 50;
        Check.That(number).IsStrictlyGreaterThan(40);
        Check.That("NFluent").Contains("Fluent");
    }
    
    [TestMethod]
    public void FailingTest_WithNFluent()
    {
        var items = new[] { "a", "b" };
        Check.That(items).HasSize(10); // Will fail
    }
    
    [TestMethod]
    [Ignore("Skipped NFluent test")]
    public void SkippedTest_WithNFluent()
    {
        Check.That(1).IsEqualTo(2);
    }
}
