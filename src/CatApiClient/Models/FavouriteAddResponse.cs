using System.Text.Json.Serialization;

namespace CatApiClient.Models;

/// <summary>
/// Response for adding a favourite.
/// </summary>
public sealed class FavouriteAddResponse
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }
}
