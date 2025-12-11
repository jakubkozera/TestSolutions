using NUnit.Framework;

namespace NUnit.FixtureTests.Fixtures;

[TestFixture]
[Category("Unit")]
public class SetupTeardownTests
{
    private List<int> _testData;

    [SetUp]
    public void Setup()
    {
        _testData = new List<int> { 1, 2, 3, 4, 5 };
    }

    [TearDown]
    public void TearDown()
    {
        _testData?.Clear();
    }

    [Test]
    public void Test_WithSetup_1()
    {
        Assert.That(_testData, Has.Count.EqualTo(5));
    }

    [Test]
    public void Test_WithSetup_2()
    {
        Assert.That(_testData, Does.Contain(3));
    }

    [Test]
    public void Test_WithSetup_3()
    {
        _testData.Add(6);
        Assert.That(_testData, Has.Count.EqualTo(6));
    }

    [Test]
    public void Test_WithSetup_4()
    {
        Assert.That(_testData[0], Is.EqualTo(1));
    }

    [Test]
    public void Test_WithSetup_5()
    {
        Assert.That(_testData.Sum(), Is.EqualTo(15));
    }
}

[TestFixture]
[Category("Unit")]
public class OneTimeSetupTests
{
    private static Dictionary<string, int> _sharedData;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _sharedData = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3
        };
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _sharedData?.Clear();
    }

    [Test]
    public void SharedData_Test_1()
    {
        Assert.That(_sharedData, Has.Count.EqualTo(3));
    }

    [Test]
    public void SharedData_Test_2()
    {
        Assert.That(_sharedData["one"], Is.EqualTo(1));
    }

    [Test]
    public void SharedData_Test_3()
    {
        Assert.That(_sharedData.ContainsKey("two"), Is.True);
    }

    [Test]
    public void SharedData_Test_4()
    {
        Assert.That(_sharedData.Values, Does.Contain(3));
    }

    [Test]
    public void SharedData_Test_5()
    {
        Assert.That(_sharedData.Keys, Has.Count.EqualTo(3));
    }
}
