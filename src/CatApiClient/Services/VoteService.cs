using CatApiClient.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace CatApiClient.Services;

public class VoteService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _jsonOptions;

    public VoteService(HttpClient http, JsonSerializerOptions jsonOptions)
    {
        _http = http;
        _jsonOptions = jsonOptions;
    }

    public async Task<IReadOnlyList<Vote>> GetVotesAsync(int limit = 100, int page = 0, CancellationToken cancellationToken = default)
    {
        var url = $"/votes?limit={limit}&page={page}";
        var resp = await _http.GetAsync(url, cancellationToken).ConfigureAwait(false);
        resp.EnsureSuccessStatusCode();
        var stream = await resp.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        var list = await JsonSerializer.DeserializeAsync<List<Vote>>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false);
        return list ?? new List<Vote>();
    }

    public async Task<VoteAddResponse> AddVoteAsync(string imageId, int value = 1, string? subId = null, CancellationToken cancellationToken = default)
    {
        var payload = new { image_id = imageId, value, sub_id = subId };
        var resp = await _http.PostAsJsonAsync("/votes", payload, cancellationToken).ConfigureAwait(false);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<VoteAddResponse>(_jsonOptions, cancellationToken).ConfigureAwait(false)
            ?? throw new InvalidOperationException("Empty votes response");
    }

    public async Task DeleteVoteAsync(string voteId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(voteId)) throw new ArgumentNullException(nameof(voteId));
        var resp = await _http.DeleteAsync($"/vote/{Uri.EscapeDataString(voteId)}", cancellationToken).ConfigureAwait(false);
        resp.EnsureSuccessStatusCode();
    }
}
