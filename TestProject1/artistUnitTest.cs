using myAPI.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject1
{
    public class artistUnitTest
    {
        private readonly string[] args;

        [Test]
        public void putArtist()
        {
            //Arrange
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            var app = builder.Build();
            ILogger <ArtistController> logger = app.Services.GetRequiredService<ILogger<ArtistController>>();
            var test = new ArtistController(logger);

            //Act
            var count = test.Get().Count();
            var actionResult = test.Post("Jane", 13, "Rock");
            //Assert
            Assert.AreEqual(count, test.Get().Count());

        }

        [Test]
        public void deleteArtist()
        {
            //Arrange
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            var app = builder.Build();
            ILogger<ArtistController> logger = app.Services.GetRequiredService<ILogger<ArtistController>>();
            var test = new ArtistController(logger);

            //Act
            var count = test.Get().Count();
            var actionResult = test.DemonstrateDelete(test.Get().ElementAt(0).Name);
            //Assert
            Assert.AreEqual(count, test.Get().Count());

        }
    }
}
