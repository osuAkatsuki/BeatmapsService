using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace BeatmapsService.Caching;

public class Cache(IDistributedCache distributedCache) : ICache
{
    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
    {
        var byteData = await distributedCache.GetAsync(key, cancellationToken);
        if (byteData is null)
            return null;

        var data = JsonSerializer.Deserialize<T>(byteData);
        return data;
    }

    public async Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions? options = null, CancellationToken cancellationToken = default)
    {
        var byteData = JsonSerializer.SerializeToUtf8Bytes(value);
        options ??= new DistributedCacheEntryOptions();

        await distributedCache.SetAsync(key, byteData, options, cancellationToken);
    }

    public async Task<(T? Item, bool Created)> GetOrCreateAsync<T>(
        string key,
        Func<DistributedCacheEntryOptions, Task<T?>> factory,
        CancellationToken cancellationToken = default)
        where T : class
    {
        var cachedRecord = await GetAsync<T>(key, cancellationToken);
        if (cachedRecord is not null)
            return (cachedRecord, false);

        var options = new DistributedCacheEntryOptions();
        
        var record = await factory(options);
        if (record is not null)
            await SetAsync(key, record, options, cancellationToken);

        return (record, true);
    }
}