using CatApiClient.Services;
using Xunit;
using System.Threading.Tasks;

namespace CatApiClient.Tests.Services
{
    public class BreedServiceTests
    {
        [Fact]
        public void BreedService_CanBeConstructed()
        {
            var service = new BreedService(null!, new System.Text.Json.JsonSerializerOptions());
            Assert.NotNull(service);
        }
    }

    public class ImageServiceTests
    {
        [Fact]
        public void ImageService_CanBeConstructed()
        {
            var service = new ImageService(null!, new System.Text.Json.JsonSerializerOptions());
            Assert.NotNull(service);
        }
    }

    public class FavouriteServiceTests
    {
        [Fact]
        public void FavouriteService_CanBeConstructed()
        {
            var service = new FavouriteService(null!, new System.Text.Json.JsonSerializerOptions());
            Assert.NotNull(service);
        }
    }

    public class VoteServiceTests
    {
        [Fact]
        public void VoteService_CanBeConstructed()
        {
            var service = new VoteService(null!, new System.Text.Json.JsonSerializerOptions());
            Assert.NotNull(service);
        }
    }

    public class FactServiceTests
    {
        [Fact]
        public void FactService_CanBeConstructed()
        {
            var service = new FactService(null!, new System.Text.Json.JsonSerializerOptions());
            Assert.NotNull(service);
        }
    }
}
