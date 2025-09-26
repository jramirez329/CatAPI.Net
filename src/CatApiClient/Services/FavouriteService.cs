using CatApiClient.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace CatApiClient.Services;

public class FavouriteService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _jsonOptions;

    public FavouriteService(HttpClient http, JsonSerializerOptions jsonOptions)
    {
        _http = http;
        _jsonOptions = jsonOptions;
    }

    public async Task<IReadOnlyList<Favourite>> GetFavouritesAsync(int limit = 100, int page = 0, CancellationToken cancellationToken = default)
    {
        var url = $"/favourites?limit={limit}&page={page}";
        var resp = await _http.GetAsync(url, cancellationToken).ConfigureAwait(false);
        resp.EnsureSuccessStatusCode();
        var stream = await resp.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        var list = await JsonSerializer.DeserializeAsync<List<Favourite>>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false);
        return list ?? new List<Favourite>();
    }

    public async Task<FavouriteAddResponse> AddFavouriteAsync(string imageId, string? subId = null, CancellationToken cancellationToken = default)
    {
        var payload = new { image_id = imageId, sub_id = subId };
        var resp = await _http.PostAsJsonAsync("/favourites", payload, cancellationToken).ConfigureAwait(false);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<FavouriteAddResponse>(_jsonOptions, cancellationToken).ConfigureAwait(false)
            ?? throw new InvalidOperationException("Empty favourites response");
    }

    public async Task DeleteFavouriteAsync(string favouriteId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(favouriteId)) throw new ArgumentNullException(nameof(favouriteId));
        var resp = await _http.DeleteAsync($"/favourites/{Uri.EscapeDataString(favouriteId)}", cancellationToken).ConfigureAwait(false);
        resp.EnsureSuccessStatusCode();
    }
}
