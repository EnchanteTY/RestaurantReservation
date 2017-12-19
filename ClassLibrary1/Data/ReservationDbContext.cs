using Microsoft.AspNet.Identity.EntityFramework;
using RestaurantReservation.BL.Entities;
using System.Data.Entity;

namespace RestaurantReservation.BL.Data
{

    public class ReservationDbContext : IdentityDbContext<ApplicationUser>
    {



        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<DishImage> DishImages { get; set; }

        public DbSet<DishImageMapping> DishImageMappings { get; set; }

        public DbSet<CartLine> CartLines { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        public DbSet<ServeList> ServeLists { get; set; }


        public ReservationDbContext()
          : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ReservationDbContext Create()
        {
            return new ReservationDbContext();
        }


    }



}






