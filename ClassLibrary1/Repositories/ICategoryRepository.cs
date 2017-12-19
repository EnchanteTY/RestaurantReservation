using RestaurantReservation.BL.Entities;
using System.Collections.Generic;

namespace RestaurantReservation.BL.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
