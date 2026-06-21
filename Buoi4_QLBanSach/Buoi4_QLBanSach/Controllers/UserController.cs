using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Buoi4_QLBanSach.Models;
using Buoi4_QLBanSach.Models.Services;

namespace Buoi4_QLBanSach.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: USERS
        public async Task<IActionResult> Index()
        {
            return View(_userService.GetAllUser());
        }

        // GET: USERS/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: USERS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: USERS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,PasswordHash,Email,Role,FullName,CreatedAt")] User user)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: USERS/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Content("Ban khong co quyen truy cap");
            }
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: USERS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Username,PasswordHash,Email,Role,FullName,CreatedAt")] User user)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Content("Ban khong co quyen truy cap");
            }
            if (id != user.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: USERS/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Content("Ban khong co quyen truy cap");
            }
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: USERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Content("Ban khong co quyen truy cap");
            }
            try
            {
                _userService.DeleteUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index), ex);
            }
        }
    }
}