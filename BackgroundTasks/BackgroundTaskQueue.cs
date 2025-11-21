using System.Threading.Channels;

namespace kvandijk.Common.BackgroundTasks;

public sealed class BackgroundTaskQueue : IBackgroundTaskQueue
{
    private readonly Channel<Func<IServiceProvider, CancellationToken, ValueTask>> _channel;

    public BackgroundTaskQueue(int capacity = 100)
    {
        var options = new BoundedChannelOptions(capacity)
        {
            FullMode = BoundedChannelFullMode.Wait, // backpressure
        };
        _channel = Channel.CreateBounded<Func<IServiceProvider, CancellationToken, ValueTask>>(options);
    }

    public ValueTask QueueAsync(Func<IServiceProvider, CancellationToken, ValueTask> workItem)
        => _channel.Writer.WriteAsync(workItem);

    public ValueTask<Func<IServiceProvider, CancellationToken, ValueTask>> DequeueAsync(CancellationToken ct)
        => _channel.Reader.ReadAsync(ct);
}