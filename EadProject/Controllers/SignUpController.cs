using Microsoft.AspNetCore.Mvc;
using EadProject.Models;
using System.Diagnostics;
using EadProject.Repositories.Interfaces;

namespace EadProject.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IUsersRepository _userRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        private readonly ILogger<HomeController> _logger;


        public SignUpController(IUsersRepository userRepository, IWebHostEnvironment webHostEnvironment, ILogger<HomeController> logger)
        {
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public ViewResult SignUpPage(bool isCreated = false)
        {
            ViewBag.isCreated = isCreated;
            return View();
        }

        //form method = "post" in our view
        [HttpPost]
        public IActionResult SignUpPage(UserModel user )
        {
            if(ModelState.IsValid)
            {
                if(_userRepository.ifUserNameExists(user.UserName) == true) //if username already exists
                {
                    ModelState.AddModelError(string.Empty, "This username already exists. Try another one.");
                    return View();
                }
                if(user.ProfilePicture == null)
                {
                    //if user did not upload a profile picture, we will add a default profile picture
                    user.profilePictureURL = "/Images/profile.png";
                }
                else if(user.ProfilePicture != null)
                {
                    string folder = @"ProfilePictures/";
                    //we need to make images names unique, we are having unique usernames so
                    folder += user.UserName + "_";
                    folder += user.ProfilePicture.FileName;

                    user.profilePictureURL = "/" + folder;
                    
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    //saving the image path
                    user.ProfilePicture.CopyTo(new FileStream(serverFolder, FileMode.Create));
                }
                int id = 0;
                if(user.Role == "buyer")
                {
                    id = _userRepository.AddNewBuyer(user);
                    _userRepository.SetCreatedByBuyer(id);
                }
                else if (user.Role == "seller")
                {
                    id = _userRepository.AddNewSeller(user);
                    _userRepository.SetCreatedBySeller(id);
                }
                if (id > 0)
                {
                    return RedirectToAction(nameof(SignUpPage), new { isCreated = true });
                }
            }
            return View();
        }
    }
}
