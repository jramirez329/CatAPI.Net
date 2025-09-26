using System.Text.Json.Serialization;

namespace CatApiClient.Models;

/// <summary>
/// Represents a vote on an image.
/// </summary>
public sealed class Vote
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("image_id")]
    public string? ImageId { get; set; }

    [JsonPropertyName("sub_id")]
    public string? SubId { get; set; }

    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("image")]
    public Image? Image { get; set; }
}
