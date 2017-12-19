using System.Collections.Generic;

namespace RestaurantReservation.BL.Entities
{
    public class Dish
    {
        public int DishID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StandardPrice { get; set; }
        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<DishImageMapping> DishImageMappings { get; set; }



    }
}
