using Xunit;

namespace XUnit.BasicTests.Unit;

[Trait("Category", "Skipped")]
public class SkippedTests
{
    [Fact(Skip = "Test not yet implemented")]
    public void NotImplemented_Test1()
    {
        Assert.True(true);
    }

    [Fact(Skip = "Waiting for external dependency")]
    public void WaitingForDependency_Test()
    {
        Assert.True(true);
    }

    [Fact(Skip = "Known issue - Bug #12345")]
    public void KnownBug_Test()
    {
        Assert.True(true);
    }

    [Fact(Skip = "Requires database connection")]
    public void RequiresDatabase_Test()
    {
        Assert.True(true);
    }

    [Fact(Skip = "Flaky test - needs investigation")]
    public void FlakyTest_NeedsInvestigation()
    {
        Assert.True(true);
    }

    [Fact(Skip = "Only runs in production environment")]
    public void ProductionOnly_Test()
    {
        Assert.True(true);
    }

    [Fact(Skip = "Requires admin privileges")]
    public void RequiresAdmin_Test()
    {
        Assert.True(true);
    }

    [Fact(Skip = "Performance test - run manually")]
    public void ManualPerformance_Test()
    {
        Assert.True(true);
    }

    [Fact(Skip = "Deprecated functionality")]
    public void Deprecated_Test()
    {
        Assert.True(true);
    }

    [Fact(Skip = "Under development")]
    public void UnderDevelopment_Test()
    {
        Assert.True(true);
    }
}
