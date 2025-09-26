using System.Text.Json.Serialization;

namespace CatApiClient.Models;

/// <summary>
/// Represents a fact about a breed or cat.
/// </summary>
public sealed class Fact
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("fact")]
    public string? Text { get; set; }

    [JsonPropertyName("breed_id")]
    public string? BreedId { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
