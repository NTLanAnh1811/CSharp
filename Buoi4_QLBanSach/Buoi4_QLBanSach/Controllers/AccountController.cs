using Buoi4_QLBanSach.Models;
using Buoi4_QLBanSach.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Buoi4_QLBanSach.Controllers
{
    public class AccountController : Controller
    {
        private readonly QlsachContext _context;
        public AccountController(QlsachContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _context.Users.FirstOrDefault(
                u => u.Username == model.Username && u.PasswordHash == model.Password);
            if(user == null) {
                ViewBag.Error = "Sai tai khoan hoac mat khau";
                return View();
            }
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
