using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RestaurantReservation.WebUI.ViewModels
{
    public class DishFormViewModel
    {


        public int DishID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public decimal StandardPrice { get; set; }

        [Display(Name = "Category")]
        public int? CategoryID { get; set; }

        public SelectList CategoryList { get; set; }

        public List<SelectList> ImageLists { get; set; }

        public string[] DishImages { get; set; }

        public string Heading { get; set; }

        public string Action { get; set; }




    }
}