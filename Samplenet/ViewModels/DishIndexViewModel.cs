using RestaurantReservation.BL.Entities;
using System.Collections.Generic;

namespace RestaurantReservation.WebUI.ViewModels
{
    public class DishIndexViewModel
    {
        public Cart Cart { get; set; }
        public List<CartLine> CartLines { get; set; }
        public string ReturnUrl { get; set; }


    }
}