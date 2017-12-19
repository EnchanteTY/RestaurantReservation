using RestaurantReservation.BL.Concrete;
using System;
using System.Collections.Generic;
using System.Web;

namespace RestaurantReservation.BL.Entities
{
    public class Cart
    {

        CartLineRepository lineRepository = new CartLineRepository();
        OrderLineRepository orderLineRepository = new OrderLineRepository();
        private string CartID { get; set; }
        private const string CartSessionKey = "CartID";


        private string GetCartID()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] =
                 HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempCartID = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartID.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public static Cart GetCart()
        {
            Cart cart = new Cart();
            cart.CartID = cart.GetCartID();
            return cart;
        }



        public void AddItem(int dishId, int table, DishSize size)
        {
            CartLine line = lineRepository.GetCartLineByDishId(dishId, CartID);

            if (line == null)
            {
                var newLine = new CartLine
                {
                    CartId = CartID,
                    DishId = dishId,
                    Table = table,
                    DishSize = size,
                    DateCreated = DateTime.Now

                };
                lineRepository.Add(newLine);
                lineRepository.Save();
            }
            else
            {
                line.Table = table;
                line.DishSize = size;
                line.DateCreated = DateTime.Now;

                lineRepository.Save();
            }
        }

        public void RemoveLine(Dish dish)
        {
            lineRepository.Remove(lineRepository.GetCartLineByDishId(dish.DishID, CartID));
        }

        public void Update(List<CartLine> lines)
        {
            foreach (var line in lines)
            {
                var dishToUpdate = lineRepository.GetCartLineByDishId(line.DishId, CartID);
                dishToUpdate.DishSize = line.DishSize;
                dishToUpdate.Table = line.Table;
                dishToUpdate.Subtotal = line.CalculatePriceForDish(line.Table, line.DishSize, line.Dish.StandardPrice);
            }
            lineRepository.Save();
        }
        public decimal ComputeTotalValue()
        {
            ICollection<CartLine> lines = lineRepository.GetCartLinesByCartId(CartID);
            decimal total = 0;
            foreach (var item in lines)
            {
                CartLine line = new CartLine();
                decimal priceForDish = line.CalculatePriceForDish(item.Table, item.DishSize, item.Dish.StandardPrice);
                total += priceForDish;
            }

            return total;

        }
        public void Clear()
        {
            ICollection<CartLine> lines = lineRepository.GetCartLinesByCartId(CartID);
            foreach (var item in lines)
            {
                lineRepository.Remove(item);
            }
        }

        public int GetNumberOfDish()
        {

            ICollection<CartLine> lines = lineRepository.GetCartLinesByCartId(CartID);
            return lines.Count;
        }

        public void MigrateBasket(string userName)
        {
            var cart = lineRepository.GetCartLinesByCartId(CartID);

            var userCart = lineRepository.GetCartLineByUserName(userName);

            if (userCart != null)
            {
                //set the basketID to the username
                string prevID = CartID;
                CartID = userName;
                //add the lines in anonymous basket to the user's basket
                foreach (var line in cart)
                {
                    AddItem(line.DishId, line.Table, line.DishSize);
                }
                //delete the lines in the anonymous basket from the database
                CartID = prevID;
                Clear();
            }
            else
            {
                //if the user does not have a basket then just migrate this one
                foreach (var line in cart)
                {
                    line.CartId = userName;
                }

                lineRepository.Save();

            }
            HttpContext.Current.Session[CartSessionKey] = userName;
        }

        public List<CartLine> GetCartLines()
        {
            return lineRepository.GetCartLinesByCartId(CartID);
        }

        public void CreateOrderLines(int orderId)
        {


            var cartLines = GetCartLines();

            foreach (var line in cartLines)
            {
                OrderLine orderLine = new OrderLine
                {
                    DishID = line.DishId,
                    DishSize = line.DishSize,
                    Table = line.Table,
                    OrderID = orderId,
                    DishName = line.Dish.Name,
                    SubTotal = line.CalculatePriceForDish(line.Table, line.DishSize, line.Dish.StandardPrice)
                };

                orderLineRepository.Add(orderLine);

            }

            orderLineRepository.Save();
            Clear();

        }

        public int GetTableOrdered(List<CartLine> lines)
        {
            int maxTable = 0;
            foreach (var line in lines)
            {
                int Table = line.Table;
                if (Table > maxTable)
                {
                    maxTable = Table;
                }
            }

            return maxTable;
        }



    }
}

