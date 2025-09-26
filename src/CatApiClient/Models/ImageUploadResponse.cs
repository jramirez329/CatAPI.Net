using System.Text.Json.Serialization;

namespace CatApiClient.Models;

/// <summary>
/// Response for uploading an image.
/// </summary>
public sealed class ImageUploadResponse
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("sub_id")]
    public string? SubId { get; set; }

    [JsonPropertyName("width")]
    public int? Width { get; set; }

    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("original_filename")]
    public string? OriginalFilename { get; set; }

    [JsonPropertyName("pending")]
    public int? Pending { get; set; }

    [JsonPropertyName("approved")]
    public int? Approved { get; set; }
}
