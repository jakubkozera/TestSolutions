using NUnit.Framework;

namespace NUnit.CategoryTests.UnitTests;

[TestFixture]
[Category("Unit")]
[Category("Fast")]
public class QuickTests
{
    [Test]
    public void Quick_Test_1() => Assert.That(true, Is.True);

    [Test]
    public void Quick_Test_2() => Assert.That(1 + 1, Is.EqualTo(2));

    [Test]
    public void Quick_Test_3() => Assert.That("test", Is.EqualTo("test"));

    [Test]
    public void Quick_Test_4() => Assert.That(new[] { 1, 2, 3 }, Has.Length.EqualTo(3));

    [Test]
    public void Quick_Test_5() => Assert.That(10, Is.GreaterThan(5));

    [Test]
    public void Quick_Test_6() => Assert.That("hello", Does.StartWith("hel"));

    [Test]
    public void Quick_Test_7() => Assert.That("world", Does.EndWith("rld"));

    [Test]
    public void Quick_Test_8() => Assert.That(new List<int> { 1, 2, 3 }, Does.Contain(2));

    [Test]
    public void Quick_Test_9() => Assert.That(100.0, Is.EqualTo(100.0).Within(0.01));

    [Test]
    public void Quick_Test_10() => Assert.That(() => true, Is.True);

    [Test]
    [Category("Smoke")]
    public void Smoke_Test_1() => Assert.Pass();

    [Test]
    [Category("Smoke")]
    public void Smoke_Test_2() => Assert.That(DateTime.Now, Is.LessThan(DateTime.Now.AddDays(1)));

    [Test]
    [Category("Smoke")]
    public void Smoke_Test_3() => Assert.That(Path.GetTempPath(), Is.Not.Empty);

    [Test]
    [Category("Regression")]
    public void Regression_Test_1() => Assert.That("fixed_bug", Does.Contain("bug"));

    [Test]
    [Category("Regression")]
    public void Regression_Test_2() => Assert.That(5 * 5, Is.EqualTo(25));
}
