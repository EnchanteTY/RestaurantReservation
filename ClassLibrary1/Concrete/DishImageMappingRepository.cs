using RestaurantReservation.BL.Data;
using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantReservation.BL.Concrete
{
    public class DishImageMappingRepository : IDishImageMappingRepository
    {
        private ReservationDbContext _context;

        public DishImageMappingRepository()
        {
            _context = new ReservationDbContext();
        }


        public IEnumerable<DishImageMapping> DishImageMappings { get { return _context.DishImageMappings; } }

        public void Remove(DishImageMapping mapping)
        {
            _context.DishImageMappings.Remove(mapping);
        }

        public void Add(DishImageMapping mapping)
        {
            _context.DishImageMappings.Add(mapping);

        }



        public void Save()
        {
            _context.SaveChanges();
        }

        public ICollection<DishImageMapping> GetMappingByDishId(int id)
        {
            List<DishImageMapping> mappings = new List<DishImageMapping>();
            mappings = _context.DishImageMappings.Where(m => m.DishID == id).ToList();
            return mappings;
        }

        public DishImageMapping GetMappingByDishIdAndImageNumber(int id, int imageNumber)
        {
            var mapping = _context.DishImageMappings
               .FirstOrDefault(m => m.DishID == id && m.ImageNumber == imageNumber);

            return mapping;
        }
    }
}
