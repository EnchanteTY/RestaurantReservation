using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;
using RestaurantReservation.WebUI.ViewModels;
using System.Web.Mvc;

namespace RestaurantReservation.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IDishRepository dishRepository;

        public CartController()
        {

        }

        public CartController(IDishRepository repository)
        {
            this.dishRepository = repository;
        }

        public ActionResult Index()
        {
            Cart cart = Cart.GetCart();

            DishIndexViewModel viewModel = new DishIndexViewModel
            {
                Cart = cart,
                CartLines = cart.GetCartLines(),

            };
            return View(viewModel);
        }

        public ActionResult AddToCart(int dishId)
        {
            Cart cart = Cart.GetCart();



            cart.AddItem(dishId, table: 1, size: DishSize.Standard);

            return RedirectToAction("Index");

        }



        public ActionResult RemoveLine(int id)
        {
            Cart cart = Cart.GetCart();
            cart.RemoveLine(dishRepository.GetDishbyId(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCart(DishIndexViewModel viewModel)
        {
            Cart cart = Cart.GetCart();

            cart.Update(viewModel.CartLines);
            return RedirectToAction("Index");
        }



        public PartialViewResult CartSummary()
        {
            Cart cart = Cart.GetCart();
            CartSummaryViewModel viewModel = new CartSummaryViewModel
            {
                NumberOfDishes = cart.GetNumberOfDish(),
                TotalCost = cart.ComputeTotalValue()
            };
            return PartialView(viewModel);
        }



    }
}