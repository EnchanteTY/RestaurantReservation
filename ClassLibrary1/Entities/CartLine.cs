using System;

namespace RestaurantReservation.BL.Entities
{
    public class CartLine
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public DateTime DateCreated { get; set; }
        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }
        public int Table { get; set; }
        public DishSize DishSize { get; set; }
        public decimal Subtotal { get; set; }
        public decimal CalculatePriceForDish(int table, DishSize dishSize, decimal standardPrice)
        {
            decimal dishPriceForSelectedSize = 0;
            switch (dishSize)
            {
                case DishSize.Small:
                    dishPriceForSelectedSize = standardPrice * 1 / 3;
                    break;

                case DishSize.Medium:
                    dishPriceForSelectedSize = standardPrice * 2 / 3;
                    break;

                case DishSize.Standard:
                    dishPriceForSelectedSize = standardPrice;
                    break;

                case DishSize.ExtraLarge:
                    dishPriceForSelectedSize = standardPrice * 4 / 3;
                    break;



            }
            decimal priceForDish = dishPriceForSelectedSize * table;
            return priceForDish;

        }
    }
}
