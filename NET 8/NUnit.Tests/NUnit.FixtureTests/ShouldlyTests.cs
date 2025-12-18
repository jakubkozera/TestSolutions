using NUnit.Framework;
using Shouldly;

namespace NUnit.FixtureTests;

[TestFixture]
public class ShouldlyTests
{
    [Test]
    public void PassingTest_WithShouldly()
    {
        var text = "Hello";
        text.ShouldContain("ell");
        text.Length.ShouldBe(5);
    }
    
    [Test]
    public void FailingTest_WithShouldly()
    {
        var number = 7;
        number.ShouldBe(999, "This should fail");
    }
    
    [Test]
    [Ignore("Intentionally skipped")]
    public void SkippedTest_WithShouldly()
    {
        "test".ShouldBeEmpty();
    }
}
