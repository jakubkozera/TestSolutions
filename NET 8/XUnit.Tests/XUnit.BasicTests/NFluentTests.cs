using NFluent;
using Xunit;

namespace XUnit.BasicTests;

public class NFluentTests
{
    [Fact]
    public void PassingTest_WithNFluent()
    {
        var result = 20 * 3;
        Check.That(result).IsEqualTo(60);
        Check.That("NFluent").Contains("Fluent");
    }
    
    [Fact]
    public void FailingTest_WithNFluent()
    {
        var array = new[] { 1, 2, 3 };
        Check.That(array).HasSize(100); // Will fail
    }
    
    [Fact(Skip = "Skipped NFluent test")]
    public void SkippedTest_WithNFluent()
    {
        Check.That(0).IsStrictlyGreaterThan(100);
    }
    
    [Fact]
    public void PassingTest_WithStringChecks()
    {
        var text = "Testing NFluent";
        Check.That(text).Not.IsEmpty();
        Check.That(text.Length).IsStrictlyGreaterThan(10);
    }
}
