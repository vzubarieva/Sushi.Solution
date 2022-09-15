using System.Collections.Generic;

namespace Sushi.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }

        // snapshot properties from menuItem
        public double MenuItemPrice { get; set; }
        public string MenuItemName { get; set; }

        // link to current menuItem
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
    }
}
