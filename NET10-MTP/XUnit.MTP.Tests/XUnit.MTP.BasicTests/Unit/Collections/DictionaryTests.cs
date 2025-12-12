using Xunit;

namespace XUnit.BasicTests.Unit.Collections;

[Trait("Category", "Unit")]
[Trait("Component", "Collections")]
public class DictionaryTests
{
    [Fact]
    public void Dictionary_Add_IncreasesCount()
    {
        var dict = new Dictionary<string, int>();
        dict.Add("one", 1);
        Assert.Equal(1, dict.Count);
    }

    [Fact]
    public void Dictionary_IndexerSet_AddsOrUpdates()
    {
        var dict = new Dictionary<string, int> { ["one"] = 1 };
        dict["one"] = 10;
        Assert.Equal(10, dict["one"]);
    }

    [Fact]
    public void Dictionary_ContainsKey_FindsKey()
    {
        var dict = new Dictionary<string, int> { ["one"] = 1 };
        Assert.True(dict.ContainsKey("one"));
    }

    [Fact]
    public void Dictionary_ContainsValue_FindsValue()
    {
        var dict = new Dictionary<string, int> { ["one"] = 1 };
        Assert.True(dict.ContainsValue(1));
    }

    [Fact]
    public void Dictionary_Remove_RemovesKey()
    {
        var dict = new Dictionary<string, int> { ["one"] = 1 };
        dict.Remove("one");
        Assert.Empty(dict);
    }

    [Fact]
    public void Dictionary_TryGetValue_RetrievesValue()
    {
        var dict = new Dictionary<string, int> { ["one"] = 1 };
        Assert.True(dict.TryGetValue("one", out var value));
        Assert.Equal(1, value);
    }

    [Fact]
    public void Dictionary_TryGetValue_ReturnsFalseForMissingKey()
    {
        var dict = new Dictionary<string, int>();
        Assert.False(dict.TryGetValue("missing", out _));
    }

    [Fact]
    public void Dictionary_Keys_ReturnsAllKeys()
    {
        var dict = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2 };
        Assert.Equal(2, dict.Keys.Count);
    }

    [Fact]
    public void Dictionary_Values_ReturnsAllValues()
    {
        var dict = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2 };
        Assert.Equal(2, dict.Values.Count);
    }

    [Fact]
    public void Dictionary_Clear_RemovesAll()
    {
        var dict = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2 };
        dict.Clear();
        Assert.Empty(dict);
    }

    [Fact]
    public void Dictionary_Indexer_ThrowsForMissingKey()
    {
        var dict = new Dictionary<string, int>();
        Assert.Throws<KeyNotFoundException>(() => dict["missing"]);
    }

    [Fact]
    public void Dictionary_DuplicateAdd_ThrowsException()
    {
        var dict = new Dictionary<string, int> { ["one"] = 1 };
        Assert.Throws<ArgumentException>(() => dict.Add("one", 2));
    }
}
