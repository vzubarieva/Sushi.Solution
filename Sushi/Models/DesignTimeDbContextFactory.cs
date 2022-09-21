using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Sushi.Models
{
  public class SushiContextFactory : IDesignTimeDbContextFactory<SushiContext>
  {
    SushiContext IDesignTimeDbContextFactory<SushiContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<SushiContext>();

      builder.UseMySql(
        configuration["ConnectionStrings:DefaultConnection"],
        ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"])
      );

      return new SushiContext(builder.Options);
    }
  }
}
