using System.ComponentModel.DataAnnotations;

namespace Sushi.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        [Display(Name = "Menu item name")]
        public string MenuItemName { get; set; }

        [Display(Name = "Menu item price")]
        public double MenuItemPrice { get; set; }
    }
}
