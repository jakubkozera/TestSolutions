using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.BasicTests.Unit;

[TestClass]
[TestCategory("Unit")]
public class SkippedTests
{
    [TestMethod]
    [Ignore("Not implemented yet")]
    public void Skipped_NotImplemented_Test1()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    [Ignore("Waiting for bug fix")]
    public void Skipped_BugFix_Test2()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    [Ignore("Requires external service")]
    public void Skipped_ExternalDependency_Test3()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    [Ignore("Performance issue")]
    public void Skipped_Performance_Test4()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    [Ignore("Flaky test")]
    public void Skipped_Flaky_Test5()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    [Ignore("Under development")]
    public void Skipped_Development_Test6()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    [Ignore("Deprecated functionality")]
    public void Skipped_Deprecated_Test7()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    [Ignore("Requires license")]
    public void Skipped_License_Test8()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    [Ignore("Platform specific")]
    public void Skipped_PlatformSpecific_Test9()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    [Ignore("Long running test")]
    public void Skipped_LongRunning_Test10()
    {
        Assert.IsTrue(true);
    }
}
