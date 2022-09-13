using System.ComponentModel.DataAnnotations;

namespace Sushi.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        [Display(Name = "Menu item name")]
        public string MenuItemName { get; set; }

        [Display(Name = "Menu item price")]
        public int MenuItemPrice { get; set; }
        public string UserId { get; set; } // Foreign Key
        public virtual ApplicationUser User { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
