using System.Text.Json.Serialization;

namespace BeatmapsService.Models.Osu;

public class BeatmapExtended : BeatmapBase
{
    [JsonPropertyName("beatmapset")]
    public Beatmapset? Beatmapset { get; init; }

    [JsonPropertyName("accuracy")]
    public required decimal OverallDifficulty { get; init; }
    
    [JsonPropertyName("ar")]
    public required decimal ApproachRate { get; init; }
    
    [JsonPropertyName("bpm")]
    public decimal? Bpm { get; init; }

    [JsonPropertyName("convert")]
    public required bool Convert { get; init; }
    
    [JsonPropertyName("count_circles")]
    public required int CountCircles { get; init; }
    
    [JsonPropertyName("count_sliders")]
    public required int CountSliders { get; init; }
    
    [JsonPropertyName("count_spinners")]
    public required int CountSpinners { get; init; }
    
    [JsonPropertyName("cs")]
    public required decimal CircleSize { get; init; }
    
    [JsonPropertyName("deleted_at")]
    public DateTimeOffset? DeletedAt { get; init; }
    
    [JsonPropertyName("drain")]
    public required decimal HealthPoints { get; init; }
    
    [JsonPropertyName("hit_length")]
    public required int HitLength { get; init; }
    
    [JsonPropertyName("is_scoreable")]
    public required bool IsScoreable { get; init; }
    
    [JsonPropertyName("last_updated")]
    public required DateTimeOffset LastUpdated { get; init; }
    
    [JsonPropertyName("mode_int")]
    public required int ModeInt { get; init; }
    
    [JsonPropertyName("passcount")]
    public required int PassCount { get; init; }
    
    [JsonPropertyName("playcount")]
    public required int PlayCount { get; init; }
    
    // TODO: enum
    [JsonPropertyName("ranked")]
    public required int Ranked { get; init; }
    
    [JsonPropertyName("url")]
    public required string Url { get; init; }
    
    // TODO: figure out if these makes more sense in extended or not
    [JsonPropertyName("max_combo")]
    public int? MaxCombo { get; init; }
    
    [JsonPropertyName("checksum")]
    public required string Checksum { get; init; }
}