using NFluent;
using NUnit.Framework;

namespace NUnit.FixtureTests;

[TestFixture]
public class NFluentTests
{
    [Test]
    public void PassingTest_WithNFluent()
    {
        var result = 5 * 5;
        Check.That(result).IsEqualTo(25);
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
        Check.That(0).IsStrictlyGreaterThan(100);
    }
}
