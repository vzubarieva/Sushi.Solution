using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sushi.Models;

namespace Sushi.Models
{
  public class SushiContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order> Orders { get; set; }

    public SushiContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder
      .Entity<MenuItem>()
      .HasData(
          new MenuItem
          {
              MenuItemId = 1,
              MenuItemName = "Chihiro's deluxe",
              MenuItemPrice = 45,
          },
          new MenuItem
          {
              MenuItemId = 2,
              MenuItemName = "Sushi special",
              MenuItemPrice = 27,
          },
          new MenuItem
          {
              MenuItemId = 3,
              MenuItemName = "Crazy salmon",
              MenuItemPrice = 22,
          },
          new MenuItem
          {
              MenuItemId = 4,
              MenuItemName = "Rainbow spider",
              MenuItemPrice = 19,
          },
          new MenuItem
          {
              MenuItemId = 5,
              MenuItemName = "Dragon roll",
              MenuItemPrice = 15,
          },
          new MenuItem
          {
              MenuItemId = 6,
              MenuItemName = "Gyouza",
              MenuItemPrice = 7,
          },
          new MenuItem
          {
              MenuItemId = 7,
              MenuItemName = "Soft-shell crab",
              MenuItemPrice = 11,
          },
          new MenuItem
          {
              MenuItemId = 8,
              MenuItemName = "Shrimp tempura",
              MenuItemPrice = 9,
          },
          new MenuItem
          {
              MenuItemId = 9,
              MenuItemName = "Fillet of magura",
              MenuItemPrice = 6,
          },
          new MenuItem
          {
              MenuItemId = 10,
              MenuItemName = "Fillet of sake",
              MenuItemPrice = 6,
          },
          new MenuItem
          {
              MenuItemId = 11,
              MenuItemName = "Fillet of madai",
              MenuItemPrice = 6,
          },
      new MenuItem
      {
          MenuItemId = 12,
          MenuItemName = "Fillet of tomago",
          MenuItemPrice = 6,
      },
      new MenuItem
      {
          MenuItemId = 13,
          MenuItemName = "Fillet of inari",
          MenuItemPrice = 6,
      },
      new MenuItem
      {
          MenuItemId = 14,
          MenuItemName = "Fillet of madai",
          MenuItemPrice = 6,
      },
      new MenuItem
      {
          MenuItemId = 15,
          MenuItemName = "Fillet of tomago",
          MenuItemPrice = 6,
      },
      new MenuItem
      {
          MenuItemId = 16,
          MenuItemName = "Fillet of suzuki",
          MenuItemPrice = 6,
      },
      new MenuItem
      {
          MenuItemId = 17,
          MenuItemName = "Fillet of unagi",
          MenuItemPrice = 6,
      },
      new MenuItem
      {
          MenuItemId = 18,
          MenuItemName = "Fillet of ebi",
          MenuItemPrice = 6,
      },
      new MenuItem
      {
          MenuItemId = 19,
          MenuItemName = "Fillet of ika",
          MenuItemPrice = 6,
      }
      );

    }
  }
}
