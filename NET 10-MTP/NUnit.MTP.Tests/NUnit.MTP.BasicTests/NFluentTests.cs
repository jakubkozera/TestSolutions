using NFluent;
using NUnit.Framework;

namespace NUnit.MTP.BasicTests;

[TestFixture]
public class NFluentTests
{
    [Test]
    public void PassingTest_WithNFluent()
    {
        var result = 8 * 8;
        Check.That(result).IsEqualTo(64);
        Check.That("NFluent").Contains("Fluent");
    }
    
    [Test]
    public void FailingTest_WithNFluent()
    {
        var array = new[] { 1, 2, 3 };
        Check.That(array).HasSize(10); // Will fail
    }
    
    [Test]
    [Ignore("Skipped NFluent test")]
    public void SkippedTest_WithNFluent()
    {
        Check.That(100).IsEqualTo(0);
    }
    
    [Test]
    public void PassingTest_WithStrings()
    {
        var text = "Testing";
        Check.That(text).Not.IsEmpty();
        Check.That(text.Length).IsStrictlyGreaterThan(5);
    }
}
