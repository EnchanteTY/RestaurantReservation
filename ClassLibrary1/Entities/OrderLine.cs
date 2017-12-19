namespace RestaurantReservation.BL.Entities
{
    public class OrderLine
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int? DishID { get; set; }
        public int Table { get; set; }
        public DishSize DishSize { get; set; }
        public string DishName { get; set; }
        public decimal SubTotal { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Order Order { get; set; }
    }
}
