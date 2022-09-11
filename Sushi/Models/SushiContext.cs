using Microsoft.EntityFrameworkCore;
using Sushi.Models;

namespace Sushi.Models
{
    public class SushiContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        public SushiContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
