using System.Text.Json.Serialization;

namespace CatApiClient.Models;

/// <summary>
/// Represents a cat breed returned by TheCatAPI.
/// </summary>
public sealed class Breed
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("origin")]
    public string? Origin { get; set; }
}
