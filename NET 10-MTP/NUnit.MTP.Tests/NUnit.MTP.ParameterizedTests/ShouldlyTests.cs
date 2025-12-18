using NUnit.Framework;
using Shouldly;

namespace NUnit.MTP.ParameterizedTests;

[TestFixture]
public class ShouldlyTests
{
    [Test]
    public void PassingTest_WithShouldly()
    {
        var text = "Shouldly";
        text.ShouldContain("Should");
        text.Length.ShouldBe(8);
    }
    
    [Test]
    public void FailingTest_WithShouldly()
    {
        var list = new List<int> { 1, 2, 3 };
        list.Count.ShouldBe(100, "This should fail");
    }
    
    [Test]
    [Ignore("Intentionally skipped")]
    public void SkippedTest_WithShouldly()
    {
        "NotEmpty".ShouldBeEmpty();
    }
}
