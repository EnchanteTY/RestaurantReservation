using RestaurantReservation.BL.Data;
using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RestaurantReservation.BL.Concrete
{
    public class CartLineRepository : ICartLineRepository
    {
        private ReservationDbContext _context;

        public CartLineRepository()
        {
            _context = new ReservationDbContext();
        }

        public CartLine GetCartLineByDishId(int id, string CartID)
        {
            return _context.CartLines.Include(l => l.Dish).SingleOrDefault(l => l.Dish.DishID == id && l.CartId == CartID);
        }

        public CartLine GetCartLineByUserName(string name)
        {
            return _context.CartLines.Single(l => l.CartId == name);
        }

        
        public List<CartLine> GetCartLinesByCartId(string CartID)
        {
            return _context.CartLines.Include(l => l.Dish).Where(l => l.CartId == CartID).ToList();
        }

        public void Add(CartLine line)
        {
            _context.CartLines.Add(line);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Remove(CartLine line)
        {
            _context.CartLines.Remove(line);
            _context.SaveChanges();
        }

    }
}
