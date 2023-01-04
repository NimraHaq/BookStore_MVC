using Microsoft.AspNetCore.Mvc;
using EadProject.Repositories.Interfaces;
using EadProject.Models;

namespace EadProject.Controllers
{
    public class AddNewBookController : Controller
    {
        private readonly IUsersRepository _userRepository = null;
        private readonly IBooksRepository _bookRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public AddNewBookController(IUsersRepository userRepository, IBooksRepository bookRepository, IWebHostEnvironment webHostEnvironment)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        //
        [HttpGet]
        public IActionResult AddNewBookPage(int id, bool isAdded = false)
        {
            ViewBag.user = _userRepository.GetSellerById(id);
            ViewBag.isAdded = isAdded;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewBookPage(BookModel book)
        {
            if(ModelState.IsValid)
            {
                if (book.BookPicture == null)
                {
                    //if user did not upload a profile picture, we will add a default profile picture
                    book.BookPictureURL = "/Images/history.jpg";
                }
                else if (book.BookPicture != null)
                {
                    string folder = @"BookPictures/";
                    //we need to make images names unique, we are having unique usernames so
                    folder += Guid.NewGuid().ToString() + "_";
                    folder += book.BookPicture.FileName;

                    book.BookPictureURL = "/" + folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    //saving the image path
                    book.BookPicture.CopyTo(new FileStream(serverFolder, FileMode.Create));
                }
                int idCreater = Convert.ToInt32(HttpContext.Request.Cookies["UserId"]);
                int id =  _bookRepository.AddNewBook(book, idCreater);
                return RedirectToAction(nameof(AddNewBookPage), new { isAdded = true });
            }
            return View();
        }
    }
}
