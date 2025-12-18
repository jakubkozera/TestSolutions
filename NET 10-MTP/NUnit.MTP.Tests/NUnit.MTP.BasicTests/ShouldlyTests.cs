using NUnit.Framework;
using Shouldly;

namespace NUnit.MTP.BasicTests;

[TestFixture]
public class ShouldlyTests
{
    [Test]
    public void PassingTest_WithShouldly()
    {
        var text = "Hello World";
        text.ShouldContain("World");
        text.Length.ShouldBe(11);
    }
    
    [Test]
    public void FailingTest_WithShouldly()
    {
        var number = 7;
        number.ShouldBe(20, "This should fail");
    }
    
    [Test]
    [Ignore("Intentionally skipped")]
    public void SkippedTest_WithShouldly()
    {
        "test".ShouldBeEmpty();
    }
    
    [Test]
    public void PassingTest_WithNullCheck()
    {
        string? nullString = null;
        nullString.ShouldBeNull();
    }
}
