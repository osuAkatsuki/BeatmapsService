using System.Text.Json.Serialization;

namespace BeatmapsService.Models.Osu;

public class NamedEntity
{
    [JsonPropertyName("id")]
    public required int Id { get; init; }
    
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}