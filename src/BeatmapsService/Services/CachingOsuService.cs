using BeatmapsService.Caching;
using BeatmapsService.Helpers;
using BeatmapsService.Models.Osu;
using Microsoft.Extensions.Caching.Distributed;

namespace BeatmapsService.Services;

public class CachingOsuService(IOsuService osuService, ICache cache) : IOsuService
{
    private const string BeatmapKey = "beatmaps";
    private const string BeatmapsetKey = "beatmapsets";

    public Task<BeatmapExtended?> FindBeatmapByIdAsync(int beatmapId, CancellationToken cancellationToken = default)
    {
        return cache.GetOrCreateAsync(
            $"{BeatmapKey}/{beatmapId}",
            async options =>
            {
                var response = await osuService.FindBeatmapByIdAsync(beatmapId, cancellationToken);
                if (response is null)
                    return null;

                options.SetAbsoluteExpiration(BeatmapHelper.GetCacheExpiry(response.Ranked));

                return response;
            },
            cancellationToken);
    }

    public Task<BeatmapsetExtended?> FindBeatmapsetByIdAsync(int beatmapsetId, CancellationToken cancellationToken = default)
    {
        return cache.GetOrCreateAsync(
            $"{BeatmapsetKey}/{beatmapsetId}",
            async options =>
            {
                var response = await osuService.FindBeatmapsetByIdAsync(beatmapsetId, cancellationToken);
                if (response is null)
                    return null;

                options.SetAbsoluteExpiration(BeatmapHelper.GetCacheExpiry(response.Ranked));

                return response;
            },
            cancellationToken);
    }
}