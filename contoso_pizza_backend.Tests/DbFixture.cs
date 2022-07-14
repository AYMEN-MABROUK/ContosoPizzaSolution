using contoso_pizza_backend.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace contoso_pizza_backend.Tests
{
    /// <summary>
    /// A collection fixture that is responsible for creating and dropping the database
    /// https://xunit.net/docs/shared-context
    /// </summary>
    public class DbFixture : IDisposable
    {
        private readonly ContosoPizzaContext _dbContext;
        public readonly string ContosoPizzaDbName = $"Blog-{Guid.NewGuid()}";
        public readonly string ConnString;
        
        private bool _disposed;

        public DbFixture()
        {
            ConnString = $"Server=inDockerHost;Port=5433;Database={ContosoPizzaDbName};User Id=postgres;Password=admin;";
            
            var builder = new DbContextOptionsBuilder<ContosoPizzaContext>();

            builder.UseNpgsql(ConnString);
            _dbContext = new ContosoPizzaContext(builder.Options);

            _dbContext.Database.Migrate();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // remove the temp db from the server once all tests are done
                    _dbContext.Database.EnsureDeleted();
                }

                _disposed = true;
            }
        }
    }

    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

}