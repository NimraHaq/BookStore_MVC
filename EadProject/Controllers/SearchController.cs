using Microsoft.AspNetCore.Mvc;
using EadProject.Repositories;
using EadProject.Repositories.Interfaces;
using EadProject.Models;

namespace EadProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUsersRepository _userRepository = null;
        private readonly IBooksRepository _bookRepository = null;

        public SearchController(IUsersRepository userRepository, IBooksRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public IActionResult SearchPage(int id, List<BookModel>? resultBooks = null, bool BookFound = false)
        {

            Console.WriteLine("cookie : " + HttpContext.Request.Cookies["UserName"]);

            /*if (HttpContext.Request.Cookies.ContainsKey("UserName"))
            {
                Console.WriteLine("Cookie is : " + HttpContext.Request.Cookies["UserName"]);
            }
            else
            {
                Console.WriteLine("no it doesnot");
            }
            */
            ViewBag.user = _userRepository.GetBuyerById(id);
            ViewBag.ResultBooks = resultBooks;
            ViewBag.BookFound = BookFound;
            return View();
        }
        [HttpPost]
        public IActionResult SearchPage( string Category, string PriceRange, string searchBook, int buyerId)//SearchBookObject obj)
        {

            /*string Category = obj.Category;
            string PriceRange = obj.PriceRange;
            string searchBook = obj.searchBook;
            int buyerId = obj.buyerId;*/

            List<BookModel>? ResultBooks;
            if (Category == "All" && PriceRange == "AllPrice" && searchBook != null)
            {
                 ResultBooks = _bookRepository.GetBookForName(searchBook);
            }
            else if(Category == "All" && PriceRange != "AllPrice" && searchBook != null)
            {
                int minPrice = 0;
                int? maxPrice = 0;
                switch(PriceRange)
                {
                    case "low":
                        minPrice = 20; maxPrice = 1000;
                        break;
                    case "medium":
                        minPrice = 1001; maxPrice = 2000;
                        break;
                    case "high":
                        minPrice = 2001; maxPrice = null;
                        break;
                }
                ResultBooks = _bookRepository.GetBookForNamePrice(minPrice, maxPrice, searchBook);
            }
            else if(Category != "All" && PriceRange == "AllPrice" && searchBook != null)
            {
                ResultBooks = _bookRepository.GetBookForNameCategory(Category, searchBook);
            }
            else if(Category != "All" && PriceRange != "AllPrice" && searchBook == null)
            {
                int minPrice = 0;
                int? maxPrice = 0;
                switch (PriceRange)
                {
                    case "low":
                        minPrice = 20; maxPrice = 1000;
                        break;
                    case "medium":
                        minPrice = 1001; maxPrice = 2000;
                        break;
                    case "high":
                        minPrice = 2001; maxPrice = null;
                        break;
                }
                ResultBooks = _bookRepository.GetBookForCategoryPrice(Category, minPrice, maxPrice);
            }
            else if(Category != "All" && PriceRange == "AllPrice" && searchBook == null)
            {
                ResultBooks = _bookRepository.GetBookForCategory(Category);
            }
            else if(Category == "All" && PriceRange != "AllPrice" && searchBook == null)
            {
                int minPrice = 0;
                int? maxPrice = 0;
                switch (PriceRange)
                {
                    case "low":
                        minPrice = 20; maxPrice = 1000;
                        break;
                    case "medium":
                        minPrice = 1001; maxPrice = 2000;
                        break;
                    case "high":
                        minPrice = 2001; maxPrice = null;
                        break;
                }
                ResultBooks = _bookRepository.GetBookForPrice(minPrice, maxPrice);
            }
            else if(Category != "All" && PriceRange != "AllPrice" && searchBook != null)
            {
                int minPrice = 0;
                int? maxPrice = 0;
                switch (PriceRange)
                {
                    case "low":
                        minPrice = 20; maxPrice = 1000;
                        break;
                    case "medium":
                        minPrice = 1001; maxPrice = 2000;
                        break;
                    case "high":
                        minPrice = 2001; maxPrice = null;
                        break;
                }
                ResultBooks = _bookRepository.GetBookForPriceCategoryName(Category, minPrice, maxPrice, searchBook);
            }
            else
            {
                ResultBooks = _bookRepository.GetAllBooks();
            }
            bool bookFound = false;
            if(ResultBooks != null)
            {
                bookFound = true;
            }
            ViewBag.user = _userRepository.GetBuyerById(buyerId);
            ViewBag.ResultBooks = ResultBooks;
            ViewBag.BookFound = bookFound;
            //return Json(ResultBooks);
           return View();
            /*            return RedirectToAction(nameof(SearchPage), new { id = buyerId, resultBooks = ResultBooks, BookFound = bookFound });
            */
        }
    }
}
