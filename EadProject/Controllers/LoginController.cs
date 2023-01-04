using Microsoft.AspNetCore.Mvc;
using EadProject.Models;
using EadProject.Repositories.Interfaces;

namespace EadProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersRepository _userRepository = null;

        public LoginController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ViewResult LoginPage( bool notExists = false)
        {
            ViewBag.notExists = notExists;
            return View();
        }
        
        [HttpPost]
        public IActionResult LoginPage(string userName, string password)
        {
            string UserName = "";
            if(userName == "admin" && password == "12345678")
            {

                if(HttpContext.Request.Cookies.ContainsKey("UserId"))
                {
                    UserName = HttpContext.Request.Cookies["UserId"];
                }
                else
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = System.DateTime.Now.AddDays(1);
                    HttpContext.Response.Cookies.Append("UserId", Convert.ToString(6), options);
                }
                return RedirectToAction("MainPage", "Admin", new { id = 6});
            }
            SellerModel? ExistantSeller = _userRepository.ifSellerExists(userName, password);
            if(ExistantSeller != null)
            {

                if (HttpContext.Request.Cookies.ContainsKey("UserId"))
                {
                    UserName = HttpContext.Request.Cookies["UserId"];
                }
                else
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = System.DateTime.Now.AddDays(1);
                    HttpContext.Response.Cookies.Append("UserId", Convert.ToString(ExistantSeller.Id), options);
                }
                return RedirectToAction("ProfileSellerPage", "Profile", new { id = ExistantSeller.Id });
                
            }
            BuyerModel? ExistantBuyer = _userRepository.ifBuyerExists(userName, password);
            if(ExistantBuyer != null)
            {
                if (HttpContext.Request.Cookies.ContainsKey("UserId"))
                {
                    UserName = HttpContext.Request.Cookies["UserId"];
                }
                else
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = System.DateTime.Now.AddDays(1);
                    HttpContext.Response.Cookies.Append("UserId", Convert.ToString(ExistantBuyer.Id), options);
                }

                return RedirectToAction("ProfileBuyerPage", "Profile", new { id = ExistantBuyer.Id });
            }
            return RedirectToAction(nameof(LoginPage), new { notExists = true });
        }
    }
}
