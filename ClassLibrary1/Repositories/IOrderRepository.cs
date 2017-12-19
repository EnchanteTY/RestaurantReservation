using RestaurantReservation.BL.Entities;
using System.Collections.Generic;

namespace RestaurantReservation.BL.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void Save();
        List<Order> Orders { get; }
        Order GetOrderById(int id);
        List<Order> GetOrderByUserId(string userId);
    }
}
