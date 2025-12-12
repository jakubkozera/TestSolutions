using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.CategoryTests.UnitTests;

[TestClass]
[TestCategory("Unit")]
[TestCategory("Fast")]
public class QuickTests
{
    [TestMethod]
    public void Quick_Test_1() => Assert.IsTrue(true);

    [TestMethod]
    public void Quick_Test_2() => Assert.AreEqual(2, 1 + 1);

    [TestMethod]
    public void Quick_Test_3() => Assert.AreEqual("test", "test");

    [TestMethod]
    public void Quick_Test_4() => Assert.AreEqual(3, new[] { 1, 2, 3 }.Length);

    [TestMethod]
    public void Quick_Test_5() => Assert.IsTrue(10 > 5);

    [TestMethod]
    public void Quick_Test_6() => Assert.IsTrue("hello".StartsWith("hel"));

    [TestMethod]
    public void Quick_Test_7() => Assert.IsTrue("world".EndsWith("rld"));

    [TestMethod]
    public void Quick_Test_8() => CollectionAssert.Contains(new List<int> { 1, 2, 3 }, 2);

    [TestMethod]
    public void Quick_Test_9() => Assert.AreEqual(100.0, 100.0, 0.01);

    [TestMethod]
    public void Quick_Test_10() => Assert.IsNotNull(new object());

    [TestMethod]
    [TestCategory("Smoke")]
    public void Smoke_Test_1() => Assert.IsTrue(DateTime.Now < DateTime.Now.AddDays(1));

    [TestMethod]
    [TestCategory("Smoke")]
    public void Smoke_Test_2() => Assert.IsNotNull(Path.GetTempPath());

    [TestMethod]
    [TestCategory("Smoke")]
    public void Smoke_Test_3() => Assert.IsTrue(Path.GetTempPath().Length > 0);

    [TestMethod]
    [TestCategory("Regression")]
    public void Regression_Test_1() => Assert.IsTrue("fixed_bug".Contains("bug"));

    [TestMethod]
    [TestCategory("Regression")]
    public void Regression_Test_2() => Assert.AreEqual(25, 5 * 5);

    [TestMethod]
    [TestCategory("Integration")]
    public void Integration_Test_1() => Assert.IsNotNull(Environment.GetEnvironmentVariables());

    [TestMethod]
    [TestCategory("Integration")]
    public void Integration_Test_2() => Assert.IsTrue(Environment.ProcessorCount > 0);

    [TestMethod]
    [TestCategory("E2E")]
    public async Task E2E_Test_1()
    {
        await Task.Delay(500);
        Assert.IsTrue(true);
    }

    [TestMethod]
    [TestCategory("E2E")]
    public async Task E2E_Test_2()
    {
        await Task.Delay(1000);
        Assert.IsTrue(true);
    }
}
