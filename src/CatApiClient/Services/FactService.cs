using CatApiClient.Models;
using System.Net.Http;
using System.Text.Json;

namespace CatApiClient.Services;

public class FactService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _jsonOptions;

    public FactService(HttpClient http, JsonSerializerOptions jsonOptions)
    {
        _http = http;
        _jsonOptions = jsonOptions;
    }

    public async Task<IReadOnlyList<Fact>> GetFactsAsync(int limit = 1, int page = 0, CancellationToken cancellationToken = default)
    {
        var url = $"/facts?limit={limit}&page={page}";
        var resp = await _http.GetAsync(url, cancellationToken).ConfigureAwait(false);
        resp.EnsureSuccessStatusCode();
        var stream = await resp.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        var list = await JsonSerializer.DeserializeAsync<List<Fact>>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false);
        return list ?? new List<Fact>();
    }
}
