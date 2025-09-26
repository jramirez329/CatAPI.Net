using CatApiClient.Models;
using System.Net.Http;
using System.Text.Json;

namespace CatApiClient.Services;

public class BreedService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _jsonOptions;

    public BreedService(HttpClient http, JsonSerializerOptions jsonOptions)
    {
        _http = http;
        _jsonOptions = jsonOptions;
    }

    public async Task<IReadOnlyList<Breed>> GetBreedsAsync(int limit = 100, int page = 0, CancellationToken cancellationToken = default)
    {
        var url = $"/breeds?limit={limit}&page={page}";
        var resp = await _http.GetAsync(url, cancellationToken).ConfigureAwait(false);
        resp.EnsureSuccessStatusCode();
        var stream = await resp.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        var list = await JsonSerializer.DeserializeAsync<List<Breed>>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false);
        return list ?? new List<Breed>();
    }
}
