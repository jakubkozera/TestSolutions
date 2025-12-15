using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.BasicTests.Unit;

[TestClass]
[TestCategory("Unit")]
public class MoreFailingTests
{
    [TestMethod]
    public void TestMethod_SimpleFail_ShouldFail()
    {
        Assert.IsTrue(false, "Simple test that should fail");
    }

    [TestMethod]
    public void TestMethod_NullCheck_ShouldFail()
    {
        string text = null;
        Assert.IsNotNull(text);
    }

    [DataTestMethod]
    [DataRow(5, 10)]
    [DataRow(3, 7)]
    [DataRow(100, 200)]
    public void DataRow_WrongExpectation(int a, int b)
    {
        var result = a + b;
        Assert.AreEqual(0, result); // Wrong expectation
    }

    [DataTestMethod]
    [DataRow("hello", "HELLO")]
    [DataRow("world", "WORLD")]
    [DataRow("test", "TEST")]
    public void DataRow_StringComparison_WrongCase(string input, string expected)
    {
        Assert.AreEqual(expected, input); // Wrong - not converted to upper
    }

    [DataTestMethod]
    [DataRow(10, 5, 2)]
    [DataRow(100, 10, 5)]
    [DataRow(50, 25, 1)]
    public void DataRow_DivisionWrong_InvalidResult(int a, int b, int expected)
    {
        var result = a / b;
        Assert.AreEqual(expected, result); // Wrong expected values
    }

    [TestMethod]
    public void TestMethod_CollectionEmpty_ShouldFail()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void TestMethod_RangeCheck_ShouldFail()
    {
        var value = 150;
        Assert.IsTrue(value >= 1 && value <= 100);
    }

    [DataTestMethod]
    [DataRow(2, true)]
    [DataRow(4, true)]
    [DataRow(6, true)]
    [DataRow(8, true)]
    public void DataRow_EvenNumbers_WrongLogic(int number, bool expected)
    {
        var isOdd = number % 2 != 0;
        Assert.AreEqual(expected, isOdd); // Checking odd but expecting even result
    }

    [TestMethod]
    public void TestMethod_TypeCheck_ShouldFail()
    {
        object obj = "string";
        Assert.IsInstanceOfType(obj, typeof(int));
    }

    [DataTestMethod]
    [DataRow("test.txt", ".pdf")]
    [DataRow("document.docx", ".txt")]
    [DataRow("image.png", ".jpg")]
    public void DataRow_FileExtension_WrongExtension(string filename, string expectedExt)
    {
        var ext = System.IO.Path.GetExtension(filename);
        Assert.AreEqual(expectedExt, ext);
    }
}
