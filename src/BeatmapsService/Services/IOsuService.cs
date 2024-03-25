using BeatmapsService.Models.Osu;

namespace BeatmapsService.Services;

public interface IOsuService
{
    Task<BeatmapExtended?> FindBeatmapByIdAsync(int beatmapId, CancellationToken cancellationToken = default);
    Task<BeatmapsetExtended?> FindBeatmapsetByIdAsync(int beatmapsetId, CancellationToken cancellationToken = default);
}