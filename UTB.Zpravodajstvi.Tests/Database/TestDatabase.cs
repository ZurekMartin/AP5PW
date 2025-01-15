using Microsoft.EntityFrameworkCore;
using UTB.Zpravodajstvi.Infrastructure.Database;

namespace UTB.Zpravodajstvi.Tests.Database
{
    public static class TestDatabase
    {
        public static ZpravodajstviDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ZpravodajstviDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;

            return new ZpravodajstviDbContext(options);
        }
    }
} 