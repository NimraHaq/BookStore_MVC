using Microsoft.AspNetCore.Mvc;
using EadProject.Models;
using EadProject.Repositories.Interfaces;

namespace EadProject.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IUsersRepository _userRepository = null;
        public OrderDetailsController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult OrderDetailsPage(string orderID, string userId)
        {
            int orderId = Convert.ToInt32(orderID);
            int sellerID = Convert.ToInt32(userId);
            Order thisOrder = new Order();  //get order with this order id

            ViewBag.user = _userRepository.GetSellerById(sellerID);

            return View(thisOrder);
        }
        [HttpPost]
        public IActionResult OrderDetailsPage(string deliveryStatus, int sellerID)
        {
            //update delivery status
            return RedirectToAction("ProfileSellerPage", "Profile", new { id = sellerID });
        }
    }
}
