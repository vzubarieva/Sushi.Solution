using System.Collections.Generic;

namespace Sushi.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        // snapshot properties from menuItem
        public double MenuItemPrice { get; set; }
        public string MenuItemName { get; set; }
        public int Count { get; set; }

        // link to current menuItem
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }

        // link to order
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
