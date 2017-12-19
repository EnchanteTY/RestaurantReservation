namespace RestaurantReservation.BL.Entities
{
    public class DishImageMapping
    {
        public int ID { get; set; }
        public int ImageNumber { get; set; }
        public int DishID { get; set; }
        public int DishImageID { get; set; }
        public virtual Dish Dish { get; set; }
        public virtual DishImage DishImage { get; set; }
    }
}
