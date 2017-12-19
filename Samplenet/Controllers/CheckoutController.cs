using RestaurantReservation.BL.Concrete;
using RestaurantReservation.BL.Entities;
using RestaurantReservation.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RestaurantReservation.WebUI.Controllers
{
    public class CheckoutController : Controller
    {

        private IOrderRepository orderRepository;
        private IOrderLineRepository orderLineRepository;
        private IServeListRepository serveRepository;

        public CheckoutController()
        {
            this.orderRepository = new OrderRepository();
            this.orderLineRepository = new OrderLineRepository();
            this.serveRepository = new ServeListRepository();
        }

        public CheckoutController(IOrderRepository repository, IOrderLineRepository lineRepository, IServeListRepository serveRepository)
        {
            this.orderRepository = repository;
            this.orderLineRepository = lineRepository;
            this.serveRepository = serveRepository;

        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            Cart cart = Cart.GetCart();

            Order order = new Order();
            order.UserID = User.Identity.Name;
            order.OrderLines = new List<OrderLine>();
            foreach (var cartline in cart.GetCartLines())
            {
                OrderLine line = new OrderLine
                {
                    DishID = cartline.DishId,
                    DishName = cartline.Dish.Name,
                    Table = cartline.Table,
                    DishSize = cartline.DishSize

                };
                order.OrderLines.Add(line);
            }
            order.TotalPrice = cart.ComputeTotalValue();
            order.TableOrdered = cart.GetTableOrdered(cart.GetCartLines());




            return View("CheckoutForm", order);
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View("CheckoutForm");
            }

            var serveLists = serveRepository.GetServeListByDateTime(order.MealDate.Date, order.MealTime);
            if (serveLists != null)
            {
                if (serveLists.AccumulatedTableOrdered == 10)
                {
                    ModelState.AddModelError("MealTime", "The booking is full for this time");
                    return View("CheckoutForm");
                }
            }

            order.DateCreated = DateTime.Now;
            orderRepository.Add(order);

            Cart cart = Cart.GetCart();
            cart.CreateOrderLines(order.OrderID);
            orderRepository.Save();

            AddOrderIntoServeList(order);
            return View("ThankYou");


        }

        public void AddOrderIntoServeList(Order order)
        {
            var serveList = serveRepository.GetServeListByDateTime(order.MealDate, order.MealTime);
            if (serveList == null)
            {
                ServeList list = new ServeList
                {
                    Date = order.MealDate,
                    Time = order.MealTime,


                };
                serveRepository.Add(list);


                list.OrderOnDateTime = new List<Order>();
                order.ServeListId = list.ServeListId;
                orderRepository.Save();


                list.OrderOnDateTime.Add(order);


                // list.TableWithOrderId = list.AssignTable(order.TableOrdered, order.OrderID);
                list.AccumulatedTableOrdered = order.TableOrdered;

                serveRepository.Save(order);




            }
            else
            {
                order.ServeListId = serveList.ServeListId;
                orderRepository.Save();
                serveList.OrderOnDateTime.Add(order);
                //serveList.TableWithOrderId = serveList.AssignTable(order.TableOrdered, order.OrderID);
                serveList.AccumulatedTableOrdered += order.TableOrdered;

                serveRepository.Save(order);

            }

        }
    }
}