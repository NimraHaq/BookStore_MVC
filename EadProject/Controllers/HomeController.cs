using Microsoft.AspNetCore.Mvc;
using EadProject.Repositories.Interfaces;
using EadProject.Repositories;
using EadProject.Models;

namespace EadProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBooksRepository _bookRepository = null;

        public HomeController(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public ViewResult homePage()
        {

            //removing all the cookies
            if (HttpContext.Request.Cookies.ContainsKey("UserName"))
            {
                HttpContext.Response.Cookies.Delete("UserName");
            }
            List<BookModel>? books = _bookRepository.GetAllBooks();
            return View(books);
        }
    }
}
