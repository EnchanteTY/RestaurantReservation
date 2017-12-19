using RestaurantReservation.BL.Repositories;
using System.Web.Mvc;

namespace RestaurantReservation.WebUI.Controllers
{

    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        private IOrderLineRepository orderLineRepository;
        private IServeListRepository serveRepository;

        public OrderController(IOrderRepository repository, IOrderLineRepository lineRepository, IServeListRepository serveRepository)
        {
            this.orderRepository = repository;
            this.orderLineRepository = lineRepository;
            this.serveRepository = serveRepository;

        }
        // GET: Order

        [Authorize(Roles = "Admin,Owner")]
        public ActionResult Index()
        {
            var pendingServeLists = serveRepository.GetPendingServeLists();
            return View(pendingServeLists);
        }


        [Authorize(Roles = "Admin,Owner")]
        public ActionResult OrderList()
        {
            var orderLists = orderRepository.Orders;
            return View(orderLists);
        }

        [Authorize(Roles = "Admin,Owner")]
        public ActionResult OrderDetails(int id)
        {
            var order = orderRepository.GetOrderById(id);
            return View(order);

        }

        [Authorize]
        public ActionResult CustomerOrder(string userId)
        {
            var orders = orderRepository.GetOrderByUserId(userId);
            return View(orders);

        }
    }
}