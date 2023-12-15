using Microsoft.AspNetCore.Mvc;

namespace Indigo_Project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(int id)
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(int id)
        {
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
    }
}
