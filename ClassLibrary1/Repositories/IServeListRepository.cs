using RestaurantReservation.BL.Entities;
using System;
using System.Collections.Generic;

namespace RestaurantReservation.BL.Repositories
{
    public interface IServeListRepository
    {

        ServeList GetServeListByDateTime(DateTime Date, MealTime Time);

        ServeList GetServeListByDate(DateTime Date);

        ServeList GetServeListById(int id);

        void Add(ServeList list);

        void Save(Order order);

        List<ServeList> ServeLists { get; }

        List<ServeList> GetPendingServeLists();

    }
}
