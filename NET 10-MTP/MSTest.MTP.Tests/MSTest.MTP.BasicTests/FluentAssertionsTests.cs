using FluentAssertions;

namespace MSTest.MTP.BasicTests;

[TestClass]
public class FluentAssertionsTests
{
    [TestMethod]
    public void PassingTest_WithFluentAssertions()
    {
        // Arrange
        var actual = 2 + 2;
        
        // Act & Assert
        actual.Should().Be(4);
        "Hello".Should().StartWith("H");
        new[] { 1, 2, 3 }.Should().Contain(2);
    }
    
    [TestMethod]
    public void FailingTest_WithFluentAssertions()
    {
        // Arrange
        var actual = 2 + 2;
        
        // Act & Assert
        actual.Should().Be(5, "because this test is designed to fail");
    }
    
    [TestMethod]
    [Ignore("This test is intentionally skipped to demonstrate Ignore attribute")]
    public void SkippedTest_WithFluentAssertions()
    {
        // This test will be skipped
        true.Should().BeFalse();
    }
    
    [TestMethod]
    public void PassingTest_WithComplexAssertions()
    {
        // Arrange
        var person = new { Name = "John", Age = 30 };
        
        // Act & Assert
        person.Name.Should().NotBeNullOrEmpty();
        person.Age.Should().BeGreaterThan(18);
        person.Age.Should().BeInRange(25, 35);
    }
    
    [TestMethod]
    public void FailingTest_WithCollectionAssertions()
    {
        // Arrange
        var numbers = new[] { 1, 2, 3, 4, 5 };
        
        // Act & Assert
        numbers.Should().HaveCount(10, "because this test should fail");
    }
}
