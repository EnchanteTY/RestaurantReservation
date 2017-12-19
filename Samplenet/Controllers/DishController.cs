using RestaurantReservation.BL.Repositories;
using RestaurantReservation.WebUI.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace RestaurantReservation.WebUI.Controllers
{
    public class DishController : Controller
    {
        private IDishRepository dishRepository;
        private ICategoryRepository categoryRepository;

        public DishController()
        {

        }

        public DishController(IDishRepository repository, ICategoryRepository categoryRepository)
        {
            this.dishRepository = repository;
            this.categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {

            DishCatalogueViewModel viewModel = new DishCatalogueViewModel();
            if (String.IsNullOrEmpty(category))
            {
                viewModel.Dishes = dishRepository.Dishes.ToList();
                viewModel.CurrentCattegory = "All Dishes";

            }
            else
            {
                viewModel.Dishes = dishRepository.GetDishesbyCategory(category);
                viewModel.CurrentCattegory = category;

            }
            return View(viewModel);
        }

        public ViewResult Detail(int id)
        {
            var dish = dishRepository.GetDishbyId(id);
            return View(dish);
        }






    }
}
