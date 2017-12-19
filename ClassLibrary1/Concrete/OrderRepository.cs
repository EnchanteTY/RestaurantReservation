using RestaurantReservation.BL.Data;
using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RestaurantReservation.BL.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private ReservationDbContext _context;

        public OrderRepository()
        {
            _context = new ReservationDbContext();
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Order> Orders { get { return _context.Orders.Include(o => o.OrderLines).ToList(); } }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Include(o => o.OrderLines).SingleOrDefault(o => o.OrderID == id);
        }

        public List<Order> GetOrderByUserId(string userId)
        {
            return _context.Orders.Include(o => o.OrderLines).
                Where(o => o.UserID == userId && o.MealDate > DateTime.Now).ToList();
        }
    }
}
