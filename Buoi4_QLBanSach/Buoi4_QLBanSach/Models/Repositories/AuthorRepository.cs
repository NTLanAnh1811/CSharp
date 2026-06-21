using Microsoft.EntityFrameworkCore;

namespace Buoi4_QLBanSach.Models.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly QlsachContext _context;
        public AuthorRepository(QlsachContext context)
        {
            _context = context;
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == id);
            if(author != null) {
                author.Books.Clear();
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author? GetById(int id)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }
}
