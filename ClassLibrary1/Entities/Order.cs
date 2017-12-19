using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.BL.Entities
{
    public class Order
    {
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }

        [Display(Name = "User")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "The salutation cannot be blank")]
        public Salutation Salutation { get; set; }

        [Required(ErrorMessage = "Your first name cannot be blank")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name cannot be blank")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Your phone number cannot be blank")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The date cannot be blank")]
        [MealDateValidation(ErrorMessage = "This date is full already")]
        [DataType(DataType.Date)]

        public DateTime MealDate { get; set; }

        [Required(ErrorMessage = "The time cannot be blank")]
        public MealTime MealTime { get; set; }

        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Time of Order")]

        public DateTime DateCreated { get; set; }

        public List<OrderLine> OrderLines { get; set; }
        public int TableOrdered { get; set; }

        [Required(ErrorMessage = "Please type N.A. if you have no special request.")]
        public string ExtraRequest { get; set; }

        public int? ServeListId { get; set; }
        public virtual ServeList ServeList { get; set; }








    }

}







