using RestaurantReservation.BL.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace RestaurantReservation.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;

        public CategoryController()
        {

        }

        public CategoryController(ICategoryRepository repository)
        {
            this.categoryRepository = repository;
        }
        // GET: Category
        public PartialViewResult GetCategoryList()
        {

            var categoryList = categoryRepository.Categories.ToList();
            return PartialView(categoryList);
        }
    }
}