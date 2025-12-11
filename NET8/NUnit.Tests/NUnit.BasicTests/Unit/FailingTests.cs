using NUnit.Framework;

namespace NUnit.BasicTests.Unit;

[TestFixture]
[Category("Unit")]
public class FailingTests
{
    [Test]
    public void Failing_AssertTrue_False()
    {
        Assert.That(false, Is.True, "This test intentionally fails");
    }

    [Test]
    public void Failing_AssertEqual_Different()
    {
        Assert.That(5, Is.EqualTo(10), "Expected 10 but got 5");
    }

    [Test]
    public void Failing_AssertNotNull_Null()
    {
        string nullString = null;
        Assert.That(nullString, Is.Not.Null, "String should not be null");
    }

    [Test]
    public void Failing_AssertEmpty_NotEmpty()
    {
        var list = new List<int> { 1, 2, 3 };
        Assert.That(list, Is.Empty, "List should be empty");
    }

    [Test]
    public void Failing_AssertGreaterThan_LessThan()
    {
        Assert.That(5, Is.GreaterThan(10), "5 should be greater than 10");
    }

    [Test]
    public void Failing_AssertContains_DoesNotContain()
    {
        var text = "Hello World";
        Assert.That(text, Does.Contain("xyz"), "Should contain xyz");
    }

    [Test]
    public void Failing_ThrowsException_DoesNotThrow()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var x = 5 + 5;
        }, "Should throw ArgumentNullException");
    }

    [Test]
    public void Failing_AssertSame_Different()
    {
        var obj1 = new object();
        var obj2 = new object();
        Assert.That(obj1, Is.SameAs(obj2), "Should be same reference");
    }

    [Test]
    public void Failing_AssertInRange_OutOfRange()
    {
        Assert.That(100, Is.InRange(1, 50), "100 should be in range 1-50");
    }

    [Test]
    public void Failing_AssertInstanceOf_WrongType()
    {
        var obj = "string";
        Assert.That(obj, Is.InstanceOf<int>(), "Should be int");
    }

    [Test]
    public void Failing_AssertStartsWith_DoesNotStart()
    {
        var text = "Hello";
        Assert.That(text, Does.StartWith("World"), "Should start with World");
    }

    [Test]
    public void Failing_AssertEndsWith_DoesNotEnd()
    {
        var text = "Hello";
        Assert.That(text, Does.EndWith("World"), "Should end with World");
    }

    [Test]
    public void Failing_CollectionCount_Wrong()
    {
        var list = new List<int> { 1, 2, 3 };
        Assert.That(list, Has.Count.EqualTo(5), "Should have 5 items");
    }

    [Test]
    public void Failing_DictionaryContainsKey_DoesNot()
    {
        var dict = new Dictionary<string, int> { ["a"] = 1 };
        Assert.That(dict, Does.ContainKey("z"), "Should contain key z");
    }

    [Test]
    public void Failing_IsPositive_Negative()
    {
        Assert.That(-5, Is.Positive, "-5 should be positive");
    }

    [Test]
    public void Failing_IsNegative_Positive()
    {
        Assert.That(5, Is.Negative, "5 should be negative");
    }

    [Test]
    public void Failing_StringMatch_DoesNotMatch()
    {
        Assert.That("test123", Does.Match("^[a-z]+$"), "Should match pattern");
    }

    [Test]
    public void Failing_CollectionUnique_HasDuplicates()
    {
        var list = new List<int> { 1, 2, 2, 3 };
        Assert.That(list, Is.Unique, "Should not have duplicates");
    }

    [Test]
    public void Failing_IsOrdered_NotOrdered()
    {
        var list = new List<int> { 3, 1, 2 };
        Assert.That(list, Is.Ordered, "Should be ordered");
    }

    [Test]
    public void Failing_Calculation_Wrong()
    {
        var result = 2 + 2;
        Assert.That(result, Is.EqualTo(5), "2+2 should equal 5");
    }
}
