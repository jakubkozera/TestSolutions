using NFluent;
using NUnit.Framework;

namespace NUnit.MTP.CategoryTests;

[TestFixture]
public class NFluentTests
{
    [Test]
    public void PassingTest_WithNFluent()
    {
        var number = 100;
        Check.That(number).IsStrictlyGreaterThan(50);
        Check.That("NFluent").Contains("Fluent");
    }
    
    [Test]
    public void FailingTest_WithNFluent()
    {
        var items = new[] { "a", "b", "c" };
        Check.That(items).HasSize(10); // Will fail
    }
    
    [Test]
    [Ignore("Skipped NFluent test")]
    public void SkippedTest_WithNFluent()
    {
        Check.That(1).IsEqualTo(2);
    }
}
