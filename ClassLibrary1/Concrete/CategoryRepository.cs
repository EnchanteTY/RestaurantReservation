using RestaurantReservation.BL.Data;
using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;
using System.Collections.Generic;

namespace RestaurantReservation.BL.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private ReservationDbContext _context;

        public CategoryRepository()
        {
            _context = new ReservationDbContext();
        }


        public IEnumerable<Category> Categories { get { return _context.Categories; } }

    }
}
