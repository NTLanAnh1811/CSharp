
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Buoi4_QLBanSach.Models;
using Buoi4_QLBanSach.Models.Services;

namespace Buoi4_QLBanSach.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: AUTHORS
        public async Task<IActionResult> Index()
        {
            return View(_authorService.GetAllAuthor());
        }

        // GET: AUTHORS/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: AUTHORS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AUTHORS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthYear,Nationality,Biography")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorService.AddAuthor(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: AUTHORS/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: AUTHORS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,BirthYear,Nationality,Biography")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _authorService.UpdateAuthor(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: AUTHORS/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: AUTHORS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                _authorService.DeleteAuthor(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index), ex);
            }
        }
    }
}