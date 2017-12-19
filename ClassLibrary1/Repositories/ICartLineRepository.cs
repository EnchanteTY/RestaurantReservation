using RestaurantReservation.BL.Entities;
using System.Collections.Generic;

namespace RestaurantReservation.BL.Repositories
{
    public interface ICartLineRepository
    {
        CartLine GetCartLineByDishId(int id, string CartID);

        List<CartLine> GetCartLinesByCartId(string CartID);
        void Add(CartLine line);

        void Save();

        void Remove(CartLine line);
    }
}
