using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sushi.Models
{
    public class Customer
    {
        public Customer()
        {
            this.MenuItems = new HashSet<MenuItem>();
        }

        public int CustomerId { get; set; }

        [Display(Name = "Customer name")]
        public string CustomerName { get; set; }
        public string UserId { get; set; } // Foreign Key

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
