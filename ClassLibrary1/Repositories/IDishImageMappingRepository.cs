using RestaurantReservation.BL.Entities;
using System.Collections.Generic;

namespace RestaurantReservation.BL.Repositories
{
    public interface IDishImageMappingRepository
    {
        IEnumerable<DishImageMapping> DishImageMappings { get; }

        void Remove(DishImageMapping mapping);

        void Add(DishImageMapping mapping);

        void Save();

        ICollection<DishImageMapping> GetMappingByDishId(int id);


        DishImageMapping GetMappingByDishIdAndImageNumber(int id, int imageNumber);
    }
}
