using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.BasicTests.Performance;

[TestClass]
[TestCategory("Performance")]
public class PerformanceTests
{
    [TestMethod]
    public async Task Performance_LargeLoop_CompletesInTime()
    {
        await Task.Delay(800);
        var sum = 0;
        for (int i = 0; i < 1000000; i++)
        {
            sum += i;
        }
        Assert.IsTrue(sum > 0);
    }

    [TestMethod]
    public async Task Performance_Sorting_HandlesLargeDataset()
    {
        await Task.Delay(1200);
        var data = Enumerable.Range(1, 10000).OrderByDescending(x => x).ToList();
        data.Sort();
        Assert.AreEqual(1, data[0]);
    }

    [TestMethod]
    public async Task Performance_Search_BinarySearch()
    {
        await Task.Delay(500);
        var data = Enumerable.Range(1, 100000).ToArray();
        var searchIndex = Array.BinarySearch(data, 50000);
        Assert.IsTrue(searchIndex >= 0);
    }

    [TestMethod]
    public async Task Performance_Aggregation_SumsLargeCollection()
    {
        await Task.Delay(700);
        var sum = Enumerable.Range(1, 100000).Sum();
        Assert.AreEqual(705082704, sum);
    }

    [TestMethod]
    public async Task Performance_Filtering_ProcessesMillionRecords()
    {
        await Task.Delay(1500);
        var filtered = Enumerable.Range(1, 1000000).Where(x => x % 2 == 0).Count();
        Assert.AreEqual(500000, filtered);
    }

    [TestMethod]
    public async Task Performance_Memory_AllocatesLargeArray()
    {
        await Task.Delay(600);
        var array = new int[1000000];
        Assert.AreEqual(1000000, array.Length);
    }

    [TestMethod]
    public async Task Performance_Memory_CreatesManyObjects()
    {
        await Task.Delay(900);
        var objects = new List<object>();
        for (int i = 0; i < 100000; i++)
        {
            objects.Add(new { Id = i, Name = $"Object{i}" });
        }
        Assert.AreEqual(100000, objects.Count);
    }

    [TestMethod]
    public async Task Performance_StringConcatenation()
    {
        await Task.Delay(1100);
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < 10000; i++)
        {
            sb.Append($"Item{i},");
        }
        Assert.IsTrue(sb.Length > 0);
    }

    [TestMethod]
    public async Task Performance_DictionaryOperations()
    {
        await Task.Delay(800);
        var dict = new Dictionary<int, string>();
        for (int i = 0; i < 100000; i++)
        {
            dict[i] = $"Value{i}";
        }
        Assert.AreEqual(100000, dict.Count);
    }

    [TestMethod]
    public async Task Performance_ListOperations()
    {
        await Task.Delay(700);
        var list = new List<int>();
        for (int i = 0; i < 500000; i++)
        {
            list.Add(i);
        }
        Assert.AreEqual(500000, list.Count);
    }

    [TestMethod]
    public async Task Performance_IO_SimulatesFileReads()
    {
        await Task.Delay(2000);
        var bytesRead = 1024 * 1024;
        Assert.IsTrue(bytesRead > 0);
    }

    [TestMethod]
    public async Task Performance_IO_SimulatesFileWrites()
    {
        await Task.Delay(2500);
        var bytesWritten = 1024 * 1024;
        Assert.IsTrue(bytesWritten > 0);
    }

    [TestMethod]
    public async Task Performance_IO_BulkOperations()
    {
        await Task.Delay(3000);
        var filesProcessed = 1000;
        Assert.AreEqual(1000, filesProcessed);
    }

    [TestMethod]
    public async Task Performance_Parallel_ProcessesInParallel()
    {
        await Task.Delay(1800);
        var processed = 0;
        Parallel.For(0, 1000, i =>
        {
            Interlocked.Increment(ref processed);
        });
        Assert.AreEqual(1000, processed);
    }

    [TestMethod]
    public async Task Performance_Linq_ComplexQuery()
    {
        await Task.Delay(1000);
        var result = Enumerable.Range(1, 10000)
            .Where(x => x % 2 == 0)
            .Select(x => x * 2)
            .OrderByDescending(x => x)
            .Take(100)
            .ToList();
        Assert.AreEqual(100, result.Count);
    }
}
