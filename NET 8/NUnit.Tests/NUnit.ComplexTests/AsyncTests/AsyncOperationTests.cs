using NUnit.Framework;

namespace NUnit.ComplexTests.AsyncTests;

[TestFixture]
[Category("Unit")]
public class AsyncOperationTests
{
    [Test]
    public async Task Async_SimpleAwait_CompletesSuccessfully()
    {
        await Task.Delay(100);
        Assert.Pass();
    }

    [Test]
    public async Task Async_MultipleAwaits_CompletesInSequence()
    {
        await Task.Delay(50);
        await Task.Delay(50);
        await Task.Delay(50);
        Assert.Pass();
    }

    [Test]
    public async Task Async_TaskWhenAll_CompletesAllTasks()
    {
        var task1 = Task.Delay(100);
        var task2 = Task.Delay(100);
        var task3 = Task.Delay(100);
        
        await Task.WhenAll(task1, task2, task3);
        Assert.Pass();
    }

    [Test]
    public async Task Async_TaskWhenAny_CompletesFirstTask()
    {
        var task1 = Task.Delay(100);
        var task2 = Task.Delay(200);
        var task3 = Task.Delay(300);
        
        var completed = await Task.WhenAny(task1, task2, task3);
        Assert.That(completed, Is.Not.Null);
    }

    [Test]
    public async Task Async_ConfigureAwait_DoesNotCaptureContext()
    {
        await Task.Delay(100).ConfigureAwait(false);
        Assert.Pass();
    }

    [Test]
    public async Task Async_ExceptionHandling_CatchesException()
    {
        try
        {
            await Task.Run(() => throw new InvalidOperationException("Test exception"));
            Assert.Fail("Should have thrown exception");
        }
        catch (InvalidOperationException)
        {
            Assert.Pass();
        }
    }

    [Test]
    public async Task Async_CancellationToken_SupportsCancellation()
    {
        var cts = new CancellationTokenSource();
        cts.CancelAfter(100);
        
        try
        {
            await Task.Delay(1000, cts.Token);
            Assert.Fail("Should have been cancelled");
        }
        catch (TaskCanceledException)
        {
            Assert.Pass();
        }
    }

    [Test]
    public async Task Async_TaskRun_ExecutesOnThreadPool()
    {
        var result = await Task.Run(() =>
        {
            Thread.Sleep(100);
            return 42;
        });
        
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public async Task Async_Continuation_ChainsOperations()
    {
        var result = await Task.Run(() => 10)
            .ContinueWith(t => t.Result * 2)
            .ContinueWith(t => t.Result + 5);
        
        Assert.That(result, Is.EqualTo(25));
    }

    [Test]
    public async Task Async_ParallelForEach_ProcessesInParallel()
    {
        var items = Enumerable.Range(1, 10).ToList();
        var processed = 0;
        
        await Task.Run(() =>
        {
            Parallel.ForEach(items, item =>
            {
                Thread.Sleep(50);
                Interlocked.Increment(ref processed);
            });
        });
        
        Assert.That(processed, Is.EqualTo(10));
    }

    [Test]
    public async Task Async_ValueTask_SupportsValueTask()
    {
        var result = await GetValueTaskResult();
        Assert.That(result, Is.EqualTo(100));
    }

    private ValueTask<int> GetValueTaskResult()
    {
        return new ValueTask<int>(100);
    }

    [Test]
    public async Task Async_AsyncEnumerable_IteratesAsync()
    {
        var count = 0;
        await foreach (var item in GetNumbersAsync())
        {
            count++;
        }
        
        Assert.That(count, Is.EqualTo(5));
    }

    private async IAsyncEnumerable<int> GetNumbersAsync()
    {
        for (int i = 1; i <= 5; i++)
        {
            await Task.Delay(10);
            yield return i;
        }
    }

    [Test]
    public async Task Async_Timeout_CompletesBeforeTimeout()
    {
        var task = Task.Delay(100);
        var timeout = Task.Delay(500);
        
        var completed = await Task.WhenAny(task, timeout);
        Assert.That(completed, Is.SameAs(task));
    }

    [Test]
    public async Task Async_ReturnValue_ReturnsCorrectValue()
    {
        var result = await GetAsyncValue();
        Assert.That(result, Is.EqualTo("async result"));
    }

    private async Task<string> GetAsyncValue()
    {
        await Task.Delay(50);
        return "async result";
    }
}
