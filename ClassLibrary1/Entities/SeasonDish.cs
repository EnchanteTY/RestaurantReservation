using System;

namespace RestaurantReservation.BL.Entities
{
    public class SeasonDish : Dish
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Festival { get; set; }
    }
}
