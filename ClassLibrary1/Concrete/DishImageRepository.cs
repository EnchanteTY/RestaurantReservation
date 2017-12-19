using RestaurantReservation.BL.Data;
using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;
using System.Collections.Generic;

namespace RestaurantReservation.BL.Concrete
{

    public class DishImageRepository : IDishImageRepository
    {
        private ReservationDbContext _context;

        public DishImageRepository()
        {
            _context = new ReservationDbContext();
        }

        public IEnumerable<DishImage> DishImages { get { return _context.DishImages; } }

        public DishImage GetImageByKey(int key)
        {
            return _context.DishImages.Find(key);
        }

        public void SaveImage(DishImage image)
        {

            _context.DishImages.Add(image);
            _context.SaveChanges();
        }
    }
}
