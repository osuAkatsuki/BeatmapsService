using System.Text.Json.Serialization;

namespace BeatmapsService.Models.Osu;

public class BeatmapsetExtended : BeatmapsetBase
{
    [JsonPropertyName("beatmaps")]
    public BeatmapExtended[] Beatmaps { get; init; } = Array.Empty<BeatmapExtended>();
    
    [JsonPropertyName("last_updated")]
    public required DateTimeOffset LastUpdated { get; init; }
    
    [JsonPropertyName("tags")]
    public required string Tags { get; init; }
    
    [JsonPropertyName("ranked")]
    public required int Ranked { get; init; }
    
    [JsonPropertyName("ranked_date")]
    public DateTimeOffset? RankedAt { get; init; }
    
    [JsonPropertyName("genre")]
    public required NamedEntity Genre { get; init; }
    
    [JsonPropertyName("language")]
    public required NamedEntity Language { get; init; }
}