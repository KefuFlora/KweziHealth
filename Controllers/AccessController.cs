using KweziHealthESOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace KweziHealthESOP.Controllers
{
    public class AccessController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(SystemAdmin admin)
        {
            const string validUsername = "admin";
            const string validPassword = "Admin123";

            if (admin.Username == validUsername &&
                admin.Password == validPassword)
            {
                HttpContext.Session.SetString(
                    "IsAdmin", "true");

                HttpContext.Session.SetString(
                    "Username", admin.Username);

                return RedirectToAction("Index", "Staff");
            }

            ViewBag.Error = "Invalid username or password.";

            return View(admin);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Access");
        }
    }
}