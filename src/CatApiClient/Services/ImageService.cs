using CatApiClient.Models;
using System.Net.Http;
using System.Text.Json;

namespace CatApiClient.Services;

public class ImageService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _jsonOptions;

    public ImageService(HttpClient http, JsonSerializerOptions jsonOptions)
    {
        _http = http;
        _jsonOptions = jsonOptions;
    }

    public async Task<IReadOnlyList<Image>> SearchImagesAsync(int limit = 1, int page = 0, string? size = null, string? mimeTypes = null, bool? hasBreeds = null, string? order = null, CancellationToken cancellationToken = default)
    {
        var query = new List<string>();
        query.Add($"limit={limit}");
        query.Add($"page={page}");
        if (!string.IsNullOrWhiteSpace(size)) query.Add($"size={Uri.EscapeDataString(size)}");
        if (!string.IsNullOrWhiteSpace(mimeTypes)) query.Add($"mime_types={Uri.EscapeDataString(mimeTypes)}");
        if (hasBreeds.HasValue) query.Add($"has_breeds={hasBreeds.Value.ToString().ToLowerInvariant()}");
        if (!string.IsNullOrWhiteSpace(order)) query.Add($"order={Uri.EscapeDataString(order)}");
        var url = "/images/search" + (query.Count > 0 ? "?" + string.Join("&", query) : string.Empty);
        var resp = await _http.GetAsync(url, cancellationToken).ConfigureAwait(false);
        resp.EnsureSuccessStatusCode();
        var stream = await resp.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        var list = await JsonSerializer.DeserializeAsync<List<Image>>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false);
        return list ?? new List<Image>();
    }
}
