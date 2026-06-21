
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Buoi4_QLBanSach.Models;
using Buoi4_QLBanSach.Models.Services;

namespace Buoi4_QLBanSach.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: BOOKS
        public async Task<IActionResult> Index()
        {
            return View(_bookService.GetAllBooks());
        }

        // GET: BOOKS/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: BOOKS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BOOKS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,PublishedYear,Pages,Language,ImageUrl,CreatedAt,UpdatedAt,Authors")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: BOOKS/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: BOOKS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Price,PublishedYear,Pages,Language,ImageUrl,CreatedAt,UpdatedAt,Authors")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: BOOKS/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: BOOKS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                _bookService.DeleteBook(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index), ex);
            }
        }
    }
}