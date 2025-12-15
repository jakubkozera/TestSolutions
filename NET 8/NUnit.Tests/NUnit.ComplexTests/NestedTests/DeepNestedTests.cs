using NUnit.Framework;

namespace NUnit.ComplexTests.NestedTests;

[TestFixture]
public class Level1_OuterTests
{
    [Test]
    public void Level1_Test1()
    {
        Assert.That(1, Is.EqualTo(1));
    }

    [Test]
    public void Level1_Test2()
    {
        Assert.That("Level1", Is.Not.Empty);
    }

    [TestFixture]
    public class Level2_MiddleTests
    {
        [Test]
        public void Level2_Test1()
        {
            Assert.That(2, Is.EqualTo(2));
        }

        [Test]
        public void Level2_Test2()
        {
            Assert.That("Level2", Contains.Substring("2"));
        }

        [Test]
        public void Level2_Test3()
        {
            var list = new List<int> { 1, 2, 3 };
            Assert.That(list, Has.Count.EqualTo(3));
        }

        [TestFixture]
        public class Level3_InnerTests
        {
            [Test]
            public void Level3_Test1()
            {
                Assert.That(3, Is.EqualTo(3));
            }

            [Test]
            public void Level3_Test2()
            {
                Assert.That(true, Is.True);
            }

            [Test]
            public void Level3_Test3()
            {
                var dict = new Dictionary<string, int> { ["key"] = 3 };
                Assert.That(dict, Does.ContainKey("key"));
            }

            [Test]
            public void Level3_Test4()
            {
                Assert.That(3.0, Is.EqualTo(3).Within(0.01));
            }

            [TestFixture]
            public class Level4_DeepNestedTests
            {
                [Test]
                public void Level4_Test1()
                {
                    Assert.That(4, Is.EqualTo(4));
                }

                [Test]
                public void Level4_Test2()
                {
                    var text = "Level4";
                    Assert.That(text, Does.StartWith("Level"));
                }

                [Test]
                public void Level4_Test3()
                {
                    var array = new[] { 1, 2, 3, 4 };
                    Assert.That(array, Has.Length.EqualTo(4));
                }

                [Test]
                public void Level4_Test4()
                {
                    Assert.That(4 * 4, Is.EqualTo(16));
                }

                [Test]
                public void Level4_Test5()
                {
                    var result = Enumerable.Range(1, 4).Sum();
                    Assert.That(result, Is.EqualTo(10));
                }

                [Test]
                public void Level4_Test6()
                {
                    Assert.That(4.5, Is.GreaterThan(4.0));
                }

                [Test]
                public void Level4_Test7()
                {
                    var obj = new { Id = 4, Name = "Test" };
                    Assert.That(obj.Id, Is.EqualTo(4));
                }

                [Test]
                public void Level4_Test8()
                {
                    Assert.That("Level4", Does.EndWith("4"));
                }

                [Test]
                public void Level4_Test9()
                {
                    var collection = new List<int> { 1, 2, 3, 4 };
                    Assert.That(collection, Does.Contain(4));
                }

                [Test]
                public void Level4_Test10()
                {
                    Assert.That(4, Is.InRange(1, 10));
                }
            }
        }

        [Test]
        public void Level2_Test4()
        {
            Assert.That(2 + 2, Is.EqualTo(4));
        }

        [Test]
        public void Level2_Test5()
        {
            Assert.That(new[] { 2, 4, 6 }, Has.All.EvenNumbers());
        }
    }

    [Test]
    public void Level1_Test3()
    {
        Assert.That(1 + 1, Is.EqualTo(2));
    }

    [Test]
    public void Level1_Test4()
    {
        Assert.That(new List<int> { 1 }, Is.Not.Empty);
    }

    [Test]
    public void Level1_Test5()
    {
        Assert.That("test", Has.Length.EqualTo(4));
    }
}

public static class CustomConstraints
{
    public static EvenNumbersConstraint EvenNumbers(this ConstraintExpression expression)
    {
        return new EvenNumbersConstraint();
    }
}

public class EvenNumbersConstraint : NUnit.Framework.Constraints.Constraint
{
    public override NUnit.Framework.Constraints.ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        if (actual is System.Collections.IEnumerable enumerable)
        {
            var allEven = enumerable.Cast<int>().All(x => x % 2 == 0);
            return new NUnit.Framework.Constraints.ConstraintResult(this, actual, allEven);
        }
        return new NUnit.Framework.Constraints.ConstraintResult(this, actual, false);
    }
}
