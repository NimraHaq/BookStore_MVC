using Microsoft.AspNetCore.Mvc;
using EadProject.Models;
using EadProject.Repositories;
using EadProject.Repositories.Interfaces;

namespace EadProject.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IUsersRepository _userRepository = null;
        private readonly IBooksRepository _bookRepository = null;

        public CatalogController(IUsersRepository userRepository, IBooksRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public ViewResult CatalogPage(int id)
        {
            ViewBag.user = _userRepository.GetBuyerById(id);

            List<BookModel> AllBooks = _bookRepository.GetAllBooks();

            return View(AllBooks);
        }
        public ViewResult BookDetailsPage(string BookId, string UserId)
        {

            int BookID = Convert.ToInt32(BookId);
            int buyerID = Convert.ToInt32(UserId);
            ViewBag.user = _userRepository.GetBuyerById(buyerID);

            BookModel? book = _bookRepository.GetBookById(BookID);
            return View(book);
        }
    }

    
}
