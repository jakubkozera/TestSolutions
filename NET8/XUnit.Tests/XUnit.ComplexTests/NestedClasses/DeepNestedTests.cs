using Xunit;

namespace XUnit.ComplexTests.NestedClasses;

[Trait("Category", "Unit")]
[Trait("Type", "Nested")]
public class Level1_OuterTests
{
    [Fact]
    public void Level1_Test1()
    {
        Assert.True(true);
    }

    [Fact]
    public void Level1_Test2()
    {
        var result = 1 + 1;
        Assert.Equal(2, result);
    }

    [Trait("Category", "Unit")]
    [Trait("Type", "Nested")]
    public class Level2_MiddleTests
    {
        [Fact]
        public void Level2_Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void Level2_Test2()
        {
            var list = new List<int> { 1, 2, 3 };
            Assert.NotEmpty(list);
        }

        [Fact]
        public void Level2_Test3()
        {
            var text = "Hello World";
            Assert.Contains("World", text);
        }

        [Trait("Category", "Unit")]
        [Trait("Type", "Nested")]
        public class Level3_InnerTests
        {
            [Fact]
            public void Level3_Test1()
            {
                Assert.True(true);
            }

            [Fact]
            public void Level3_Test2()
            {
                var dict = new Dictionary<string, int> { ["key"] = 42 };
                Assert.True(dict.ContainsKey("key"));
            }

            [Fact]
            public void Level3_Test3()
            {
                var numbers = new[] { 1, 2, 3, 4, 5 };
                Assert.Equal(5, numbers.Length);
            }

            [Fact]
            public void Level3_Test4()
            {
                var result = Math.Pow(2, 3);
                Assert.Equal(8, result);
            }

            [Trait("Category", "Unit")]
            [Trait("Type", "Nested")]
            public class Level4_DeepNestedTests
            {
                [Fact]
                public void Level4_Test1()
                {
                    Assert.True(true);
                }

                [Fact]
                public void Level4_Test2()
                {
                    var text = "Nested";
                    Assert.Equal(6, text.Length);
                }

                [Fact]
                public void Level4_Test3()
                {
                    var list = new List<string> { "a", "b", "c" };
                    Assert.Equal(3, list.Count);
                }

                [Fact]
                public void Level4_Test4()
                {
                    var value = 100;
                    Assert.InRange(value, 1, 1000);
                }

                [Fact]
                public void Level4_Test5()
                {
                    var items = new[] { 1, 2, 3 };
                    Assert.All(items, item => Assert.True(item > 0));
                }
            }
        }
    }

    [Trait("Category", "Unit")]
    [Trait("Type", "Nested")]
    public class Level2_AlternateTests
    {
        [Fact]
        public void Level2Alt_Test1()
        {
            var result = "test".ToUpper();
            Assert.Equal("TEST", result);
        }

        [Fact]
        public void Level2Alt_Test2()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            Assert.Single(queue);
        }

        [Trait("Category", "Unit")]
        [Trait("Type", "Nested")]
        public class Level3_AlternateInnerTests
        {
            [Fact]
            public void Level3Alt_Test1()
            {
                var stack = new Stack<string>();
                stack.Push("item");
                Assert.Equal("item", stack.Peek());
            }

            [Fact]
            public void Level3Alt_Test2()
            {
                var hashSet = new HashSet<int> { 1, 2, 3 };
                Assert.True(hashSet.Add(4));
            }
        }
    }
}
