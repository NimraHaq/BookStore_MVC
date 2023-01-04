using Microsoft.AspNetCore.Mvc;
using EadProject.Models;
using EadProject.Repositories.Interfaces;

namespace EadProject.Controllers
{
    public class CheckoutController : Controller
	{
		private readonly IUsersRepository _userRepository = null;

		public CheckoutController(IUsersRepository userRepository)
		{
			_userRepository = userRepository;
		}
        [HttpGet]
		public ViewResult CheckoutPage(int id)
		{
			ViewBag.user = _userRepository.GetBuyerById(id);
			return View();
		}
        [HttpPost]
		public IActionResult CheckoutPage(Order order)
		{
			/*
			List<Order> Orders = new List<Order>(); //the user has ordered whole cart, so all the books will have their own orders.

			UserModel? user = _userRepository.GetUserById(order.BuyerID);
			foreach(var item in user.Cart)
            {
				Order OrderItem = new Order()
				{
					DeliveryAdress = order.DeliveryAdress,
					BuyerID = order.BuyerID,
					BooksToOrder = item,
				};
				Orders.Add(OrderItem);
            }

			//now whatever user has ordered need to placed in its order list so,
			user.myOrders = Orders; //user has made orders

			//now we need to update the seller's orders list as well

			foreach(var item in Orders)
            {
				UserModel? seller = _userRepository.GetUserById(item.BooksToOrder.SellerID);
				seller.myOrders.Add(item);
            }
			//now the buyer has made the order and now we have nothing to do with it.
			//and every seller has known about the orders, so we have nothing to do with that as well.
			//now we need to thank buyer for the order.

			*/
			return RedirectToAction(nameof(OrderPlacedPage));//, new { id  = order.BuyerID });
		}


		public ViewResult OrderPlacedPage(int id = 2)
		{
			ViewBag.user = _userRepository.GetBuyerById(id);
			return View();
		}
	}
}
