using Xunit;

namespace XUnit.BasicTests.Unit.Collections;

[Trait("Category", "Unit")]
[Trait("Component", "Collections")]
public class QueueTests
{
    [Fact]
    public void Queue_Enqueue_AddsItem()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Queue_Dequeue_RemovesFirstItem()
    {
        var queue = new Queue<int>(new[] { 1, 2, 3 });
        var item = queue.Dequeue();
        Assert.Equal(1, item);
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Queue_Peek_DoesNotRemoveItem()
    {
        var queue = new Queue<int>(new[] { 1, 2, 3 });
        var item = queue.Peek();
        Assert.Equal(1, item);
        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void Queue_FIFO_Order()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.Equal(3, queue.Dequeue());
    }

    [Fact]
    public void Queue_Clear_RemovesAll()
    {
        var queue = new Queue<int>(new[] { 1, 2, 3 });
        queue.Clear();
        Assert.Empty(queue);
    }

    [Fact]
    public void Queue_Contains_FindsItem()
    {
        var queue = new Queue<int>(new[] { 1, 2, 3 });
        Assert.True(queue.Contains(2));
    }

    [Fact]
    public void Queue_ToArray_CreatesArray()
    {
        var queue = new Queue<int>(new[] { 1, 2, 3 });
        var array = queue.ToArray();
        Assert.Equal(3, array.Length);
    }

    [Fact]
    public void Queue_DequeueEmpty_ThrowsException()
    {
        var queue = new Queue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Queue_PeekEmpty_ThrowsException()
    {
        var queue = new Queue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void Queue_TryDequeue_ReturnsFalseWhenEmpty()
    {
        var queue = new Queue<int>();
        Assert.False(queue.TryDequeue(out _));
    }
}
