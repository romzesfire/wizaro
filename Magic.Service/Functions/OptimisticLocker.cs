using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;
using Magic.DTO.Interfaces;
using Magic.Service.Configuration;
using Magic.Service.Exceptions;

namespace Magic.Service.Functions;

public class OptimisticLocker : ILocker
{
    private readonly RetryPolicy _retryPolicy;

    public OptimisticLocker(IOptions<LockerConfiguration> config)
    {
        var delay = Backoff
            .DecorrelatedJitterBackoffV2(TimeSpan.FromMilliseconds(config.Value.DelayMilliseconds),
                config.Value.IterationCount);

        _retryPolicy = Policy.Handle<DbUpdateConcurrencyException>()
            .WaitAndRetry(delay);
    }

    public void ConcurrentExecute(Action func)
    {
        var result = _retryPolicy.ExecuteAndCapture(func);
        switch (result.FinalException)
        {
            case null:
                return;
            case DbUpdateConcurrencyException:
                throw new ConcurrentWriteException();
            default:
                throw result.FinalException;
        }
    }

    public async Task ConcurrentExecuteAsync(Action func)
    {
        await Task.Run(() => ConcurrentExecute(func));
    }
}