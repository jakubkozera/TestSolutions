using NFluent;

namespace MSTest.MTP.BasicTests;

[TestClass]
public class NFluentTests
{
    [TestMethod]
    public void PassingTest_WithNFluent()
    {
        // Arrange
        var result = 7 + 3;
        
        // Act & Assert
        Check.That(result).IsEqualTo(10);
        Check.That("NFluent").StartsWith("NF");
        Check.That(new[] { 1, 2, 3 }).Contains(1, 2, 3);
    }
    
    [TestMethod]
    public void FailingTest_WithNFluent()
    {
        // Arrange
        var value = 123;
        
        // Act & Assert
        Check.That(value).IsEqualTo(456); // This will fail
    }
    
    [TestMethod]
    [Ignore("This test demonstrates the Ignore attribute")]
    public void SkippedTest_WithNFluent()
    {
        // This test will be skipped
        Check.That(true).IsFalse();
    }
    
    [TestMethod]
    public void PassingTest_WithStringChecks()
    {
        // Arrange
        var text = "Testing with NFluent";
        
        // Act & Assert
        Check.That(text).Contains("NFluent");
        Check.That(text).Not.IsEmpty();
        Check.That(text.Length).IsStrictlyGreaterThan(5);
    }
    
    [TestMethod]
    public void FailingTest_WithCollections()
    {
        // Arrange
        var items = new List<int> { 1, 2, 3 };
        
        // Act & Assert
        Check.That(items).HasSize(5); // This will fail
    }
}
