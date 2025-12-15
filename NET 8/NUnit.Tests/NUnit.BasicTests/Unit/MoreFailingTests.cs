using NUnit.Framework;

namespace NUnit.BasicTests.Unit;

[TestFixture]
[Category("Unit")]
public class MoreFailingTests
{
    [Test]
    public void Test_SimpleFail_ShouldFail()
    {
        Assert.That(false, Is.True, "Simple test that should fail");
    }

    [Test]
    public void Test_NullCheck_ShouldFail()
    {
        string text = null;
        Assert.That(text, Is.Not.Null);
    }

    [TestCase(5, 10)]
    [TestCase(3, 7)]
    [TestCase(100, 200)]
    public void TestCase_WrongExpectation(int a, int b)
    {
        var result = a + b;
        Assert.That(result, Is.EqualTo(0)); // Wrong expectation
    }

    [TestCase("hello", "HELLO")]
    [TestCase("world", "WORLD")]
    [TestCase("test", "TEST")]
    public void TestCase_StringComparison_WrongCase(string input, string expected)
    {
        Assert.That(input, Is.EqualTo(expected)); // Wrong - not converted to upper
    }

    [TestCase(10, 5, 2)]
    [TestCase(100, 10, 5)]
    [TestCase(50, 25, 1)]
    public void TestCase_DivisionWrong_InvalidResult(int a, int b, int expected)
    {
        var result = a / b;
        Assert.That(result, Is.EqualTo(expected)); // Wrong expected values
    }

    [Test]
    public void Test_CollectionEmpty_ShouldFail()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        Assert.That(list, Is.Empty);
    }

    [Test]
    public void Test_RangeCheck_ShouldFail()
    {
        var value = 150;
        Assert.That(value, Is.InRange(1, 100));
    }

    [TestCase(2, true)]
    [TestCase(4, true)]
    [TestCase(6, true)]
    [TestCase(8, true)]
    public void TestCase_EvenNumbers_WrongLogic(int number, bool expected)
    {
        var isOdd = number % 2 != 0;
        Assert.That(isOdd, Is.EqualTo(expected)); // Checking odd but expecting even result
    }

    [Test]
    public void Test_TypeCheck_ShouldFail()
    {
        object obj = "string";
        Assert.That(obj, Is.InstanceOf<int>());
    }

    [TestCase("test.txt", ".pdf")]
    [TestCase("document.docx", ".txt")]
    [TestCase("image.png", ".jpg")]
    public void TestCase_FileExtension_WrongExtension(string filename, string expectedExt)
    {
        var ext = System.IO.Path.GetExtension(filename);
        Assert.That(ext, Is.EqualTo(expectedExt));
    }
}
