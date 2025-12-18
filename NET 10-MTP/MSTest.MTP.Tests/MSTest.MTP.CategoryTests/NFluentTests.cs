using NFluent;

namespace MSTest.MTP.CategoryTests;

[TestClass]
public class NFluentTests
{
    [TestMethod]
    [TestCategory("Unit")]
    public void PassingTest_WithNFluent()
    {
        var number = 42;
        Check.That(number).IsStrictlyGreaterThan(40);
        Check.That(number).IsStrictlyLessThan(50);
    }
    
    [TestMethod]
    [TestCategory("Unit")]
    public void FailingTest_WithNFluent()
    {
        var array = new[] { 1, 2, 3 };
        Check.That(array).HasSize(10); // Should fail
    }
    
    [TestMethod]
    [TestCategory("Integration")]
    [Ignore("Skipped for testing purposes")]
    public void SkippedTest_WithNFluent()
    {
        Check.That("test").IsEmpty();
    }
}
