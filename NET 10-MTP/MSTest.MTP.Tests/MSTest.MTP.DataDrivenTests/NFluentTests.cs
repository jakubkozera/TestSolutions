using NFluent;

namespace MSTest.MTP.DataDrivenTests;

[TestClass]
public class NFluentTests
{
    [DataTestMethod]
    [DataRow(10, 20, 30)]
    [DataRow(5, 15, 20)]
    public void PassingTest_DataDriven_NFluent(int a, int b, int expected)
    {
        var sum = a + b;
        Check.That(sum).IsEqualTo(expected);
    }
    
    [DataTestMethod]
    [DataRow(1, 1, 100)]
    public void FailingTest_DataDriven_NFluent(int a, int b, int expected)
    {
        var sum = a + b;
        Check.That(sum).IsEqualTo(expected); // Will fail
    }
    
    [TestMethod]
    [Ignore("Skipped NFluent test")]
    public void SkippedTest_NFluent()
    {
        Check.That(0).IsStrictlyGreaterThan(100);
    }
}
