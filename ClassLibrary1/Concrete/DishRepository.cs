using RestaurantReservation.BL.Data;
using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RestaurantReservation.BL.Concrete

{
    public class DishRepository : IDishRepository
    {
        private ReservationDbContext _context;

        public DishRepository()
        {
            _context = new ReservationDbContext();
        }

        public IEnumerable<Dish> Dishes { get { return _context.Dishes; } }

        public IEnumerable<Dish> GetDishesbyCategory(string category)
        {
            return _context.Dishes
                .Include(d => d.Category)
                .Where(d => d.Category.Name == category)
                .ToList();
        }

        public Dish GetDishbyId(int id)
        {
            return _context.Dishes
                .FirstOrDefault(d => d.DishID == id);
        }



        public void AddDish(Dish dish)
        {
            _context.Dishes.Add(dish);
            _context.SaveChanges();

        }

        public void Save()
        {

            _context.SaveChanges();
        }

        public void Remove(Dish dish)
        {
            _context.Dishes.Remove(dish);
        }

        public IEnumerable<Dish> DishesIncludeDishMapping
        {
            get
            { return _context.Dishes.Include(d => d.DishImageMappings); }
        }

    }
}
