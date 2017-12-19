using RestaurantReservation.BL;
using RestaurantReservation.BL.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.WebUI.ViewModels
{
    public class CheckoutFormViewModel
    {
        public int OrderID { get; set; }
        public Salutation Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        [MealDateValidation]
        [DataType(DataType.Date)]
        public DateTime MealDate { get; set; }


        public MealTime MealTime { get; set; }
        public int TableOrdered { get; set; }
        public string ExtraRequest { get; set; }
    }
}