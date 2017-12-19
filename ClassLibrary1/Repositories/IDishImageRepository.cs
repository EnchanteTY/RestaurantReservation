using RestaurantReservation.BL.Entities;
using System.Collections.Generic;

namespace RestaurantReservation.BL.Repositories
{
    public interface IDishImageRepository
    {
        IEnumerable<DishImage> DishImages { get; }
        DishImage GetImageByKey(int key);
        void SaveImage(DishImage image);
    }
}
