using System.Text.Json.Serialization;

namespace BeatmapsService.Models.Osu;

public class BeatmapsetBase
{
    [JsonPropertyName("artist")]
    public required string Artist { get; init; }
    
    [JsonPropertyName("artist_unicode")]
    public required string ArtistUnicode { get; init; }

    // TODO: add `covers`

    [JsonPropertyName("creator")]
    public required string Creator { get; init; }
    
    [JsonPropertyName("favourite_count")]
    public required int FavouriteCount { get; init; }
    
    [JsonPropertyName("id")]
    public required int Id { get; init; }
    
    [JsonPropertyName("nsfw")]
    public required bool Nsfw { get; init; }
    
    [JsonPropertyName("offset")]
    public required int Offset { get; init; }
    
    [JsonPropertyName("play_count")]
    public required int PlayCount { get; init; }
    
    [JsonPropertyName("preview_url")]
    public required string PreviewUrl { get; init; }
    
    [JsonPropertyName("source")]
    public required string Source { get; init; }
    
    [JsonPropertyName("status")]
    public required string Status { get; init; }
    
    [JsonPropertyName("spotlight")]
    public required bool Spotlight { get; init; }
    
    [JsonPropertyName("title")]
    public required string Title { get; init; }
    
    [JsonPropertyName("title_unicode")]
    public required string TitleUnicode { get; init; }
    
    [JsonPropertyName("user_id")]
    public required int UserId { get; init; }
    
    [JsonPropertyName("video")]
    public required bool Video { get; init; }
}