using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RestaurantReservation.WebUI.ViewModels.Admin
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }

    }
}