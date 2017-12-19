using RestaurantReservation.BL.Data;
using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantReservation.BL.Concrete
{
    public class ServeListRepository : IServeListRepository
    {
        private ReservationDbContext _context;
        public ServeListRepository()
        {
            _context = new ReservationDbContext();
        }

        public ServeList GetServeListByDateTime(DateTime date, MealTime time)
        {
            return _context.ServeLists.SingleOrDefault(s => s.Date == date && s.Time == time);
        }

        public ServeList GetServeListByDate(DateTime date)
        {
            return _context.ServeLists.SingleOrDefault(s => s.Date == date);
        }

        public ServeList GetServeListById(int id)
        {
            return _context.ServeLists.SingleOrDefault(s => s.ServeListId == id);
        }

        public void Add(ServeList list)
        {
            _context.ServeLists.Add(list);
            _context.SaveChanges();
        }

        public void Save(Order order)
        {

            _context.Entry(order).State = System.Data.Entity.EntityState.Detached;

            _context.SaveChanges();
        }

        public List<ServeList> ServeLists { get { return _context.ServeLists.ToList(); } }

        public List<ServeList> GetPendingServeLists()
        {
            return _context.ServeLists.Where(s => s.Date > DateTime.Now).ToList();
        }
    }
}
