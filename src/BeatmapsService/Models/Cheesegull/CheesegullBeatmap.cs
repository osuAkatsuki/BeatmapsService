using System.Text.Json.Serialization;

namespace BeatmapsService.Models.Cheesegull;

public class CheesegullBeatmap
{
    [JsonPropertyName("BeatmapID")]
    public required int Id { get; init; }
    
    [JsonPropertyName("ParentSetID")]
    public required int BeatmapsetId { get; init; }
    
    [JsonPropertyName("DiffName")]
    public required string Version { get; init; }
    
    [JsonPropertyName("FileMD5")]
    public required string Checksum { get; init; }
    
    [JsonPropertyName("Mode")]
    public required int Mode { get; init; }
    
    [JsonPropertyName("BPM")]
    public required decimal Bpm { get; init; }
    
    [JsonPropertyName("AR")]
    public required decimal ApproachRate { get; init; }
    
    [JsonPropertyName("OD")]
    public required decimal OverallDifficulty { get; init; }
    
    [JsonPropertyName("CS")]
    public required decimal CircleSize { get; init; }
    
    [JsonPropertyName("HP")]
    public required decimal HealthPoints { get; init; }
    
    [JsonPropertyName("TotalLength")]
    public required int TotalLength { get; init; }
    
    [JsonPropertyName("HitLength")]
    public required int HitLength { get; init; }
    
    [JsonPropertyName("Playcount")]
    public required int PlayCount { get; init; }
    
    [JsonPropertyName("Passcount")]
    public required int PassCount { get; init; }
    
    [JsonPropertyName("MaxCombo")]
    public required int MaxCombo { get; init; }
    
    [JsonPropertyName("DifficultyRating")]
    public required decimal DifficultyRating { get; init; }
}