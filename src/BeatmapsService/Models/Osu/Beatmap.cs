using System.Text.Json.Serialization;

namespace BeatmapsService.Models.Osu;

public class Beatmap : BeatmapBase
{
    [JsonPropertyName("beatmapset")]
    public Beatmapset? Beatmapset { get; init; }
}