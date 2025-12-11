using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.BasicTests.Unit;

[TestClass]
[TestCategory("Unit")]
public class FailingTests
{
    [TestMethod]
    public void Failing_AssertTrue_False()
    {
        Assert.IsTrue(false, "This test intentionally fails");
    }

    [TestMethod]
    public void Failing_AssertEqual_Different()
    {
        Assert.AreEqual(10, 5, "Expected 10 but got 5");
    }

    [TestMethod]
    public void Failing_AssertNotNull_Null()
    {
        string nullString = null;
        Assert.IsNotNull(nullString, "String should not be null");
    }

    [TestMethod]
    public void Failing_CollectionEmpty_NotEmpty()
    {
        var list = new List<int> { 1, 2, 3 };
        Assert.AreEqual(0, list.Count, "List should be empty");
    }

    [TestMethod]
    public void Failing_AssertGreaterThan_LessThan()
    {
        Assert.IsTrue(5 > 10, "5 should be greater than 10");
    }

    [TestMethod]
    public void Failing_AssertContains_DoesNotContain()
    {
        var text = "Hello World";
        StringAssert.Contains(text, "xyz", "Should contain xyz");
    }

    [TestMethod]
    public void Failing_ThrowsException_DoesNotThrow()
    {
        try
        {
            var x = 5 + 5;
            Assert.Fail("Expected ArgumentNullException but none was thrown");
        }
        catch (ArgumentNullException)
        {
            // Expected
        }
    }

    [TestMethod]
    public void Failing_AssertSame_Different()
    {
        var obj1 = new object();
        var obj2 = new object();
        Assert.AreSame(obj1, obj2, "Should be same reference");
    }

    [TestMethod]
    public void Failing_AssertInRange_OutOfRange()
    {
        Assert.IsTrue(100 >= 1 && 100 <= 50, "100 should be in range 1-50");
    }

    [TestMethod]
    public void Failing_AssertInstanceOf_WrongType()
    {
        var obj = "string";
        Assert.IsInstanceOfType(obj, typeof(int), "Should be int");
    }

    [TestMethod]
    public void Failing_AssertStartsWith_DoesNotStart()
    {
        var text = "Hello";
        StringAssert.StartsWith(text, "World", "Should start with World");
    }

    [TestMethod]
    public void Failing_AssertEndsWith_DoesNotEnd()
    {
        var text = "Hello";
        StringAssert.EndsWith(text, "World", "Should end with World");
    }

    [TestMethod]
    public void Failing_CollectionCount_Wrong()
    {
        var list = new List<int> { 1, 2, 3 };
        Assert.AreEqual(5, list.Count, "Should have 5 items");
    }

    [TestMethod]
    public void Failing_DictionaryContainsKey_DoesNot()
    {
        var dict = new Dictionary<string, int> { ["a"] = 1 };
        Assert.IsTrue(dict.ContainsKey("z"), "Should contain key z");
    }

    [TestMethod]
    public void Failing_IsPositive_Negative()
    {
        Assert.IsTrue(-5 > 0, "-5 should be positive");
    }

    [TestMethod]
    public void Failing_IsNegative_Positive()
    {
        Assert.IsTrue(5 < 0, "5 should be negative");
    }

    [TestMethod]
    public void Failing_StringMatch_DoesNotMatch()
    {
        StringAssert.Matches("test123", new System.Text.RegularExpressions.Regex("^[a-z]+$"), "Should match pattern");
    }

    [TestMethod]
    public void Failing_CollectionUnique_HasDuplicates()
    {
        var list = new List<int> { 1, 2, 2, 3 };
        var distinct = list.Distinct().Count();
        Assert.AreEqual(list.Count, distinct, "Should not have duplicates");
    }

    [TestMethod]
    public void Failing_IsOrdered_NotOrdered()
    {
        var list = new List<int> { 3, 1, 2 };
        var ordered = list.OrderBy(x => x).ToList();
        CollectionAssert.AreEqual(ordered, list, "Should be ordered");
    }

    [TestMethod]
    public void Failing_Calculation_Wrong()
    {
        var result = 2 + 2;
        Assert.AreEqual(5, result, "2+2 should equal 5");
    }
}
