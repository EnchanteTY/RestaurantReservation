using System;
using System.Collections.Generic;

namespace RestaurantReservation.BL.Entities
{
    public class ServeList
    {

        public int ServeListId { get; set; }
        public DateTime Date { get; set; }
        public MealTime Time { get; set; }
        public int AccumulatedTableOrdered { get; set; }
        public virtual List<Order> OrderOnDateTime { get; set; }

        public void CreateOrder(Order order)
        {

        }

        public void AssignOrderWithTable(int tableOrded, Order order)
        {
            for (int i = 0; i < tableOrded; i++)
            {
                OrderOnDateTime.Add(order);
            }

        }

        public int[] TableWithOrderId = new int[10];

        public int[] AssignTable(int tableOrdered, int orderId)
        {
            int[] tableWithOrderId = new int[10];
            for (int i = AccumulatedTableOrdered; i < tableOrdered + AccumulatedTableOrdered; i++)
            {
                tableWithOrderId[i] = orderId;
            }

            return tableWithOrderId;
        }



    }
}
