using RestaurantReservation.BL.Entities;

namespace RestaurantReservation.BL.Repositories
{
    public interface IOrderLineRepository
    {
        void Add(OrderLine line);
        void Save();
    }
}
