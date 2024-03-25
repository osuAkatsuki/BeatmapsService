namespace BeatmapsService.Helpers;

public static class BeatmapHelper
{
    public static TimeSpan GetCacheExpiry(int ranked)
    {
        return ranked switch
        {
            // graveyard
            -2 => TimeSpan.FromDays(1),
            // wip
            -1 => TimeSpan.FromMinutes(5),
            // pending,
            0 => TimeSpan.FromMinutes(10),
            // ranked
            1 => TimeSpan.FromDays(1),
            // approved
            2 => TimeSpan.FromDays(1),
            // qualified
            3 => TimeSpan.FromMinutes(5),
            // loved
            4 => TimeSpan.FromDays(1),
            _ => throw new InvalidOperationException($"Ranked status {ranked} is invalid"),
        };
    }
}