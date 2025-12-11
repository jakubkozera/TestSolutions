using Xunit;

namespace XUnit.ParameterizedTests.TheoryTests;

[Trait("Category", "Unit")]
public class MemberDataTests
{
    [Theory]
    [MemberData(nameof(GetAdditionData))]
    public void Add_WithMemberData(int a, int b, int expected)
    {
        var result = a + b;
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> GetAdditionData()
    {
        yield return new object[] { 1, 2, 3 };
        yield return new object[] { 5, 5, 10 };
        yield return new object[] { -1, 1, 0 };
        yield return new object[] { 100, 200, 300 };
        yield return new object[] { 0, 0, 0 };
        yield return new object[] { -10, -20, -30 };
        yield return new object[] { 999, 1, 1000 };
        yield return new object[] { 50, 50, 100 };
    }

    [Theory]
    [MemberData(nameof(GetStringData))]
    public void StringOperations_WithMemberData(string input, string expected, string operation)
    {
        var result = operation switch
        {
            "upper" => input.ToUpper(),
            "lower" => input.ToLower(),
            "trim" => input.Trim(),
            _ => input
        };
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> GetStringData()
    {
        yield return new object[] { "hello", "HELLO", "upper" };
        yield return new object[] { "WORLD", "world", "lower" };
        yield return new object[] { "  test  ", "test", "trim" };
        yield return new object[] { "Test", "TEST", "upper" };
        yield return new object[] { "CASE", "case", "lower" };
    }

    [Theory]
    [MemberData(nameof(GetComplexData))]
    public void ComplexObjects_WithMemberData(TestData data, int expected)
    {
        var result = data.Value1 + data.Value2;
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> GetComplexData()
    {
        yield return new object[] { new TestData { Value1 = 10, Value2 = 20 }, 30 };
        yield return new object[] { new TestData { Value1 = 5, Value2 = 15 }, 20 };
        yield return new object[] { new TestData { Value1 = 100, Value2 = 200 }, 300 };
        yield return new object[] { new TestData { Value1 = -5, Value2 = 5 }, 0 };
    }

    [Theory]
    [MemberData(nameof(GetArrayData))]
    public void ArrayOperations_WithMemberData(int[] numbers, int expected)
    {
        var sum = numbers.Sum();
        Assert.Equal(expected, sum);
    }

    public static IEnumerable<object[]> GetArrayData()
    {
        yield return new object[] { new[] { 1, 2, 3 }, 6 };
        yield return new object[] { new[] { 10, 20, 30 }, 60 };
        yield return new object[] { new[] { -5, 5, 0 }, 0 };
        yield return new object[] { new[] { 100 }, 100 };
        yield return new object[] { Array.Empty<int>(), 0 };
    }

    [Theory]
    [MemberData(nameof(GetCollectionData))]
    public void ListOperations_WithMemberData(List<string> items, int expectedCount, string expectedFirst)
    {
        Assert.Equal(expectedCount, items.Count);
        if (expectedCount > 0)
        {
            Assert.Equal(expectedFirst, items[0]);
        }
    }

    public static IEnumerable<object[]> GetCollectionData()
    {
        yield return new object[] { new List<string> { "apple", "banana" }, 2, "apple" };
        yield return new object[] { new List<string> { "test" }, 1, "test" };
        yield return new object[] { new List<string>(), 0, "" };
        yield return new object[] { new List<string> { "one", "two", "three" }, 3, "one" };
    }

    [Theory]
    [MemberData(nameof(GetDictionaryData))]
    public void DictionaryOperations_WithMemberData(Dictionary<string, int> dict, string key, int expectedValue)
    {
        Assert.True(dict.ContainsKey(key));
        Assert.Equal(expectedValue, dict[key]);
    }

    public static IEnumerable<object[]> GetDictionaryData()
    {
        yield return new object[]
        {
            new Dictionary<string, int> { ["one"] = 1, ["two"] = 2 },
            "one",
            1
        };
        yield return new object[]
        {
            new Dictionary<string, int> { ["test"] = 100, ["value"] = 200 },
            "test",
            100
        };
    }

    [Theory]
    [MemberData(nameof(GetLongParameterData))]
    public void LongParameters_WithMemberData(int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int expected)
    {
        var result = p1 + p2 + p3 + p4 + p5 + p6 + p7 + p8;
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> GetLongParameterData()
    {
        yield return new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 36 };
        yield return new object[] { 10, 10, 10, 10, 10, 10, 10, 10, 80 };
        yield return new object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        yield return new object[] { 5, 5, 5, 5, 5, 5, 5, 5, 40 };
    }

    [Theory]
    [MemberData(nameof(GetBooleanData))]
    public void BooleanLogic_WithMemberData(bool input1, bool input2, string operation, bool expected)
    {
        var result = operation switch
        {
            "and" => input1 && input2,
            "or" => input1 || input2,
            "xor" => input1 ^ input2,
            _ => false
        };
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> GetBooleanData()
    {
        yield return new object[] { true, true, "and", true };
        yield return new object[] { true, false, "and", false };
        yield return new object[] { true, false, "or", true };
        yield return new object[] { false, false, "or", false };
        yield return new object[] { true, true, "xor", false };
        yield return new object[] { true, false, "xor", true };
    }

    public class TestData
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }
}
