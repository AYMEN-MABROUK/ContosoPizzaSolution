using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

namespace contoso_pizza_backend.Tests
{
    [Collection("Database")]
    public class ContosoPizzaWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly DbFixture _dbFixture;

        public ContosoPizzaWebApplicationFactory(DbFixture dbFixture)
            => _dbFixture = dbFixture;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            //builder.ConfigureServices(services =>
            //{
            //    // Remove the app's BlogDbContext registration.
            //    var descriptor = services.SingleOrDefault(
            //        d => d.ServiceType ==
            //            typeof(DbContextOptions<BlogDbContext>));

            //    if (descriptor is object)
            //        services.Remove(descriptor);

            //    services.AddDbContext<BlogDbContext>(options =>
            //    {
            //        // uses the connection string from the fixture
            //        options.UseSqlServer(_dbFixture.ConnString);
            //    });
            //})
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:DefaultConnection", _dbFixture.ConnString)
                });
            });
        }
    }
}