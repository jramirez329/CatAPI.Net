using System.Text.Json.Serialization;

namespace CatApiClient.Models;

/// <summary>
/// Represents a cat image returned by TheCatAPI.
/// </summary>
public sealed class Image
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("width")]
    public int? Width { get; set; }

    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("mime_type")]
    public string? MimeType { get; set; }

    [JsonPropertyName("breeds")]
    public List<Breed>? Breeds { get; set; }
}
