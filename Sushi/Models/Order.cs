using System.Collections.Generic;

namespace Sushi.Models
{
  public class Order
  {
    public Order()
    {
        this.OrderItems = new HashSet<OrderItem>();
    }

    public int OrderId { get; set; }
    public double subTotalPrice { get; set; }
    public double TotalPrice { get; set; }
    public int ItemsCount { get; set; }
    public string UserId { get; set; }

    // public virtual ApplicationUser User { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
  }
}
