using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.BL.Entities
{
    public class DishImage
    {
        public int ID { get; set; }

        [Display(Name = "File")]
        [StringLength(100)]
        [Index(IsUnique = true)]

        public string FileName { get; set; }

        public virtual ICollection<DishImageMapping> DishImageMappings { get; set; }
    }
}
