using System.Text.Json.Serialization;

namespace BeatmapsService.Models.Osu;

public class Beatmapset : BeatmapsetBase
{
    [JsonPropertyName("beatmaps")]
    public Beatmap[] Beatmaps { get; init; } = Array.Empty<Beatmap>();
}