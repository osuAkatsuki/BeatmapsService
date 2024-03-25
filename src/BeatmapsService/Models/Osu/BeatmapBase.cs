using System.Text.Json.Serialization;

namespace BeatmapsService.Models.Osu;

// TODO: enums for stuff like mode, status
public class BeatmapBase
{
    [JsonPropertyName("id")]
    public required int Id { get; init; }
    
    [JsonPropertyName("beatmapset_id")]
    public required int BeatmapsetId { get; init; }
    
    [JsonPropertyName("mode")]
    public required string Mode { get; init; }
    
    [JsonPropertyName("difficulty_rating")]
    public required decimal DifficultyRating { get; init; }
    
    [JsonPropertyName("status")]
    public required string Status { get; init; }
    
    [JsonPropertyName("total_length")]
    public required int TotalLength { get; init; }
    
    [JsonPropertyName("user_id")]
    public required int UserId { get; init; }
    
    [JsonPropertyName("version")]
    public required string Version { get; init; }
}