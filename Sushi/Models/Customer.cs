using System.Collections.Generic;

namespace Sushi.Models
{
    public class Customer
    {
        public Customer()
        {
            this.MenuItems = new HashSet<MenuItem>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
