using NUnit.Framework;

namespace NUnit.BasicTests.Unit;

[TestFixture]
[Category("Unit")]
public class SkippedTests
{
    [Test]
    [Ignore("Not implemented yet")]
    public void Skipped_NotImplemented_Test1()
    {
        Assert.Pass();
    }

    [Test]
    [Ignore("Waiting for bug fix")]
    public void Skipped_BugFix_Test2()
    {
        Assert.Pass();
    }

    [Test]
    [Ignore("Requires external service")]
    public void Skipped_ExternalDependency_Test3()
    {
        Assert.Pass();
    }

    [Test]
    [Ignore("Performance issue")]
    public void Skipped_Performance_Test4()
    {
        Assert.Pass();
    }

    [Test]
    [Ignore("Flaky test")]
    public void Skipped_Flaky_Test5()
    {
        Assert.Pass();
    }

    [Test]
    [Ignore("Under development")]
    public void Skipped_Development_Test6()
    {
        Assert.Pass();
    }

    [Test]
    [Ignore("Deprecated functionality")]
    public void Skipped_Deprecated_Test7()
    {
        Assert.Pass();
    }

    [Test]
    [Ignore("Requires license")]
    public void Skipped_License_Test8()
    {
        Assert.Pass();
    }

    [Test]
    [Ignore("Platform specific")]
    public void Skipped_PlatformSpecific_Test9()
    {
        Assert.Pass();
    }

    [Test]
    [Ignore("Long running test")]
    public void Skipped_LongRunning_Test10()
    {
        Assert.Pass();
    }
}
