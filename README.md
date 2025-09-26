# CatAPI.Net

## Overview

CatAPI.Net is a .NET 9 SDK for TheCatAPI, providing strongly-typed models and service classes for interacting with cat images, breeds, favourites, votes, and facts. Includes a sample console app and unit tests.

## Features
- .NET 9 class library: `CatApiClient`
- Models for all major API objects (Image, Breed, Favourite, Vote, Fact)
- Service classes for API endpoints (ImageService, BreedService, etc.)
- Sample console app: `CatApiClient.Sample`
- xUnit unit tests for models and services

## Getting Started

### Build and Run Sample

```powershell
cd src\CatApiClient
dotnet build
cd ..\..\samples\CatApiClient.Sample
dotnet run
```

Optionally set your API key in the environment variable `THECATAPI_KEY` to include it in requests.

### Usage Example

```csharp
using CatApiClient;
using CatApiClient.Services;

var http = new HttpClient { BaseAddress = new Uri("https://api.thecatapi.com/v1") };
var client = new TheCatApiClient(http);
var images = await client.ImageService.SearchImagesAsync(limit: 2);
```

## Testing

Run all unit tests:

```powershell
cd tests
dotnet test
```

## License

MIT