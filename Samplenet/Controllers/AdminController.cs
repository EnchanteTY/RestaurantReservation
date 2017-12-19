using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;
using RestaurantReservation.WebUI.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace RestaurantReservation.WebUI.Controllers
{
    [Authorize(Roles = "Owner")]
    public class AdminController : Controller
    {
        private IDishRepository dishRepository;
        private ICategoryRepository categoryRepository;
        private IDishImageRepository dishImageRepository;
        private IDishImageMappingRepository mappingRepository;

        public AdminController()
        {

        }

        public AdminController(IDishRepository repository, ICategoryRepository categoryRepository,
            IDishImageRepository dishImageRepository, IDishImageMappingRepository dishImageMappingRepository)
        {
            this.dishRepository = repository;
            this.categoryRepository = categoryRepository;
            this.dishImageRepository = dishImageRepository;
            this.mappingRepository = dishImageMappingRepository;
        }
        // GET: Admin


        public PartialViewResult AdminButton()
        {
            return PartialView();
        }

        public ActionResult Dish()
        {
            return View(dishRepository.Dishes);
        }

        public ActionResult Create()
        {
            var viewModel = new DishFormViewModel
            {
                Action = "Create",
                Heading = "Create a new dish",
                CategoryList = new SelectList(categoryRepository.Categories, "ID", "Name"),
                ImageLists = new List<SelectList>()
            };
            for (int i = 0; i < Constant.Constant.ImagesPerDish; i++)
            {
                viewModel.ImageLists.Add(new SelectList(dishImageRepository.DishImages, "ID", "FileName"));
            }



            return View("DishForm", viewModel);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Create(DishFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Create a new dish";
                viewModel.CategoryList = new SelectList(categoryRepository.Categories, "ID", "Name");
                viewModel.ImageLists = new List<SelectList>();
                for (int i = 0; i < Constant.Constant.ImagesPerDish; i++)
                {
                    viewModel.ImageLists.Add(new SelectList(dishImageRepository.DishImages, "ID", "FileName"));
                }
                return View("DishForm", viewModel);
            }

            var dish = new Dish
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                StandardPrice = viewModel.StandardPrice,
                CategoryID = viewModel.CategoryID,

            };



            dishRepository.AddDish(dish);


            string[] dishImages = viewModel.DishImages.Where(pi =>
                !string.IsNullOrEmpty(pi)).ToArray();
            List<DishImageMapping> mappings = new List<DishImageMapping>();
            for (int i = 0; i < dishImages.Length; i++)
            {
                DishImageMapping mapping = new DishImageMapping()
                {
                    DishID = dish.DishID,
                    ImageNumber = i,
                    DishImageID = int.Parse(dishImages[i])

                };
                mappingRepository.Add(mapping);
                mappingRepository.Save();
            }


            TempData["message"] = $"{viewModel.Name} has been saved.";
            return RedirectToAction("Index", "Admin");

        }

        public ActionResult Edit(int id)
        {
            var dish = dishRepository.GetDishbyId(id);

            var viewModel = new DishFormViewModel
            {
                Action = "Edit",
                DishID = dish.DishID,
                Name = dish.Name,
                Description = dish.Description,
                StandardPrice = dish.StandardPrice,
                CategoryID = dish.CategoryID,
                Heading = $"Edit {dish.Name}",
                ImageLists = new List<SelectList>(),
                CategoryList = new SelectList(categoryRepository.Categories, "ID", "Name")

            };



            foreach (var imageMapping in dish.DishImageMappings.OrderBy(pim => pim.ImageNumber))
            {
                viewModel.ImageLists.Add(new SelectList(dishImageRepository.DishImages.ToList(),
                    "ID", "FileName", imageMapping.DishImageID));
            }

            for (int i = viewModel.ImageLists.Count; i < Constant.Constant.ImagesPerDish; i++)
            {
                viewModel.ImageLists.Add(new SelectList(dishImageRepository.DishImages, "ID", "FileName"));
            }

            return View("DishForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DishFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Create a new dish";
                viewModel.CategoryList = new SelectList(categoryRepository.Categories, "ID", "Name");
                viewModel.ImageLists = new List<SelectList>();
                for (int i = viewModel.ImageLists.Count; i < Constant.Constant.ImagesPerDish; i++)
                {
                    viewModel.ImageLists.Add(new SelectList(dishImageRepository.DishImages, "ID", "FileName"));
                }
                return View("DishForm", viewModel);
            }

            var dishToUpdated = dishRepository.GetDishbyId(viewModel.DishID);
            dishToUpdated.Name = viewModel.Name;
            dishToUpdated.CategoryID = viewModel.CategoryID;
            dishToUpdated.StandardPrice = viewModel.StandardPrice;
            dishToUpdated.Description = viewModel.Description;

            dishRepository.Save();

            var mappings = mappingRepository.GetMappingByDishId(viewModel.DishID);

            if (mappings == null)
            {
                mappings = new List<DishImageMapping>();
            }
            string[] dishImages = viewModel.DishImages.Where(pi =>
             !string.IsNullOrEmpty(pi)).ToArray();
            for (int i = 0; i < dishImages.Length; i++)
            {
                var mappingToUpdated = mappingRepository.GetMappingByDishIdAndImageNumber(viewModel.DishID, i);
                if (mappingToUpdated == null)
                {
                    DishImageMapping mapping = new DishImageMapping()
                    {
                        DishID = viewModel.DishID,
                        ImageNumber = i,
                        DishImageID = int.Parse(dishImages[i])

                    };
                    mappingRepository.Add(mapping);
                }
                else
                {
                    if (mappingToUpdated.DishImageID != int.Parse(dishImages[i]))
                    {
                        mappingToUpdated.DishImageID = int.Parse(dishImages[i]);
                    }
                }

            }
            for (int i = dishImages.Length; i < Constant.Constant.ImagesPerDish; i++)
            {
                var mappingToUpdated = mappingRepository.GetMappingByDishIdAndImageNumber(viewModel.DishID, i);
                if (mappingToUpdated != null)
                {
                    mappingRepository.Remove(mappingToUpdated);
                }
            }

            mappingRepository.Save();

            TempData["message"] = $"The edited {viewModel.Name} has been saved.";
            return RedirectToAction("Dish");

        }

        public ActionResult Delete(int id)
        {
            Dish dish = dishRepository.GetDishbyId(id);
            return View(dish);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dish dish = dishRepository.GetDishbyId(id);
            dishRepository.Remove(dish);
            dishRepository.Save();

            TempData["message"] = $"{dish.Name} has been deletedd.";
            return RedirectToAction("Index");
        }


    }
}