using Shouldly;

namespace MSTest.MTP.DataDrivenTests;

[TestClass]
public class ShouldlyTests
{
    [DataTestMethod]
    [DataRow("Hello", 5)]
    [DataRow("Test", 4)]
    public void PassingTest_DataDriven_Shouldly(string text, int expectedLength)
    {
        text.Length.ShouldBe(expectedLength);
    }
    
    [DataTestMethod]
    [DataRow("Fail", 100)]
    public void FailingTest_DataDriven_Shouldly(string text, int expectedLength)
    {
        text.Length.ShouldBe(expectedLength, "This should fail");
    }
    
    [TestMethod]
    [Ignore("Skipped test")]
    public void SkippedTest_Shouldly()
    {
        "".ShouldNotBeEmpty();
    }
}
