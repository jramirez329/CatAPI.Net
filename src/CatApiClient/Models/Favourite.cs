using System.Text.Json.Serialization;

namespace CatApiClient.Models;

/// <summary>
/// Represents a favourite image for a user.
/// </summary>
public sealed class Favourite
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    [JsonPropertyName("image_id")]
    public string? ImageId { get; set; }

    [JsonPropertyName("sub_id")]
    public string? SubId { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("image")]
    public Image? Image { get; set; }
}
