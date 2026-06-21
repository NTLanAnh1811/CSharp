using Buoi4_QLBanSach.Models.Repositories;

namespace Buoi4_QLBanSach.Models.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
           _bookRepository.Add(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book? GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
