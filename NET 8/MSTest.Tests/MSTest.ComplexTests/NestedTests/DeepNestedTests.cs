using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.ComplexTests.NestedTests;

[TestClass]
public class Level1_OuterTests
{
    [TestMethod]
    public void Level1_Test1()
    {
        Assert.AreEqual(1, 1);
    }

    [TestMethod]
    public void Level1_Test2()
    {
        Assert.IsTrue("Level1".Length > 0);
    }

    [TestClass]
    public class Level2_MiddleTests
    {
        [TestMethod]
        public void Level2_Test1()
        {
            Assert.AreEqual(2, 2);
        }

        [TestMethod]
        public void Level2_Test2()
        {
            StringAssert.Contains("Level2", "2");
        }

        [TestMethod]
        public void Level2_Test3()
        {
            var list = new List<int> { 1, 2, 3 };
            Assert.AreEqual(3, list.Count);
        }

        [TestClass]
        public class Level3_InnerTests
        {
            [TestMethod]
            public void Level3_Test1()
            {
                Assert.AreEqual(3, 3);
            }

            [TestMethod]
            public void Level3_Test2()
            {
                Assert.IsTrue(true);
            }

            [TestMethod]
            public void Level3_Test3()
            {
                var dict = new Dictionary<string, int> { ["key"] = 3 };
                Assert.IsTrue(dict.ContainsKey("key"));
            }

            [TestMethod]
            public void Level3_Test4()
            {
                Assert.AreEqual(3.0, 3, 0.01);
            }

            [TestClass]
            public class Level4_DeepNestedTests
            {
                [TestMethod]
                public void Level4_Test1()
                {
                    Assert.AreEqual(4, 4);
                }

                [TestMethod]
                public void Level4_Test2()
                {
                    var text = "Level4";
                    StringAssert.StartsWith(text, "Level");
                }

                [TestMethod]
                public void Level4_Test3()
                {
                    var array = new[] { 1, 2, 3, 4 };
                    Assert.AreEqual(4, array.Length);
                }

                [TestMethod]
                public void Level4_Test4()
                {
                    Assert.AreEqual(16, 4 * 4);
                }

                [TestMethod]
                public void Level4_Test5()
                {
                    var result = Enumerable.Range(1, 4).Sum();
                    Assert.AreEqual(10, result);
                }

                [TestMethod]
                public void Level4_Test6()
                {
                    Assert.IsTrue(4.5 > 4.0);
                }

                [TestMethod]
                public void Level4_Test7()
                {
                    var obj = new { Id = 4, Name = "Test" };
                    Assert.AreEqual(4, obj.Id);
                }

                [TestMethod]
                public void Level4_Test8()
                {
                    StringAssert.EndsWith("Level4", "4");
                }

                [TestMethod]
                public void Level4_Test9()
                {
                    var collection = new List<int> { 1, 2, 3, 4 };
                    CollectionAssert.Contains(collection, 4);
                }

                [TestMethod]
                public void Level4_Test10()
                {
                    Assert.IsTrue(4 >= 1 && 4 <= 10);
                }
            }
        }

        [TestMethod]
        public void Level2_Test4()
        {
            Assert.AreEqual(4, 2 + 2);
        }

        [TestMethod]
        public void Level2_Test5()
        {
            var numbers = new[] { 2, 4, 6 };
            Assert.IsTrue(numbers.All(x => x % 2 == 0));
        }
    }

    [TestMethod]
    public void Level1_Test3()
    {
        Assert.AreEqual(2, 1 + 1);
    }

    [TestMethod]
    public void Level1_Test4()
    {
        Assert.IsTrue(new List<int> { 1 }.Count > 0);
    }

    [TestMethod]
    public void Level1_Test5()
    {
        Assert.AreEqual(4, "test".Length);
    }
}
