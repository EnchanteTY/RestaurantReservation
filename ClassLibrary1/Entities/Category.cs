using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.BL.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
