using System.ComponentModel.DataAnnotations;

namespace Sushi.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        [Display(Name = "Menu item name")]
        public string MenuItemName { get; set; }

        // public bool isChecked { get; set; }

        [Display(Name = "Menu item price")]
        public double MenuItemPrice { get; set; }
        public string UserId { get; set; } // Foreign Key
        public virtual ApplicationUser User { get; set; }
    }
}
