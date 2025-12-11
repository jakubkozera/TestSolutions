using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest.ComplexTests.AsyncTests;

[TestClass]
[TestCategory("Unit")]
public class AsyncOperationTests
{
    [TestMethod]
    public async Task Async_SimpleAwait_CompletesSuccessfully()
    {
        await Task.Delay(100);
        Assert.IsTrue(true);
    }

    [TestMethod]
    public async Task Async_MultipleAwaits_CompletesInSequence()
    {
        await Task.Delay(50);
        await Task.Delay(50);
        await Task.Delay(50);
        Assert.IsTrue(true);
    }

    [TestMethod]
    public async Task Async_TaskWhenAll_CompletesAllTasks()
    {
        var task1 = Task.Delay(100);
        var task2 = Task.Delay(100);
        var task3 = Task.Delay(100);
        
        await Task.WhenAll(task1, task2, task3);
        Assert.IsTrue(true);
    }

    [TestMethod]
    public async Task Async_TaskWhenAny_CompletesFirstTask()
    {
        var task1 = Task.Delay(100);
        var task2 = Task.Delay(200);
        var task3 = Task.Delay(300);
        
        var completed = await Task.WhenAny(task1, task2, task3);
        Assert.IsNotNull(completed);
    }

    [TestMethod]
    public async Task Async_ConfigureAwait_DoesNotCaptureContext()
    {
        await Task.Delay(100).ConfigureAwait(false);
        Assert.IsTrue(true);
    }

    [TestMethod]
    public async Task Async_ExceptionHandling_CatchesException()
    {
        try
        {
            await Task.Run(() => throw new InvalidOperationException("Test exception"));
            Assert.Fail("Should have thrown exception");
        }
        catch (InvalidOperationException)
        {
            Assert.IsTrue(true);
        }
    }

    [TestMethod]
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
            Assert.IsTrue(true);
        }
    }

    [TestMethod]
    public async Task Async_TaskRun_ExecutesOnThreadPool()
    {
        var result = await Task.Run(() =>
        {
            Thread.Sleep(100);
            return 42;
        });
        
        Assert.AreEqual(42, result);
    }

    [TestMethod]
    public async Task Async_Continuation_ChainsOperations()
    {
        var result = await Task.Run(() => 10)
            .ContinueWith(t => t.Result * 2)
            .ContinueWith(t => t.Result + 5);
        
        Assert.AreEqual(25, result);
    }

    [TestMethod]
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
        
        Assert.AreEqual(10, processed);
    }

    [TestMethod]
    public async Task Async_ValueTask_SupportsValueTask()
    {
        var result = await GetValueTaskResult();
        Assert.AreEqual(100, result);
    }

    private ValueTask<int> GetValueTaskResult()
    {
        return new ValueTask<int>(100);
    }

    [TestMethod]
    public async Task Async_AsyncEnumerable_IteratesAsync()
    {
        var count = 0;
        await foreach (var item in GetNumbersAsync())
        {
            count++;
        }
        
        Assert.AreEqual(5, count);
    }

    private async IAsyncEnumerable<int> GetNumbersAsync()
    {
        for (int i = 1; i <= 5; i++)
        {
            await Task.Delay(10);
            yield return i;
        }
    }

    [TestMethod]
    public async Task Async_Timeout_CompletesBeforeTimeout()
    {
        var task = Task.Delay(100);
        var timeout = Task.Delay(500);
        
        var completed = await Task.WhenAny(task, timeout);
        Assert.AreSame(task, completed);
    }

    [TestMethod]
    public async Task Async_ReturnValue_ReturnsCorrectValue()
    {
        var result = await GetAsyncValue();
        Assert.AreEqual("async result", result);
    }

    private async Task<string> GetAsyncValue()
    {
        await Task.Delay(50);
        return "async result";
    }
}
