using Xunit;

namespace XUnit.TraitTests.PerformanceTests;

[Trait("Category", "Performance")]
[Trait("Component", "Computation")]
[Trait("Priority", "High")]
public class ComputationPerformanceTests
{
    [Fact]
    public async Task Performance_LargeLoop_CompletesInTime()
    {
        await Task.Delay(800);
        var sum = 0;
        for (int i = 0; i < 1000000; i++)
        {
            sum += i;
        }
        Assert.True(sum > 0);
    }

    [Fact]
    public async Task Performance_Sorting_HandlesLargeDataset()
    {
        await Task.Delay(1200);
        var data = Enumerable.Range(1, 10000).OrderByDescending(x => x).ToList();
        data.Sort();
        Assert.Equal(1, data[0]);
    }

    [Fact]
    public async Task Performance_Search_BinarySearchEfficient()
    {
        await Task.Delay(500);
        var data = Enumerable.Range(1, 100000).ToArray();
        var searchIndex = Array.BinarySearch(data, 50000);
        Assert.True(searchIndex >= 0);
    }

    [Fact]
    public async Task Performance_Aggregation_SumsLargeCollection()
    {
        await Task.Delay(700);
        var sum = Enumerable.Range(1, 100000).Sum();
        Assert.Equal(705082704, sum);
    }

    [Fact]
    public async Task Performance_Filtering_ProcessesMillionRecords()
    {
        await Task.Delay(1500);
        var filtered = Enumerable.Range(1, 1000000).Where(x => x % 2 == 0).Count();
        Assert.Equal(500000, filtered);
    }
}

[Trait("Category", "Performance")]
[Trait("Component", "Memory")]
[Trait("Priority", "Medium")]
public class MemoryPerformanceTests
{
    [Fact]
    public async Task Performance_Memory_AllocatesLargeArray()
    {
        await Task.Delay(600);
        var array = new int[1000000];
        Assert.Equal(1000000, array.Length);
    }

    [Fact]
    public async Task Performance_Memory_CreatesManyObjects()
    {
        await Task.Delay(900);
        var objects = new List<object>();
        for (int i = 0; i < 100000; i++)
        {
            objects.Add(new { Id = i, Name = $"Object{i}" });
        }
        Assert.Equal(100000, objects.Count);
    }

    [Fact]
    public async Task Performance_Memory_StringConcatenation()
    {
        await Task.Delay(1100);
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < 10000; i++)
        {
            sb.Append($"Item{i},");
        }
        Assert.True(sb.Length > 0);
    }

    [Fact]
    public async Task Performance_Memory_DictionaryOperations()
    {
        await Task.Delay(800);
        var dict = new Dictionary<int, string>();
        for (int i = 0; i < 100000; i++)
        {
            dict[i] = $"Value{i}";
        }
        Assert.Equal(100000, dict.Count);
    }

    [Fact]
    public async Task Performance_Memory_ListOperations()
    {
        await Task.Delay(700);
        var list = new List<int>();
        for (int i = 0; i < 500000; i++)
        {
            list.Add(i);
        }
        Assert.Equal(500000, list.Count);
    }
}

[Trait("Category", "Performance")]
[Trait("Component", "IO")]
[Trait("Priority", "Low")]
public class IOPerformanceTests
{
    [Fact]
    public async Task Performance_IO_SimulatesFileReads()
    {
        await Task.Delay(2000);
        var bytesRead = 1024 * 1024;
        Assert.True(bytesRead > 0);
    }

    [Fact]
    public async Task Performance_IO_SimulatesFileWrites()
    {
        await Task.Delay(2500);
        var bytesWritten = 1024 * 1024;
        Assert.True(bytesWritten > 0);
    }

    [Fact]
    public async Task Performance_IO_SimulatesBulkOperations()
    {
        await Task.Delay(3000);
        var filesProcessed = 1000;
        Assert.Equal(1000, filesProcessed);
    }

    [Fact]
    public async Task Performance_IO_SimulatesNetworkTransfer()
    {
        await Task.Delay(1800);
        var transferred = true;
        Assert.True(transferred);
    }

    [Fact]
    public async Task Performance_IO_SimulatesStreamProcessing()
    {
        await Task.Delay(2200);
        var processed = true;
        Assert.True(processed);
    }
}
