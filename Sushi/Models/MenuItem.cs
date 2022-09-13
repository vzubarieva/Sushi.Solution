using System.ComponentModel.DataAnnotations;

namespace Sushi.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        [Display(Name = "Menu Item Name")]
        public string MenuItemName { get; set; }

        [Display(Name = "Menu Price")]
        public int MenuItemPrice { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
