using System.Threading.Tasks;
using Xunit;

namespace XUnit.ComplexTests.AsyncTests;

[Trait("Category", "Unit")]
[Trait("Type", "Async")]
public class AsyncOperationTests
{
    [Fact]
    public async Task Async_SimpleAwait_CompletesSuccessfully()
    {
        await Task.Delay(10);
        Assert.True(true);
    }

    [Fact]
    public async Task Async_MultipleAwaits_ExecutesSequentially()
    {
        await Task.Delay(10);
        var result = 1;
        await Task.Delay(10);
        result += 2;
        await Task.Delay(10);
        result += 3;
        Assert.Equal(6, result);
    }

    [Fact]
    public async Task Async_TaskWhenAll_ExecutesInParallel()
    {
        var task1 = Task.Delay(50).ContinueWith(_ => 1);
        var task2 = Task.Delay(50).ContinueWith(_ => 2);
        var task3 = Task.Delay(50).ContinueWith(_ => 3);

        var results = await Task.WhenAll(task1, task2, task3);
        Assert.Equal(6, results.Sum());
    }

    [Fact]
    public async Task Async_TaskWhenAny_CompletesWhenFirst()
    {
        var task1 = Task.Delay(100).ContinueWith(_ => "slow");
        var task2 = Task.Delay(10).ContinueWith(_ => "fast");

        var completedTask = await Task.WhenAny(task1, task2);
        var result = await completedTask;
        Assert.Equal("fast", result);
    }

    [Fact]
    public async Task Async_ConfigureAwait_WorksCorrectly()
    {
        await Task.Delay(20).ConfigureAwait(false);
        var result = 42;
        Assert.Equal(42, result);
    }

    [Fact]
    public async Task Async_ExceptionHandling_CatchesException()
    {
        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await Task.Delay(10);
            throw new InvalidOperationException("Test exception");
        });
    }

    [Fact]
    public async Task Async_CancellationToken_CancelsOperation()
    {
        var cts = new System.Threading.CancellationTokenSource();
        cts.CancelAfter(50);

        await Assert.ThrowsAsync<TaskCanceledException>(async () =>
        {
            await Task.Delay(1000, cts.Token);
        });
    }

    [Fact]
    public async Task Async_ReturnValue_ReturnsCorrectly()
    {
        var result = await GetValueAsync();
        Assert.Equal(100, result);
    }

    [Fact]
    public async Task Async_LongRunning_CompletesEventually()
    {
        await Task.Delay(500);
        var result = await ProcessLongOperationAsync();
        Assert.True(result);
    }

    [Fact]
    public async Task Async_NestedAwait_WorksCorrectly()
    {
        var result = await OuterAsync();
        Assert.Equal("nested", result);
    }

    [Fact]
    public async Task Async_TaskRun_ExecutesOnThreadPool()
    {
        var result = await Task.Run(() =>
        {
            Thread.Sleep(50);
            return 42;
        });
        Assert.Equal(42, result);
    }

    [Fact]
    public async Task Async_Continuation_ChainsCorrectly()
    {
        var result = await Task.Delay(20)
            .ContinueWith(_ => 10)
            .ContinueWith(t => t.Result * 2);
        Assert.Equal(20, result);
    }

    [Fact]
    public async Task Async_ParallelForEach_ProcessesItems()
    {
        var items = Enumerable.Range(1, 10).ToList();
        var results = new System.Collections.Concurrent.ConcurrentBag<int>();

        await Task.Run(() =>
        {
            Parallel.ForEach(items, item =>
            {
                Thread.Sleep(10);
                results.Add(item * 2);
            });
        });

        Assert.Equal(10, results.Count);
    }

    [Fact]
    public async Task Async_ValueTask_WorksLikeTask()
    {
        var result = await GetValueTaskAsync();
        Assert.Equal(50, result);
    }

    [Fact]
    public async Task Async_AsyncEnumerable_IteratesCorrectly()
    {
        var count = 0;
        await foreach (var item in GetAsyncEnumerableAsync())
        {
            count++;
        }
        Assert.Equal(5, count);
    }

    // Helper methods
    private async Task<int> GetValueAsync()
    {
        await Task.Delay(10);
        return 100;
    }

    private async Task<bool> ProcessLongOperationAsync()
    {
        await Task.Delay(100);
        return true;
    }

    private async Task<string> OuterAsync()
    {
        var result = await InnerAsync();
        return result;
    }

    private async Task<string> InnerAsync()
    {
        await Task.Delay(10);
        return "nested";
    }

    private async ValueTask<int> GetValueTaskAsync()
    {
        await Task.Delay(10);
        return 50;
    }

    private async IAsyncEnumerable<int> GetAsyncEnumerableAsync()
    {
        for (int i = 0; i < 5; i++)
        {
            await Task.Delay(10);
            yield return i;
        }
    }
}
