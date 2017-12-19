using RestaurantReservation.BL.Entities;
using System.Collections.Generic;

namespace RestaurantReservation.WebUI.ViewModels
{
    public class DishCatalogueViewModel
    {
        public IEnumerable<Dish> Dishes { get; set; }

        public string CurrentCattegory { get; set; }
    }
}