using Microsoft.AspNetCore.Mvc;
using EadProject.Models;
using EadProject.Repositories.Interfaces;

namespace EadProject.Controllers
{
    public class CartController : Controller
    {
        private readonly IUsersRepository _userRepository = null;

        public CartController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ViewResult DisplayCart(int id)
        {
            //now we need to display all the books in the user cart

            List<BookModel>? cartBooks = _userRepository.GetBuyerCartBooks(id);
            int Total = 0;
            if (cartBooks != null)
            {
                foreach (BookModel book in cartBooks)
                {
                    Total += book.Price;
                }
            }
            ViewBag.Total = Total;
            //the object user will be passed and its cart will be dislayed

            ViewBag.user = _userRepository.GetBuyerById(id);
            if (cartBooks == null)
            {
                ViewBag.ifBooks = "No books in your cart";
            }
            else
            {
                ViewBag.ifBooks = null;
            }

            return View("CartPage", cartBooks);
        }
        public IActionResult CartPage(string BookId, string UserId)
        {
            int BookID = Convert.ToInt32(BookId);
            int buyerID = Convert.ToInt32(UserId);

            //now we need to add the book in user cart in the database

            _userRepository.AddBookToBuyerCart(buyerID, BookID);

            return RedirectToAction(nameof(DisplayCart), new { id = buyerID });

            //the book has been added to user cart
            //now we need to display all the books in the user cart

            /*List<BookModel>? cartBooks = _userRepository.GetBuyerCartBooks(buyerID);
            int Total = 0;
            if(cartBooks != null)
            {
                foreach(BookModel book in cartBooks)
                {
                    Total += book.Price;
                }
            }
            ViewBag.Total = Total;  
            //the object user will be passed and its cart will be dislayed

            ViewBag.user = _userRepository.GetBuyerById(buyerID);
            if(cartBooks == null)
            {
                ViewBag.ifBooks = "No books in your cart";
            }
            else
            {
                ViewBag.ifBooks = null;
            }

            
            

            return View(cartBooks);*/
        }
    }
}
