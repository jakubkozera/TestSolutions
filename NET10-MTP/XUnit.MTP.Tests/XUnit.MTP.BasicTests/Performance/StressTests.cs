using System.Threading.Tasks;
using Xunit;

namespace XUnit.BasicTests.Performance;

[Trait("Category", "Performance")]
[Trait("Priority", "Low")]
public class StressTests
{
    [Fact]
    public async Task Stress_ConcurrentOperations_HandlesLoad()
    {
        await Task.Delay(5000);
        var tasks = new List<Task>();
        for (int i = 0; i < 100; i++)
        {
            tasks.Add(Task.Run(async () => await Task.Delay(10)));
        }
        await Task.WhenAll(tasks);
        Assert.True(true);
    }

    [Fact]
    public async Task Stress_MemoryAllocations_CompletesSuccessfully()
    {
        await Task.Delay(5000);
        var lists = new List<List<int>>();
        for (int i = 0; i < 100; i++)
        {
            lists.Add(Enumerable.Range(0, 1000).ToList());
        }
        Assert.Equal(100, lists.Count);
    }

    [Fact]
    public async Task Stress_RecursiveOperations_DoesNotStackOverflow()
    {
        await Task.Delay(5000);
        int Fibonacci(int n) => n <= 1 ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
        var result = Fibonacci(20);
        Assert.Equal(6765, result);
    }

    [Fact]
    public async Task Stress_ExceptionHandling_PerformsWell()
    {
        await Task.Delay(5000);
        int count = 0;
        for (int i = 0; i < 1000; i++)
        {
            try
            {
                if (i % 2 == 0) throw new InvalidOperationException();
                count++;
            }
            catch (InvalidOperationException)
            {
                // Expected
            }
        }
        Assert.Equal(500, count);
    }

    [Fact]
    public async Task Stress_StringConcatenation_CompletesInTime()
    {
        await Task.Delay(5000);
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < 10000; i++)
        {
            sb.Append($"Item {i}\n");
        }
        var result = sb.ToString();
        Assert.Contains("Item 5000", result);
    }
}
