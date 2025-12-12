using System.Threading.Tasks;
using Xunit;

namespace XUnit.BasicTests.Performance;

[Trait("Category", "Performance")]
[Trait("Priority", "Low")]
public class LargeDatasetTests
{
    [Fact]
    public async Task Process_LargeArray_CompletesInReasonableTime()
    {
        await Task.Delay(3000);
        var array = new int[10000];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i * 2;
        }
        Assert.Equal(10000, array.Length);
    }

    [Fact]
    public async Task Sort_LargeArray_CompletesSuccessfully()
    {
        await Task.Delay(5000);
        var array = new int[5000];
        var random = new Random(42);
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next();
        }
        Array.Sort(array);
        Assert.True(array[0] <= array[array.Length - 1]);
    }

    [Fact]
    public async Task Search_LargeDictionary_FindsValue()
    {
        await Task.Delay(4000);
        var dict = new Dictionary<int, string>();
        for (int i = 0; i < 10000; i++)
        {
            dict[i] = $"Value_{i}";
        }
        Assert.Equal("Value_5000", dict[5000]);
    }

    [Fact]
    public async Task Filter_LargeList_ReturnsMatchingItems()
    {
        await Task.Delay(6000);
        var list = Enumerable.Range(0, 10000).ToList();
        var filtered = list.Where(x => x % 2 == 0).ToList();
        Assert.Equal(5000, filtered.Count);
    }

    [Fact]
    public async Task GroupBy_LargeDataset_GroupsCorrectly()
    {
        await Task.Delay(7000);
        var data = Enumerable.Range(0, 10000).Select(x => new { Group = x % 10, Value = x }).ToList();
        var grouped = data.GroupBy(x => x.Group).ToList();
        Assert.Equal(10, grouped.Count);
    }

    [Fact]
    public async Task Join_LargeDatasets_ProducesResults()
    {
        await Task.Delay(8000);
        var left = Enumerable.Range(0, 5000).Select(x => new { Id = x, Value = $"L{x}" }).ToList();
        var right = Enumerable.Range(0, 5000).Select(x => new { Id = x, Value = $"R{x}" }).ToList();
        var joined = left.Join(right, l => l.Id, r => r.Id, (l, r) => new { l.Id, l.Value, RValue = r.Value }).ToList();
        Assert.Equal(5000, joined.Count);
    }

    [Fact]
    public async Task Aggregate_LargeSequence_ComputesCorrectly()
    {
        await Task.Delay(5000);
        var sum = Enumerable.Range(1, 10000).Aggregate(0, (acc, x) => acc + x);
        Assert.Equal(50005000, sum);
    }

    [Fact]
    public async Task Distinct_LargeDatasetWithDuplicates_RemovesDuplicates()
    {
        await Task.Delay(6000);
        var data = Enumerable.Range(0, 10000).Concat(Enumerable.Range(0, 10000)).ToList();
        var distinct = data.Distinct().ToList();
        Assert.Equal(10000, distinct.Count);
    }

    [Fact]
    public async Task OrderBy_MultipleKeys_SortsCorrectly()
    {
        await Task.Delay(9000);
        var data = Enumerable.Range(0, 5000)
            .Select(x => new { Primary = x % 10, Secondary = x % 100, Value = x })
            .OrderBy(x => x.Primary)
            .ThenBy(x => x.Secondary)
            .ToList();
        Assert.Equal(5000, data.Count);
    }

    [Fact]
    public async Task SelectMany_NestedCollections_FlattensCorrectly()
    {
        await Task.Delay(10000);
        var nested = Enumerable.Range(0, 100)
            .Select(x => Enumerable.Range(0, 100).ToList())
            .ToList();
        var flattened = nested.SelectMany(x => x).ToList();
        Assert.Equal(10000, flattened.Count);
    }
}
