using Microsoft.AspNetCore.Mvc;
using EadProject.Models;
using EadProject.Repositories.Interfaces;

namespace EadProject.Controllers
{
    public class UpdateBookInfoController : Controller
    {
        private readonly IUsersRepository _userRepository = null;
        private readonly IBooksRepository _bookRepository = null;
        public UpdateBookInfoController(IUsersRepository userRepository, IBooksRepository bookRepo)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepo;
        }
        public IActionResult UpdateBookInfoPage(string bookID, string userId, bool isBookUpdated = false)
        {

            int BookID = Convert.ToInt32(bookID);
            int sellerID = Convert.ToInt32(userId);

            SellerModel? user = _userRepository.GetSellerById(sellerID);
            ViewBag.user = user;
            ViewBag.isBookUpdated = isBookUpdated;

            BookModel? bookToUpdate = _bookRepository.GetBookById(BookID);

            return View(bookToUpdate);
        }

        [HttpPost]
        public IActionResult UpdateBookInfoPage(BookModel book)
        {
            if(ModelState.IsValid)
            {
                //update the book information in the database
                int ModifierId = Convert.ToInt32(HttpContext.Request.Cookies["UserId"]);
                _bookRepository.UpdateBookInfo(book, ModifierId);
                return RedirectToAction("ProfileSellerPage", "Profile", new { id = book.SellerId });
            }
            return View();
        }
    }
}
