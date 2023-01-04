using Microsoft.AspNetCore.Mvc;
using EadProject.Repositories.Interfaces;
using EadProject.Repositories;
using EadProject.Models;

namespace EadProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUsersRepository _userRepository = null;
        private readonly IBooksRepository _bookRepository = null;

        public AdminController(IUsersRepository userRepository, IBooksRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public IActionResult MainPage(int id)
        {
            return View();
        }
        public ViewResult RemoveUser(bool isRemoved = false, bool ifNotExists = false)
        {
            ViewBag.isRemoved = isRemoved;
            ViewBag.ifNotExists = ifNotExists;
            return View();
        }
        [HttpPost]
        public IActionResult RemoveUser(string removeUser)
        {
            string? ifBuyerOrSeller = _userRepository.UserBuyerORSeller(removeUser);
            if (ifBuyerOrSeller == null)
            {
                return RedirectToAction(nameof(removeUser), new { isRemoved = false, ifNotExists = true });
            }
            bool deleted = false;
            if (ifBuyerOrSeller == "seller")
            {
                deleted = _userRepository.RemoveSellerByUsername(removeUser);
            }
            if (ifBuyerOrSeller == "buyer")
            {
                deleted = _userRepository.RemoveBuyerByUsername(removeUser);
            }
            return RedirectToAction(nameof(removeUser), new { isRemoved = deleted, ifNotExists = false });
        }

        public ViewResult RemoveBook(bool isRemoved = false, bool ifNotExists = false)
        {
            ViewBag.isRemoved = isRemoved;
            ViewBag.ifNotExists = ifNotExists;
            return View();
        }
        [HttpPost]
        public IActionResult RemoveBook(int removeBook)
        {
            bool ifExists = _bookRepository.ifBookIdExists(removeBook);
            if (ifExists == false)
            {
                return RedirectToAction(nameof(RemoveBook), new { isRemoved = false, ifNotExists = true });
            }
            _bookRepository.DeleteBookById(removeBook);
            return RedirectToAction(nameof(RemoveBook), new { isRemoved = true, ifNotExists = false });

        }
    }
}
