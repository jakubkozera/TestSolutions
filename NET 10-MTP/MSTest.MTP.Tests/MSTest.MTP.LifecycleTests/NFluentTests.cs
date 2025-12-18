using NFluent;

namespace MSTest.MTP.LifecycleTests;

[TestClass]
public class NFluentTests
{
    private static List<string> _items = new();
    
    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        _items.Add("Item1");
        _items.Add("Item2");
    }
    
    [TestMethod]
    public void PassingTest_WithLifecycle_NFluent()
    {
        Check.That(_items).HasSize(2);
        Check.That(_items).Contains("Item1");
    }
    
    [TestMethod]
    public void FailingTest_WithLifecycle_NFluent()
    {
        Check.That(_items).HasSize(10); // Will fail
    }
    
    [TestMethod]
    [Ignore("Skipped NFluent test")]
    public void SkippedTest_NFluent()
    {
        Check.That(_items).IsEmpty();
    }
}
