using RestaurantReservation.BL.Entities;
using System.Collections.Generic;

namespace RestaurantReservation.BL.Repositories
{
    public interface IDishRepository
    {
        IEnumerable<Dish> Dishes { get; }
        IEnumerable<Dish> GetDishesbyCategory(string category);
        Dish GetDishbyId(int id);
        void AddDish(Dish dish);
        void Save();
        void Remove(Dish dish);
        IEnumerable<Dish> DishesIncludeDishMapping { get; }


    }
}