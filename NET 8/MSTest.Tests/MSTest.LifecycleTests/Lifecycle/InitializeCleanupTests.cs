using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.LifecycleTests.Lifecycle;

[TestClass]
[TestCategory("Unit")]
public class InitializeCleanupTests
{
    private List<int> _testData;

    [TestInitialize]
    public void Initialize()
    {
        _testData = new List<int> { 1, 2, 3, 4, 5 };
    }

    [TestCleanup]
    public void Cleanup()
    {
        _testData?.Clear();
    }

    [TestMethod]
    public void Test_WithInitialize_1()
    {
        Assert.AreEqual(5, _testData.Count);
    }

    [TestMethod]
    public void Test_WithInitialize_2()
    {
        CollectionAssert.Contains(_testData, 3);
    }

    [TestMethod]
    public void Test_WithInitialize_3()
    {
        _testData.Add(6);
        Assert.AreEqual(6, _testData.Count);
    }

    [TestMethod]
    public void Test_WithInitialize_4()
    {
        Assert.AreEqual(1, _testData[0]);
    }

    [TestMethod]
    public void Test_WithInitialize_5()
    {
        Assert.AreEqual(15, _testData.Sum());
    }
}

[TestClass]
[TestCategory("Unit")]
public class ClassInitializeCleanupTests
{
    private static Dictionary<string, int> _sharedData;

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        _sharedData = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3
        };
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        _sharedData?.Clear();
    }

    [TestMethod]
    public void SharedData_Test_1()
    {
        Assert.AreEqual(3, _sharedData.Count);
    }

    [TestMethod]
    public void SharedData_Test_2()
    {
        Assert.AreEqual(1, _sharedData["one"]);
    }

    [TestMethod]
    public void SharedData_Test_3()
    {
        Assert.IsTrue(_sharedData.ContainsKey("two"));
    }

    [TestMethod]
    public void SharedData_Test_4()
    {
        CollectionAssert.Contains(_sharedData.Values, 3);
    }

    [TestMethod]
    public void SharedData_Test_5()
    {
        Assert.AreEqual(3, _sharedData.Keys.Count);
    }
}
