using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace Shop.Infrastructure.Persistent.Ef
{
    public class ShopContextFactory : IDesignTimeDbContextFactory<ShopContext>
    {
        public ShopContext CreateDbContext(string[] args)
        {
            // محل خواندن تنظیمات (appsettings.json)
            var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
            .Build();


            // خواندن Connection String به نام DefaultConnection
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // ساخت options
            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ShopContext(optionsBuilder.Options);
        }
    }
}
