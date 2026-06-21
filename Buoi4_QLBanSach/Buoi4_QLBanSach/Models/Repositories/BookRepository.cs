using Microsoft.EntityFrameworkCore;

namespace Buoi4_QLBanSach.Models.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly QlsachContext _qlsachContext;
        public BookRepository(QlsachContext qlsachContext)
        {
            _qlsachContext = qlsachContext;
        }

        public void Add(Book book)
        {
            _qlsachContext.Books.Add(book);
            _qlsachContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _qlsachContext.Books.Find(id);
            if(book != null) {
                _qlsachContext.Books.Remove(book);
                _qlsachContext.SaveChanges();
            }
        }

        public List<Book> GetAll()
        {
            return _qlsachContext.Books.Include(b => b.Authors).Include(b => b.Categories).ToList();
        }

        public Book? GetById(int id)
        {
            return _qlsachContext.Books.Include(b => b.Authors).Include(b => b.Categories).FirstOrDefault(b => b.Id == id);
        }

        public void Update(Book book)
        {
            _qlsachContext.Books.Update(book);
            _qlsachContext.SaveChanges();
        }
    }
}
