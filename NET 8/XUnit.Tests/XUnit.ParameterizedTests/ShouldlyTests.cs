using Shouldly;
using Xunit;

namespace XUnit.ParameterizedTests;

public class ShouldlyTests
{
    [Fact]
    public void PassingTest_WithShouldly()
    {
        var text = "Shouldly Library";
        text.ShouldContain("Library");
        text.Length.ShouldBe(16);
    }
    
    [Fact]
    public void FailingTest_WithShouldly()
    {
        var number = 10;
        number.ShouldBe(1000, "This should fail");
    }
    
    [Fact(Skip = "Intentionally skipped")]
    public void SkippedTest_WithShouldly()
    {
        "NotEmpty".ShouldBeEmpty();
    }
    
    [Fact]
    public void PassingTest_WithNullCheck()
    {
        string nullValue = null;
        nullValue.ShouldBeNull();
    }
}
