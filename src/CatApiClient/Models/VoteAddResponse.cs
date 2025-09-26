using System.Text.Json.Serialization;

namespace CatApiClient.Models;

/// <summary>
/// Response for adding a vote.
/// </summary>
public sealed class VoteAddResponse
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }
}
