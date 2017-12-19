using RestaurantReservation.BL.Data;
using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;

namespace RestaurantReservation.BL.Concrete
{
    public class OrderLineRepository : IOrderLineRepository
    {
        private ReservationDbContext _context;

        public OrderLineRepository()
        {
            _context = new ReservationDbContext();
        }

        public void Add(OrderLine line)
        {
            _context.OrderLines.Add(line);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
