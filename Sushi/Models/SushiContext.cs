using Microsoft.EntityFrameworkCore;

namespace Sushi.Models
{
    public class SushiContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }

        public SushiContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
