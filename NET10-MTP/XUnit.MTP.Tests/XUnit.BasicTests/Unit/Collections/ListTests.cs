using System.Linq;
using Xunit;

namespace XUnit.BasicTests.Unit.Collections;

[Trait("Category", "Unit")]
[Trait("Component", "Collections")]
public class ListTests
{
    [Fact]
    public void List_Add_IncreasesCount()
    {
        var list = new List<int>();
        list.Add(1);
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void List_AddRange_AddsMultipleItems()
    {
        var list = new List<int>();
        list.AddRange(new[] { 1, 2, 3 });
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void List_Remove_DecreasesCount()
    {
        var list = new List<int> { 1, 2, 3 };
        list.Remove(2);
        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void List_Contains_FindsItem()
    {
        var list = new List<string> { "apple", "banana", "cherry" };
        Assert.True(list.Contains("banana"));
    }

    [Fact]
    public void List_IndexOf_ReturnsCorrectIndex()
    {
        var list = new List<string> { "apple", "banana", "cherry" };
        Assert.Equal(1, list.IndexOf("banana"));
    }

    [Fact]
    public void List_Clear_RemovesAllItems()
    {
        var list = new List<int> { 1, 2, 3 };
        list.Clear();
        Assert.Empty(list);
    }

    [Fact]
    public void List_Insert_PlacesItemAtIndex()
    {
        var list = new List<int> { 1, 3 };
        list.Insert(1, 2);
        Assert.Equal(2, list[1]);
    }

    [Fact]
    public void List_RemoveAt_RemovesItemAtIndex()
    {
        var list = new List<int> { 1, 2, 3 };
        list.RemoveAt(1);
        Assert.Equal(new[] { 1, 3 }, list);
    }

    [Fact]
    public void List_Sort_OrdersItems()
    {
        var list = new List<int> { 3, 1, 2 };
        list.Sort();
        Assert.Equal(new[] { 1, 2, 3 }, list);
    }

    [Fact]
    public void List_Reverse_ReversesOrder()
    {
        var list = new List<int> { 1, 2, 3 };
        list.Reverse();
        Assert.Equal(new[] { 3, 2, 1 }, list);
    }

    [Fact]
    public void List_Find_ReturnsFirstMatch()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var result = list.Find(x => x > 2);
        Assert.Equal(3, result);
    }

    [Fact]
    public void List_FindAll_ReturnsAllMatches()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var result = list.FindAll(x => x > 2);
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void List_Any_ChecksForMatch()
    {
        var list = new List<int> { 1, 2, 3 };
        Assert.True(list.Any(x => x == 2));
    }

    [Fact]
    public void List_All_ChecksAllItems()
    {
        var list = new List<int> { 2, 4, 6 };
        Assert.True(list.All(x => x % 2 == 0));
    }

    [Fact]
    public void List_ToArray_CreatesArray()
    {
        var list = new List<int> { 1, 2, 3 };
        var array = list.ToArray();
        Assert.Equal(3, array.Length);
    }
}
