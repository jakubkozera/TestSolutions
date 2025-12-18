using Shouldly;

namespace MSTest.MTP.BasicTests;

[TestClass]
public class ShouldlyTests
{
    [TestMethod]
    public void PassingTest_WithShouldly()
    {
        // Arrange
        var actual = 10 * 5;
        
        // Act & Assert
        actual.ShouldBe(50);
        "World".ShouldStartWith("W");
        new[] { "a", "b", "c" }.ShouldContain("b");
    }
    
    [TestMethod]
    public void FailingTest_WithShouldly()
    {
        // Arrange
        var text = "Hello World";
        
        // Act & Assert
        text.ShouldBe("Goodbye World", "This test is designed to fail");
    }
    
    [TestMethod]
    [Ignore("Intentionally skipped for demonstration purposes")]
    public void SkippedTest_WithShouldly()
    {
        // This test will be skipped
        1.ShouldBe(2);
    }
    
    [TestMethod]
    public void PassingTest_WithNullChecks()
    {
        // Arrange
        string? nullValue = null;
        string nonNullValue = "test";
        
        // Act & Assert
        nullValue.ShouldBeNull();
        nonNullValue.ShouldNotBeNull();
        nonNullValue.ShouldNotBeEmpty();
    }
    
    [TestMethod]
    public void FailingTest_WithNumericComparison()
    {
        // Arrange
        var value = 42;
        
        // Act & Assert
        value.ShouldBeGreaterThan(100, "This should fail");
    }
}
