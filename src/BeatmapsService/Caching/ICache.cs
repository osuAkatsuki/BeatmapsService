using Microsoft.Extensions.Caching.Distributed;

namespace BeatmapsService.Caching;

public interface ICache
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class;
    Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default);
    Task<(T? Item, bool Created)> GetOrCreateAsync<T>(
        string key,
        Func<DistributedCacheEntryOptions, Task<T?>> factory,
        CancellationToken cancellationToken = default)
        where T : class;
}