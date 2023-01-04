using Microsoft.AspNetCore.Mvc;
using EadProject.Models;
using EadProject.Repositories.Interfaces;

namespace EadProject.Controllers
{
    public class ProfileController : Controller
	{
		private readonly IUsersRepository _userRepository = null;
		private readonly IBooksRepository _bookRepository = null;

		public ProfileController(IUsersRepository userRepository, IBooksRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public ViewResult ProfileBuyerPage(int id)
		{
			Console.WriteLine("cookie : " + HttpContext.Request.Cookies["UserName"]);
			BuyerModel? user = _userRepository.GetBuyerById(id);
			return View(user);
		}
		public ViewResult ProfileSellerPage(int id)
		{
			SellerModel? user = _userRepository.GetSellerById(id);
			List<BookModel>? SellerBooks = _bookRepository.GetAllBooksSeller(id);
			ViewBag.SellerBooks = SellerBooks;
			return View(user);
		}
	}
}
