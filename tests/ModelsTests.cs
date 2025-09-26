
using CatApiClient.Models;
using Xunit;
using System.Collections.Generic;

namespace CatApiClient.Tests.Models
{
    public class BreedTests
    {
        [Fact]
        public void Breed_Properties_SetAndGet()
        {
            var breed = new Breed
            {
                Id = "abys",
                Name = "Abyssinian",
                Origin = "Egypt"
            };
            Assert.Equal("abys", breed.Id);
            Assert.Equal("Abyssinian", breed.Name);
            Assert.Equal("Egypt", breed.Origin);
        }
    }

    public class ImageTests
    {
        [Fact]
        public void Image_Properties_SetAndGet()
        {
            var image = new Image
            {
                Id = "img1",
                Url = "https://cat.com/img1.jpg",
                Width = 800,
                Height = 600,
                MimeType = "image/jpeg",
                Breeds = new List<Breed>()
            };
            Assert.Equal("img1", image.Id);
            Assert.Equal("https://cat.com/img1.jpg", image.Url);
            Assert.Equal(800, image.Width);
            Assert.Equal(600, image.Height);
            Assert.Equal("image/jpeg", image.MimeType);
            Assert.NotNull(image.Breeds);
        }
    }

    public class FavouriteTests
    {
        [Fact]
        public void Favourite_Properties_SetAndGet()
        {
            var fav = new Favourite
            {
                Id = 1,
                UserId = "user1",
                ImageId = "img1",
                SubId = "sub1",
                CreatedAt = "2025-09-25",
                Image = new Image { Id = "img1" }
            };
            Assert.Equal(1, fav.Id);
            Assert.Equal("user1", fav.UserId);
            Assert.Equal("img1", fav.ImageId);
            Assert.Equal("sub1", fav.SubId);
            Assert.Equal("2025-09-25", fav.CreatedAt);
            Assert.NotNull(fav.Image);
        }
    }

    public class VoteTests
    {
        [Fact]
        public void Vote_Properties_SetAndGet()
        {
            var vote = new Vote
            {
                Id = 2,
                ImageId = "img2",
                SubId = "sub2",
                Value = 1,
                CountryCode = "US",
                CreatedAt = "2025-09-25",
                Image = new Image { Id = "img2" }
            };
            Assert.Equal(2, vote.Id);
            Assert.Equal("img2", vote.ImageId);
            Assert.Equal("sub2", vote.SubId);
            Assert.Equal(1, vote.Value);
            Assert.Equal("US", vote.CountryCode);
            Assert.Equal("2025-09-25", vote.CreatedAt);
            Assert.NotNull(vote.Image);
        }
    }

    public class FactTests
    {
        [Fact]
        public void Fact_Properties_SetAndGet()
        {
            var fact = new Fact
            {
                Id = "f1",
                Text = "Cats sleep a lot.",
                BreedId = "abys",
                Title = "Cat Sleep"
            };
            Assert.Equal("f1", fact.Id);
            Assert.Equal("Cats sleep a lot.", fact.Text);
            Assert.Equal("abys", fact.BreedId);
            Assert.Equal("Cat Sleep", fact.Title);
        }
    }
}
